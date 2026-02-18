using System.Data;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço de mensageria - busca base de dados conforme tipo de ação
/// Usa stored procedures para performance em queries complexas
/// Implementa cache de dados para evitar múltiplas buscas
/// </summary>
public class MensageriaService : IMensageriaService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<MensageriaService> _logger;

    // Cache de dados (replicando lógica do projeto antigo com blnFirstExec)
    private static bool _blnFirstExec = false;
    private static DataTable? _dtDadosCobranca = null;
    private static DataTable? _dtDadosCobrancaParcelas = null;
    private static DataTable? _dtDadosCobrancaPreventiva = null;
    private static DateTime _ultimaExecucao = DateTime.MinValue;
    private static readonly object _lockObj = new object();

    public MensageriaService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<MensageriaService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<DataTable> BuscarBaseMensageriaAsync(
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        bool cobrancaPreventiva,
        string nomeBancoCrm)
    {
        try
        {
            var dsTipoAcao = acao.ID_TIPO_ACAONavigation?.DS_TIPO_ACAO ?? "";
            
            _logger.LogInformation("Buscando base mensageria - Tipo: {Tipo}, Descrição: {Descricao}, Preventiva: {Preventiva}", 
                dsTipoAcao, acao.DS_NOME_ACAO, cobrancaPreventiva);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var proceduresRepo = new ClienteMaisStoredProceduresRepository(
                crmDb,
                _loggerFactory.CreateLogger<ClienteMaisStoredProceduresRepository>());

            // Roteamento baseado no tipo e descrição da ação
            if (dsTipoAcao.Contains("PÓS OCUPACIONAL") || dsTipoAcao.Contains("POS OCUPACIONAL"))
            {
                return await BuscarBasePosOcupacionalAsync(proceduresRepo);
            }
            else if (dsTipoAcao.Contains("EMAIL ANIVERSARIO") || dsTipoAcao.Contains("ANIVERSÁRIO"))
            {
                return await BuscarBaseRelacionamentoAsync(proceduresRepo, apenasAniversariantes: true);
            }
            else if (dsTipoAcao.Contains("RELACIONAMENTO COM CLIENTE"))
            {
                return await BuscarBaseRelacionamentoAsync(proceduresRepo, apenasAniversariantes: false);
            }
            else
            {
                // Mensageria de cobrança (principal) - implementa cache como no projeto antigo
                return await BuscarBaseCobrancaAsync(proceduresRepo, cobrancaPreventiva);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria");
            throw;
        }
    }

    private async Task<DataTable> BuscarBaseCobrancaAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo,
        bool cobrancaPreventiva)
    {
        var dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        // Implementa lógica de cache como no projeto antigo
        lock (_lockObj)
        {
            // Verifica se precisa recarregar (nova data ou primeira execução)
            if (!_blnFirstExec || _ultimaExecucao.Date != DateTime.Now.Date)
            {
                _blnFirstExec = false;
                _dtDadosCobranca = null;
                _dtDadosCobrancaParcelas = null;
                _dtDadosCobrancaPreventiva = null;
                _ultimaExecucao = DateTime.Now;
            }
        }

        if (!_blnFirstExec)
        {
            _logger.LogInformation("Primeira execução ou nova data - carregando dados de mensageria");
            
            // Busca base de cobrança
            _dtDadosCobranca = await proceduresRepo.BuscarBaseMensageriaCobrancaAsync(dataInicio);
            _logger.LogDebug("Base cobrança carregada: {Count} registros", _dtDadosCobranca.Rows.Count);
            
            // Busca base de parcelas
            try
            {
                _dtDadosCobrancaParcelas = await proceduresRepo.BuscarBaseMensageriaParcelasAsync(dataInicio);
                _logger.LogDebug("Base parcelas carregada: {Count} registros", _dtDadosCobrancaParcelas.Rows.Count);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Erro ao buscar base de parcelas, continuando sem ela");
                _dtDadosCobrancaParcelas = null;
            }
            
            // Busca base preventiva
            _dtDadosCobrancaPreventiva = await proceduresRepo.BuscarBaseMensageriaAReceberAsync(dataInicio);
            _logger.LogDebug("Base preventiva carregada: {Count} registros", _dtDadosCobrancaPreventiva.Rows.Count);
            
            _blnFirstExec = true;
        }
        else
        {
            _logger.LogDebug("Usando dados em cache de mensageria");
        }

        // Retorna cópia dos dados conforme tipo de cobrança
        DataTable dtDados;
        if (!cobrancaPreventiva)
        {
            dtDados = _dtDadosCobranca!.Copy();
            _logger.LogInformation("Retornando base de cobrança: {Count} registros", dtDados.Rows.Count);
        }
        else
        {
            dtDados = _dtDadosCobrancaPreventiva!.Copy();
            _logger.LogInformation("Retornando base preventiva: {Count} registros", dtDados.Rows.Count);
        }

        return dtDados;
    }

    private async Task<DataTable> BuscarBasePosOcupacionalAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo)
    {
        _logger.LogDebug("Buscando base pós-ocupacional");
        var dtDados = await proceduresRepo.BuscarBaseMensageriaPosOcupacionalAsync();
        _logger.LogInformation("Base pós-ocupacional retornou {Count} registros", dtDados.Rows.Count);
        return dtDados;
    }

    private async Task<DataTable> BuscarBaseRelacionamentoAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo,
        bool apenasAniversariantes)
    {
        _logger.LogDebug("Buscando base de relacionamento (aniversariantes: {Flag})", apenasAniversariantes);
        var dtDados = await proceduresRepo.BuscarBaseMensageriaRelacionamentoAsync(apenasAniversariantes);
        _logger.LogInformation("Base relacionamento retornou {Count} registros", dtDados.Rows.Count);
        return dtDados;
    }

    /// <summary>
    /// Limpa cache de dados - útil para forçar recarga
    /// </summary>
    public static void LimparCache()
    {
        lock (_lockObj)
        {
            _blnFirstExec = false;
            _dtDadosCobranca = null;
            _dtDadosCobrancaParcelas = null;
            _dtDadosCobrancaPreventiva = null;
        }
    }
}
