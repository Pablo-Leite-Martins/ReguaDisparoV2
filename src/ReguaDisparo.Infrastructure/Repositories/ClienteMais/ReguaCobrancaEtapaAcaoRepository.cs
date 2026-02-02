using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaEtapaAcaoRepository : IReguaCobrancaEtapaAcaoRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaEtapaAcaoRepository> _logger;

    public ReguaCobrancaEtapaAcaoRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaEtapaAcaoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todas as ações de etapa de régua");

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} ações de etapa de régua", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações de etapa de régua");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorReguaEtapaAsync(int idReguaEtapa)
    {
        try
        {
            _logger.LogDebug("Listando ações por etapa {IdReguaEtapa}", idReguaEtapa);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .Where(a => a.ID_CASO_COBRANCA_REGUA_ETAPA == idReguaEtapa)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} ações para a etapa {IdReguaEtapa}", lista.Count, idReguaEtapa);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações por etapa {IdReguaEtapa}", idReguaEtapa);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorTipoAcaoAsync(int idTipoAcao)
    {
        try
        {
            _logger.LogDebug("Listando ações por tipo {IdTipoAcao}", idTipoAcao);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .Where(a => a.ID_TIPO_ACAO == idTipoAcao)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} ações do tipo {IdTipoAcao}", lista.Count, idTipoAcao);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações por tipo {IdTipoAcao}", idTipoAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO?> BuscarAsync(int idAcao)
    {
        try
        {
            _logger.LogDebug("Buscando ação {IdAcao}", idAcao);

            var acao = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao);

            if (acao == null)
            {
                _logger.LogWarning("Ação {IdAcao} não encontrada", idAcao);
            }

            return acao;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ação {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo ação de etapa de régua");

            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Ação {IdAcao} inserida com sucesso", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir ação de etapa de régua");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando ação {IdAcao}", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);

            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Ação {IdAcao} atualizada com sucesso", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar ação {IdAcao}", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
            throw;
        }
    }

    public async Task ExcluirAsync(int idAcao)
    {
        try
        {
            _logger.LogDebug("Excluindo ação {IdAcao}", idAcao);

            var acao = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .FirstOrDefaultAsync(a => a.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao);

            if (acao != null)
            {
                _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Remove(acao);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ação {IdAcao} excluída com sucesso", idAcao);
            }
            else
            {
                _logger.LogWarning("Ação {IdAcao} não encontrada para exclusão", idAcao);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir ação {IdAcao}", idAcao);
            throw;
        }
    }
}
