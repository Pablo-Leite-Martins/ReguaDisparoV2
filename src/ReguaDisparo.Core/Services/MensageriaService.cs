using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço de mensageria - busca base de dados conforme tipo de ação
/// Usa stored procedures para performance em queries complexas
/// </summary>
public class MensageriaService : IMensageriaService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<MensageriaService> _logger;

    // Cache de dados para evitar múltiplas buscas no mesmo processamento
    private Dictionary<string, (DateTime timestamp, object data)> _cache = new();
    private readonly TimeSpan _cacheTimeout = TimeSpan.FromMinutes(5);

    public MensageriaService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<MensageriaService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<DestinatarioMensageria>> BuscarBaseMensageriaAsync(
        string tipoAcao,
        string? descricaoAcao,
        bool cobrancaPreventiva,
        string nomeBancoCrm,
        string idOrganizacao)
    {
        try
        {
            _logger.LogInformation("Buscando base mensageria - Tipo: {Tipo}, Descrição: {Descricao}, Preventiva: {Preventiva}", 
                tipoAcao, descricaoAcao, cobrancaPreventiva);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var proceduresRepo = new ClienteMaisStoredProceduresRepository(
                crmDb,
                _loggerFactory.CreateLogger<ClienteMaisStoredProceduresRepository>());

            var descricaoUpper = descricaoAcao?.ToUpper() ?? "";

            // Roteamento baseado no tipo e descrição da ação
            if (descricaoUpper.Contains("PÓS OCUPACIONAL") || descricaoUpper.Contains("POS OCUPACIONAL"))
            {
                return await BuscarBasePosOcupacionalAsync(proceduresRepo);
            }
            else if (descricaoUpper.Contains("EMAIL ANIVERSARIO") || descricaoUpper.Contains("ANIVERSÁRIO"))
            {
                return await BuscarBaseRelacionamentoAsync(proceduresRepo, apenasAniversariantes: true);
            }
            else if (descricaoUpper.Contains("RELACIONAMENTO COM CLIENTE"))
            {
                return await BuscarBaseRelacionamentoAsync(proceduresRepo, apenasAniversariantes: false);
            }
            else if (tipoAcao.ToUpper().Contains("EMAIL") || tipoAcao.ToUpper().Contains("SMS") || tipoAcao.ToUpper().Contains("WHATSAPP"))
            {
                // Mensageria de cobrança (principal)
                return await BuscarBaseCobrancaAsync(
                    proceduresRepo, 
                    cobrancaPreventiva, 
                    idOrganizacao);
            }
            else
            {
                _logger.LogWarning("Tipo de ação não reconhecido para mensageria: {TipoAcao}", tipoAcao);
                return new List<DestinatarioMensageria>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria");
            throw;
        }
    }

    private async Task<List<DestinatarioMensageria>> BuscarBaseCobrancaAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo,
        bool cobrancaPreventiva,
        string idOrganizacao)
    {
        var dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var incluirTodasEmpresas = idOrganizacao == "COLORADO"; // Regra específica Colorado

        if (cobrancaPreventiva)
        {
            // Cobrança preventiva (títulos a vencer)
            _logger.LogDebug("Buscando base de cobrança preventiva");
            var baseAReceber = await proceduresRepo.BuscarBaseMensageriaAReceberAsync(dataInicio, incluirTodasEmpresas);
            
            return baseAReceber.Select(b => new DestinatarioMensageria
            {
                IdEmpresa = b.ID_EMPRESA,
                IdObra = b.ID_OBRA,
                IdVenda = b.ID_VENDA,
                Cliente = b.DS_CLIENTE,
                Email = b.DS_EMAIL,
                DDD = b.COD_DDD,
                Telefone = b.NR_TELEFONE,
                Produto = b.DS_PRODUTO,
                DataVencimento = b.DT_VENCIMENTO_PROXIMO,
                ValorParcela = b.VL_PROXIMO_VENCIMENTO,
                DiasAteVencimento = b.DIAS_ATE_VENCIMENTO
            }).ToList();
        }
        else
        {
            // Cobrança normal (títulos vencidos)
            _logger.LogDebug("Buscando base de cobrança (vencidos)");
            
            // Busca base de cobrança principal
            var baseCobranca = await proceduresRepo.BuscarBaseMensageriaCobrancaAsync(dataInicio);
            
            // Busca base de parcelas para complementar informações
            List<BaseMensageriaParcelas>? baseParcelas = null;
            try
            {
                baseParcelas = await proceduresRepo.BuscarBaseMensageriaParcelasAsync(dataInicio, incluirTodasEmpresas);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Erro ao buscar base de parcelas, continuando sem ela");
            }

            return baseCobranca.Select(b => new DestinatarioMensageria
            {
                IdEmpresa = b.ID_EMPRESA,
                IdObra = b.ID_OBRA,
                IdVenda = b.ID_VENDA,
                Cliente = b.DS_CLIENTE,
                Email = b.DS_EMAIL,
                DDD = b.COD_DDD,
                Telefone = b.NR_TELEFONE,
                Produto = b.DS_PRODUTO,
                ChaveErp = b.ID_CHAVE_ERP,
                Identificador = b.DS_IDENTIFICADOR,
                ClassificacaoContrato = b.DS_CLASSIFICACAO_CONTRATO,
                AgingDias = b.NR_AGING_DIAS_CONTRATO,
                ValorVencido = b.VL_TOTAL_VENCIDO,
                ValorAVencer = b.VL_TOTAL_A_VENCER,
                DataVencimento = b.DT_VENCIMENTO_MAIS_ANTIGO,
                QuantidadeParcelasVencidas = b.QT_PARCELAS_VENCIDAS
            }).ToList();
        }
    }

    private async Task<List<DestinatarioMensageria>> BuscarBasePosOcupacionalAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo)
    {
        _logger.LogDebug("Buscando base pós-ocupacional");
        
        var basePosOcupacional = await proceduresRepo.BuscarBaseMensageriaPosOcupacionalAsync();
        
        return basePosOcupacional.Select(b => new DestinatarioMensageria
        {
            IdEmpresa = b.ID_EMPRESA,
            IdObra = b.ID_OBRA,
            IdVenda = b.ID_VENDA,
            Cliente = b.DS_CLIENTE,
            Email = b.DS_EMAIL,
            DDD = b.COD_DDD,
            Telefone = b.NR_TELEFONE,
            DataEntregaChaves = b.DT_ENTREGA_CHAVES
        }).ToList();
    }

    private async Task<List<DestinatarioMensageria>> BuscarBaseRelacionamentoAsync(
        IClienteMaisStoredProceduresRepository proceduresRepo,
        bool apenasAniversariantes)
    {
        _logger.LogDebug("Buscando base de relacionamento (aniversariantes: {Flag})", apenasAniversariantes);
        
        var baseRelacionamento = await proceduresRepo.BuscarBaseMensageriaRelacionamentoAsync(apenasAniversariantes);
        
        return baseRelacionamento.Select(b => new DestinatarioMensageria
        {
            IdEmpresa = b.ID_EMPRESA,
            IdObra = b.ID_OBRA,
            IdVenda = b.ID_VENDA,
            Cliente = b.DS_CLIENTE,
            Email = b.DS_EMAIL,
            DDD = b.COD_DDD,
            Telefone = b.NR_TELEFONE,
            DataNascimento = b.DT_NASCIMENTO,
            Aniversariante = b.FL_ANIVERSARIANTE_MES
        }).ToList();
    }

    /// <summary>
    /// Limpa cache de dados
    /// </summary>
    public void LimparCache()
    {
        _cache.Clear();
        _logger.LogDebug("Cache de mensageria limpo");
    }
}
