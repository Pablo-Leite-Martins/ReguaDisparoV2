using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

/// <summary>
/// Repositório para histórico de não envios da régua de cobrança
/// </summary>
public class ReguaCobrancaHistoricoNaoEnvioRepository : IReguaCobrancaHistoricoNaoEnvioRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaHistoricoNaoEnvioRepository> _logger;

    public ReguaCobrancaHistoricoNaoEnvioRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaHistoricoNaoEnvioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarAsync()
    {
        try
        {
            return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs
                .AsNoTracking()
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de não envio");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarPorAcaoAsync(int idAcao)
    {
        try
        {
            return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs
                .AsNoTracking()
                .Where(x => x.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao)
                .OrderByDescending(x => x.DT_ENVIO)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de não envio para ação {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO?> BuscarAsync(int id)
    {
        try
        {
            return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs
                .FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar histórico de não envio {Id}", id);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade)
    {
        try
        {
            await _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs.AddAsync(entidade);
            await _context.SaveChangesAsync();

            _logger.LogDebug("Histórico de não envio inserido com sucesso: {Id}", entidade.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir histórico de não envio");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade)
    {
        try
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogDebug("Histórico de não envio atualizado com sucesso: {Id}", entidade.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar histórico de não envio {Id}", entidade.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
            throw;
        }
    }

    public async Task ExcluirAsync(int id)
    {
        try
        {
            var entidade = await BuscarAsync(id);
            if (entidade != null)
            {
                _context.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs.Remove(entidade);
                await _context.SaveChangesAsync();

                _logger.LogDebug("Histórico de não envio excluído com sucesso: {Id}", id);
            }
            else
            {
                _logger.LogWarning("Histórico de não envio {Id} não encontrado para exclusão", id);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir histórico de não envio {Id}", id);
            throw;
        }
    }
}
