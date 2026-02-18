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
            _logger.LogDebug("Listando todas as a��es de etapa de r�gua");

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} a��es de etapa de r�gua", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar a��es de etapa de r�gua");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorReguaEtapaAsync(int idReguaEtapa)
    {
        try
        {
            _logger.LogDebug("Listando a��es por etapa {IdReguaEtapa}", idReguaEtapa);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .Include(a => a.ID_TIPO_ACAONavigation)
                .Where(a => a.ID_CASO_COBRANCA_REGUA_ETAPA == idReguaEtapa)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} a��es para a etapa {IdReguaEtapa}", lista.Count, idReguaEtapa);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar a��es por etapa {IdReguaEtapa}", idReguaEtapa);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorTipoAcaoAsync(int idTipoAcao)
    {
        try
        {
            _logger.LogDebug("Listando a��es por tipo {IdTipoAcao}", idTipoAcao);

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .Where(a => a.ID_TIPO_ACAO == idTipoAcao)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} a��es do tipo {IdTipoAcao}", lista.Count, idTipoAcao);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar a��es por tipo {IdTipoAcao}", idTipoAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO?> BuscarAsync(int idAcao)
    {
        try
        {
            _logger.LogDebug("Buscando a��o {IdAcao}", idAcao);

            var acao = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao);

            if (acao == null)
            {
                _logger.LogWarning("A��o {IdAcao} n�o encontrada", idAcao);
            }

            return acao;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar a��o {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo a��o de etapa de r�gua");

            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("A��o {IdAcao} inserida com sucesso", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir a��o de etapa de r�gua");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando a��o {IdAcao}", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);

            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("A��o {IdAcao} atualizada com sucesso", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar a��o {IdAcao}", entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
            throw;
        }
    }

    public async Task ExcluirAsync(int idAcao)
    {
        try
        {
            _logger.LogDebug("Excluindo a��o {IdAcao}", idAcao);

            var acao = await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs
                .FirstOrDefaultAsync(a => a.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao);

            if (acao != null)
            {
                _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs.Remove(acao);
                await _context.SaveChangesAsync();

                _logger.LogInformation("A��o {IdAcao} exclu�da com sucesso", idAcao);
            }
            else
            {
                _logger.LogWarning("A��o {IdAcao} n�o encontrada para exclus�o", idAcao);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir a��o {IdAcao}", idAcao);
            throw;
        }
    }
}
