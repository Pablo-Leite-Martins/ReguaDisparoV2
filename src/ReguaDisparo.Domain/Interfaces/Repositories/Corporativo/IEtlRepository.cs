using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

public interface IEtlRepository
{
    Task<TB_CMCORP_ETL?> BuscarPorOrgAsync(string idOrganizacao);
}
