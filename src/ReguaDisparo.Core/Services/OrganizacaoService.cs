using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.Corporativo;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciamento de organizações
/// </summary>
public class OrganizacaoService : IOrganizacaoService
{
    private readonly ILogger<OrganizacaoService> _logger;
    private readonly IOrganizacaoRepository _organizacaoRepository;

    public OrganizacaoService(
        ILogger<OrganizacaoService> logger,
        IOrganizacaoRepository organizacaoRepository)
    {
        _logger = logger;
        _organizacaoRepository = organizacaoRepository;
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarAtivasAsync()
    {
        try
        {
            _logger.LogDebug("Buscando organizações ativas");
            var organizacoes = await _organizacaoRepository.ListarAtivasAsync();
            _logger.LogDebug("Encontradas {Count} organizações ativas", organizacoes.Count);
            return organizacoes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações ativas");
            throw;
        }
    }

    public async Task<TB_CMCORP_ORGANIZACAO?> BuscarAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Buscando organização {IdOrganizacao}", idOrganizacao);
            var organizacao = await _organizacaoRepository.BuscarAsync(idOrganizacao);
            
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

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todas as organizações");
            var organizacoes = await _organizacaoRepository.ListarAsync();
            _logger.LogDebug("Encontradas {Count} organizações", organizacoes.Count);
            return organizacoes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações");
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarPossuemIntegracao_CRM_ERPAsync()
    {
        try
        {
            _logger.LogDebug("Listando organizações com integração CRM/ERP");
            var organizacoes = await _organizacaoRepository.ListarPossuemIntegracao_CRM_ERPAsync();
            _logger.LogDebug("Encontradas {Count} organizações com integração CRM/ERP", organizacoes.Count);
            return organizacoes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações com integração CRM/ERP");
            throw;
        }
    }

    public async Task<List<TB_CMCORP_ORGANIZACAO>> ListaOrganizacaoUAUCloudAsync()
    {
        try
        {
            _logger.LogDebug("Listando organizações UAU Cloud");
            var organizacoes = await _organizacaoRepository.ListaOrganizacaoUAUCloudAsync();
            _logger.LogDebug("Encontradas {Count} organizações UAU Cloud", organizacoes.Count);
            return organizacoes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar organizações UAU Cloud");
            throw;
        }
    }
}
