using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ControleAcesso;
using ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

namespace ReguaDisparo.Infrastructure.Repositories.ControleAcesso;

public class GrupoRepository : IGrupoRepository
{
    private readonly ControleAcessoDbContext _context;
    private readonly ILogger<GrupoRepository> _logger;

    public GrupoRepository(
        ControleAcessoDbContext context,
        ILogger<GrupoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMC_GRUPO>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todos os grupos");

            var lista = await _context.TB_CMC_GRUPOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} grupos", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar grupos");
            throw;
        }
    }

    public async Task<List<TB_CMC_GRUPO>> ListarAtivosPorOrganizacaoAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Listando grupos ativos da organização {IdOrganizacao}", idOrganizacao);

            var lista = await _context.TB_CMC_GRUPOs
                .Where(g => g.ID_ORGANIZACAO == idOrganizacao && g.FL_ATIVO == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listados {Count} grupos ativos para organização {IdOrganizacao}", 
                lista.Count, idOrganizacao);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar grupos ativos por organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }

    public async Task<TB_CMC_GRUPO?> BuscarAsync(int idGrupo)
    {
        try
        {
            _logger.LogDebug("Buscando grupo {IdGrupo}", idGrupo);

            var grupo = await _context.TB_CMC_GRUPOs
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.ID_GRUPO == idGrupo);

            if (grupo == null)
            {
                _logger.LogWarning("Grupo {IdGrupo} não encontrado", idGrupo);
            }

            return grupo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar grupo {IdGrupo}", idGrupo);
            throw;
        }
    }

    public async Task<List<TB_CMC_GRUPO_USUARIO>> ListarUsuariosDoGrupoAsync(int idGrupo)
    {
        try
        {
            _logger.LogDebug("Listando usuários do grupo {IdGrupo}", idGrupo);

            var lista = await _context.TB_CMC_GRUPO_USUARIOs
                .Where(gu => gu.ID_GRUPO == idGrupo)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Grupo {IdGrupo} possui {Count} usuários", idGrupo, lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar usuários do grupo {IdGrupo}", idGrupo);
            throw;
        }
    }

    public async Task<List<TB_CMC_GRUPO_FUNCAO>> ListarFuncoesDoGrupoAsync(int idGrupo)
    {
        try
        {
            _logger.LogDebug("Listando funções do grupo {IdGrupo}", idGrupo);

            var lista = await _context.TB_CMC_GRUPO_FUNCAOs
                .Where(gf => gf.ID_GRUPO == idGrupo)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Grupo {IdGrupo} possui {Count} funções", idGrupo, lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar funções do grupo {IdGrupo}", idGrupo);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMC_GRUPO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo grupo {NomeGrupo}", entidade.DS_GRUPO);

            _context.TB_CMC_GRUPOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Grupo {IdGrupo} - {NomeGrupo} inserido com sucesso", 
                entidade.ID_GRUPO, entidade.DS_GRUPO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir grupo {NomeGrupo}", entidade.DS_GRUPO);
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMC_GRUPO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando grupo {IdGrupo}", entidade.ID_GRUPO);

            _context.TB_CMC_GRUPOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Grupo {IdGrupo} atualizado com sucesso", entidade.ID_GRUPO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar grupo {IdGrupo}", entidade.ID_GRUPO);
            throw;
        }
    }

    public async Task ExcluirAsync(int idGrupo)
    {
        try
        {
            _logger.LogDebug("Excluindo grupo {IdGrupo}", idGrupo);

            var grupo = await _context.TB_CMC_GRUPOs
                .FirstOrDefaultAsync(g => g.ID_GRUPO == idGrupo);

            if (grupo != null)
            {
                _context.TB_CMC_GRUPOs.Remove(grupo);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Grupo {IdGrupo} excluído com sucesso", idGrupo);
            }
            else
            {
                _logger.LogWarning("Grupo {IdGrupo} não encontrado para exclusão", idGrupo);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir grupo {IdGrupo}", idGrupo);
            throw;
        }
    }
}
