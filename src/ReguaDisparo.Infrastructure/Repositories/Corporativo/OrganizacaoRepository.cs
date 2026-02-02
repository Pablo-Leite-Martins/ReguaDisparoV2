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
            _logger.LogDebug("Listando todas as organizações");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organizações", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações");
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarAtivasAsync()
    {
        try
        {
            _logger.LogDebug("Listando organizações ativas");

            // Usando a procedure do contexto
            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .FromSqlRaw("EXEC CMCORP_sp_ListaOrganizacoesAtivas")
                .AsNoTracking()
                .ToListAsync();

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
            _logger.LogDebug("Listando organizações com integração CRM-ERP");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .Where(o => o.FL_CRM_INTEGRADO_ERP == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organizações com integração CRM-ERP", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações com integração CRM-ERP");
            throw;
        }
    }

    public async Task<TB_CMCORP_ORGANIZACAO?> BuscarAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Buscando organização {IdOrganizacao}", idOrganizacao);

            var organizacao = await _context.TB_CMCORP_ORGANIZACAOs
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == idOrganizacao);

            if (organizacao == null)
            {
                _logger.LogWarning("Organização {IdOrganizacao} não encontrada", idOrganizacao);
            }

            return organizacao;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListaOrganizacaoUAUCloudAsync()
    {
        try
        {
            _logger.LogDebug("Listando organizações UAU Cloud");

            var lista = await _context.TB_CMCORP_ORGANIZACAOs
                .Where(o => o.FL_UAU_CLOUD == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} organizações UAU Cloud", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações UAU Cloud");
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);

            _context.TB_CMCORP_ORGANIZACAOs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Organização {IdOrganizacao} inserida com sucesso", entidade.ID_ORGANIZACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);

            _context.TB_CMCORP_ORGANIZACAOs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Organização {IdOrganizacao} atualizada com sucesso", entidade.ID_ORGANIZACAO);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task AtualizarLayoutAsync(TB_CMCORP_ORGANIZACAO entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando layout da organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);

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

                _logger.LogInformation("Layout da organização {IdOrganizacao} atualizado com sucesso", entidade.ID_ORGANIZACAO);
            }
            else
            {
                _logger.LogWarning("Organização {IdOrganizacao} não encontrada para atualizar layout", entidade.ID_ORGANIZACAO);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar layout da organização {IdOrganizacao}", entidade.ID_ORGANIZACAO);
            throw;
        }
    }

    public async Task ExcluirAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Excluindo organização {IdOrganizacao}", idOrganizacao);

            var organizacao = await _context.TB_CMCORP_ORGANIZACAOs
                .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == idOrganizacao);

            if (organizacao != null)
            {
                _context.TB_CMCORP_ORGANIZACAOs.Remove(organizacao);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Organização {IdOrganizacao} excluída com sucesso", idOrganizacao);
            }
            else
            {
                _logger.LogWarning("Organização {IdOrganizacao} não encontrada para exclusão", idOrganizacao);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }
}
