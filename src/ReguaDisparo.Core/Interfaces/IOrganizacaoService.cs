using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de gerenciamento de organizações
/// </summary>
public interface IOrganizacaoService
{
    /// <summary>
    /// Lista todas as organizações ativas do sistema
    /// </summary>
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarAtivasAsync();

    /// <summary>
    /// Busca uma organização específica por ID
    /// </summary>
    Task<TB_CMCORP_ORGANIZACAO?> BuscarAsync(string idOrganizacao);

    /// <summary>
    /// Lista todas as organizações
    /// </summary>
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarAsync();

    /// <summary>
    /// Lista organizações que possuem integração CRM/ERP
    /// </summary>
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarPossuemIntegracao_CRM_ERPAsync();

    /// <summary>
    /// Lista organizações UAU Cloud
    /// </summary>
    Task<List<TB_CMCORP_ORGANIZACAO>> ListaOrganizacaoUAUCloudAsync();
}
