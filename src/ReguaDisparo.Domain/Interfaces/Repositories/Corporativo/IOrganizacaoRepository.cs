using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

public interface IOrganizacaoRepository
{
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarAsync();
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarAtivasAsync();
    Task<List<TB_CMCORP_ORGANIZACAO>> ListarPossuemIntegracao_CRM_ERPAsync();
    Task<TB_CMCORP_ORGANIZACAO?> BuscarAsync(string idOrganizacao);
    Task<List<TB_CMCORP_ORGANIZACAO>> ListaOrganizacaoUAUCloudAsync();
    Task InserirAsync(TB_CMCORP_ORGANIZACAO entidade);
    Task AtualizarAsync(TB_CMCORP_ORGANIZACAO entidade);
    Task AtualizarLayoutAsync(TB_CMCORP_ORGANIZACAO entidade);
    Task ExcluirAsync(string idOrganizacao);
}
