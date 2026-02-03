using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities;
using ReguaDisparo.Domain.Entities.Corporativo;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

namespace ReguaDisparo.Infrastructure.Repositories.Corporativo;

public class OrganizacaoRepository : IOrganizacaoRepository
{
    private readonly CorporativoDbContext _context;
    private readonly ILogger<OrganizacaoRepository> _logger;

    public OrganizacaoRepository(
        CorporativoDbContext context,
        ILogger<OrganizacaoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todas as organiza��es");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organiza��es", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organiza��es");
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarAtivasAsync()
    {
        try
        {
            _logger.LogDebug("Listando organizações ativas");

            // Alternativa: usar query LINQ em vez da stored procedure para evitar erro de colunas faltantes
            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .Where(o => o.FL_ATIVO == true)
                .AsNoTracking()
                .OrderBy(x => x.DS_NOME_FANTASIA)
                .ToListAsync();

            // Se precisar usar a stored procedure, ela deve retornar TODAS as colunas da entidade
            // incluindo DS_COR_SECUNDARIA_PORTALV2, mesmo que seja NULL

            _logger.LogInformation("Listadas {Count} organizações ativas", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações ativas");
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarPossuemIntegracao_CRM_ERPAsync()
    {
        try
        {
            _logger.LogDebug("Listando organiza��es com integra��o CRM-ERP");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .Where(o => o.FL_CRM_INTEGRADO_ERP == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organiza��es com integra��o CRM-ERP", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organiza��es com integra��o CRM-ERP");
            throw;
        }
    }

    public async Task<TB_CMCORP_ORGANIZACAO?> BuscarAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Buscando organiza��o {IdOrganizacao}", idOrganizacao);

            var organizacao = await _context.TB_CMCORP_ORGANIZACAOs
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == idOrganizacao);

            if (organizacao == null)
            {
                _logger.LogWarning("Organiza��o {IdOrganizacao} n�o encontrada", idOrganizacao);
            }

            return organizacao;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar organiza��o {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListaOrganizacaoUAUCloudAsync()
    {
        try
        {
            _logger.LogDebug("Listando organiza��es UAU Cloud");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .Where(o => o.FL_UAU_CLOUD == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organiza��es UAU Cloud", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organiza��es UAU Cloud");
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);

            _context.TB_CMCORP_ORGANIZACAOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Organiza��o {IdOrganizacao} inserida com sucesso", entidade.ID_ORGANIZACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);

            _context.TB_CMCORP_ORGANIZACAOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Organiza��o {IdOrganizacao} atualizada com sucesso", entidade.ID_ORGANIZACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task AtualizarLayoutAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando layout da organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);

            var organizacao = await _context.TB_CMCORP_ORGANIZACAOs
                .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == entidade.ID_ORGANIZACAO);

            if (organizacao != null)
            {
                organizacao.DS_URL_LOGO = entidade.DS_URL_LOGO;
                organizacao.DS_URL_GALERIA1 = entidade.DS_URL_GALERIA1;
                organizacao.DS_URL_GALERIA2 = entidade.DS_URL_GALERIA2;
                organizacao.DS_URL_GALERIA3 = entidade.DS_URL_GALERIA3;
                organizacao.DS_COR_LOGO = entidade.DS_COR_LOGO;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Layout da organiza��o {IdOrganizacao} atualizado com sucesso", entidade.ID_ORGANIZACAO);
            }
            else
            {
                _logger.LogWarning("Organiza��o {IdOrganizacao} n�o encontrada para atualizar layout", entidade.ID_ORGANIZACAO);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar layout da organiza��o {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task ExcluirAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Excluindo organiza��o {IdOrganizacao}", idOrganizacao);

            var organizacao = await _context.TB_CMCORP_ORGANIZACAOs
                .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == idOrganizacao);

            if (organizacao != null)
            {
                _context.TB_CMCORP_ORGANIZACAOs.Remove(organizacao);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Organiza��o {IdOrganizacao} exclu�da com sucesso", idOrganizacao);
            }
            else
            {
                _logger.LogWarning("Organiza��o {IdOrganizacao} n�o encontrada para exclus�o", idOrganizacao);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir organiza��o {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }
}
