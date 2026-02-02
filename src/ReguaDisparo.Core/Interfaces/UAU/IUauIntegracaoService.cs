namespace ReguaDisparo.Core.Interfaces.UAU;

/// <summary>
/// Interface para serviço de integração com UAU
/// </summary>
public interface IUauIntegracaoService
{
    /// <summary>
    /// Verifica se o PRO_UAU foi executado para uma organização
    /// </summary>
    /// <param name="urlWebserviceCapys">URL do webservice CAPYS da organização</param>
    /// <returns>True se o PRO_UAU foi executado, False caso contrário</returns>
    Task<bool> VerificaProUauExecutouAsync(string urlWebserviceCapys);
}
