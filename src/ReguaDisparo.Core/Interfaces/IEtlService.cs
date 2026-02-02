using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de ETL
/// </summary>
public interface IEtlService
{
    /// <summary>
    /// Busca informações de ETL por organização
    /// </summary>
    Task<TB_CMCORP_ETL?> BuscarPorOrganizacaoAsync(string idOrganizacao);

    /// <summary>
    /// Verifica se o ETL foi executado hoje para uma organização
    /// </summary>
    Task<bool> EtlExecutadoHojeAsync(string idOrganizacao);
}
