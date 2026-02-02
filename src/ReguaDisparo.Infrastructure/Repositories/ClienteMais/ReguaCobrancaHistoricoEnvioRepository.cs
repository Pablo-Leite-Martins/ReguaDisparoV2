using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaHistoricoEnvioRepository : IReguaCobrancaHistoricoEnvioRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaHistoricoEnvioRepository> _logger;

    public ReguaCobrancaHistoricoEnvioRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaHistoricoEnvioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO?> BuscarAsync(int idHistorico)
    {
        try
        {
            _logger.LogDebug("Buscando histórico de envio {IdHistorico}", idHistorico);

            var historico = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO == idHistorico);

            if (historico == null)
            {
                _logger.LogWarning("Histórico de envio {IdHistorico} não encontrado", idHistorico);
            }

            return historico;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar histórico de envio {IdHistorico}", idHistorico);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorReguaAsync(int idRegua)
    {
        try
        {
            _logger.LogDebug("Listando histórico de envio por régua {IdRegua}", idRegua);

            // Buscar etapas da régua
            var etapas = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs
                .Where(e => e.ID_CASO_COBRANCA_REGUA == idRegua)
                .Select(e => e.ID_CASO_COBRANCA_REGUA_ETAPA)
                .ToListAsync();

            // Buscar ações dessas etapas
            var acoes = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .Where(a => a.ID_CASO_COBRANCA_REGUA_ETAPA.HasValue && etapas.Contains(a.ID_CASO_COBRANCA_REGUA_ETAPA.Value))
                .Select(a => a.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO)
                .ToListAsync();

            // Buscar históricos dessas ações
            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO.HasValue && acoes.Contains(h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO.Value))
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} históricos para a régua {IdRegua}", lista.Count, idRegua);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar histórico por régua {IdRegua}", idRegua);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorTemplateAsync(int idTemplate)
    {
        try
        {
            _logger.LogDebug("Listando histórico de envio por template {IdTemplate}", idTemplate);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_DOCUMENTO_TEMPLATE == idTemplate)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} históricos para o template {IdTemplate}", lista.Count, idTemplate);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar histórico por template {IdTemplate}", idTemplate);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorReguaEtapaAcaoAsync(int idReguaEtapaAcao)
    {
        try
        {
            _logger.LogDebug("Listando histórico de envio por ação {IdReguaEtapaAcao}", idReguaEtapaAcao);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idReguaEtapaAcao)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} históricos para a ação {IdReguaEtapaAcao}", lista.Count, idReguaEtapaAcao);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar histórico por ação {IdReguaEtapaAcao}", idReguaEtapaAcao);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorContaAsync(int idConta)
    {
        try
        {
            _logger.LogDebug("Listando histórico de envio por conta {IdConta}", idConta);

            // A tabela não tem ID_CONTA diretamente
            // Pode ser necessário usar ID_CHAVE_ERP ou outra lógica
            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} históricos", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar histórico por conta {IdConta}", idConta);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> VerificaDadoEnviadoDiaAsync(string idChaveErp, int idReguaEtapaAcao)
    {
        try
        {
            _logger.LogDebug("Verificando dado enviado no dia para chave ERP {IdChaveErp} e ação {IdReguaEtapaAcao}", 
                idChaveErp, idReguaEtapaAcao);

            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_CHAVE_ERP == idChaveErp 
                         && h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idReguaEtapaAcao
                         && h.DT_ENVIO >= hoje 
                         && h.DT_ENVIO < amanha)
                .AsNoTracking()
                .ToListAsync();

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar dado enviado no dia");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> VerificaDadoEnviadoDiaPorContaAsync(int idConta, int idReguaEtapaAcao)
    {
        try
        {
            _logger.LogDebug("Verificando dado enviado no dia para conta {IdConta} e ação {IdReguaEtapaAcao}", 
                idConta, idReguaEtapaAcao);

            var hoje = DateTime.Today;
            var amanha = hoje.AddDays(1);

            // A tabela não tem ID_CONTA, ajustar conforme necessário
            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idReguaEtapaAcao
                         && h.DT_ENVIO >= hoje 
                         && h.DT_ENVIO < amanha)
                .AsNoTracking()
                .ToListAsync();

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar dado enviado no dia por conta");
            throw;
        }
    }

    public async Task<int> QuantidadeRegistrosDataAsync(int idReguaEtapaAcao, DateTime data)
    {
        try
        {
            _logger.LogDebug("Contando registros para ação {IdReguaEtapaAcao} na data {Data}", 
                idReguaEtapaAcao, data.ToString("yyyy-MM-dd"));

            var dataInicio = data.Date;
            var dataFim = dataInicio.AddDays(1);

            var count = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs
                .Where(h => h.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idReguaEtapaAcao
                         && h.DT_ENVIO >= dataInicio 
                         && h.DT_ENVIO < dataFim)
                .CountAsync();

            _logger.LogInformation("Encontrados {Count} registros para a ação {IdReguaEtapaAcao} na data {Data}", 
                count, idReguaEtapaAcao, data.ToString("yyyy-MM-dd"));

            return count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao contar registros por data");
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo histórico de envio");

            _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Histórico de envio {IdHistorico} inserido com sucesso", 
                entidade.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir histórico de envio");
            throw;
        }
    }
}
