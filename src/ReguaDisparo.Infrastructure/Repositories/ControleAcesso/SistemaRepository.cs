using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ControleAcesso;
using ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

namespace ReguaDisparo.Infrastructure.Repositories.ControleAcesso;

public class SistemaRepository : ISistemaRepository
{
    private readonly ControleAcessoDbContext _context;
    private readonly ILogger<SistemaRepository> _logger;

    public SistemaRepository(
        ControleAcessoDbContext context,
        ILogger<SistemaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMC_SISTEMA>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todos os sistemas");

            var lista = await _context.TB_CMC_SISTEMAs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} sistemas", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar sistemas");
            throw;
        }
    }

    public async Task<List<TB_CMC_SISTEMA>> ListarAtivosAsync()
    {
        try
        {
            _logger.LogDebug("Listando sistemas ativos");

            // TB_CMC_SISTEMA não possui FL_ATIVO, retorna todos
            var lista = await _context.TB_CMC_SISTEMAs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} sistemas", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar sistemas ativos");
            throw;
        }
    }

    public async Task<TB_CMC_SISTEMA?> BuscarAsync(int idSistema)
    {
        try
        {
            _logger.LogDebug("Buscando sistema {IdSistema}", idSistema);

            var sistema = await _context.TB_CMC_SISTEMAs
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID_SISTEMA == idSistema);

            if (sistema == null)
            {
                _logger.LogWarning("Sistema {IdSistema} não encontrado", idSistema);
            }

            return sistema;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar sistema {IdSistema}", idSistema);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMC_SISTEMA entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo sistema {NomeSistema}", entidade.DS_NOME_SISTEMA);

            _context.TB_CMC_SISTEMAs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Sistema {IdSistema} - {NomeSistema} inserido com sucesso", 
                entidade.ID_SISTEMA, entidade.DS_NOME_SISTEMA);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir sistema {NomeSistema}", entidade.DS_NOME_SISTEMA);
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMC_SISTEMA entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando sistema {IdSistema}", entidade.ID_SISTEMA);

            _context.TB_CMC_SISTEMAs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Sistema {IdSistema} atualizado com sucesso", entidade.ID_SISTEMA);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar sistema {IdSistema}", entidade.ID_SISTEMA);
            throw;
        }
    }

    public async Task ExcluirAsync(int idSistema)
    {
        try
        {
            _logger.LogDebug("Excluindo sistema {IdSistema}", idSistema);

            var sistema = await _context.TB_CMC_SISTEMAs
                .FirstOrDefaultAsync(s => s.ID_SISTEMA == idSistema);

            if (sistema != null)
            {
                _context.TB_CMC_SISTEMAs.Remove(sistema);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Sistema {IdSistema} excluído com sucesso", idSistema);
            }
            else
            {
                _logger.LogWarning("Sistema {IdSistema} não encontrado para exclusão", idSistema);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir sistema {IdSistema}", idSistema);
            throw;
        }
    }
}
