using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para orquestração do processamento de notificações
/// </summary>
public interface INotificationOrchestrator
{
    /// <summary>
    /// Processa notificações para todas as empresas ativas
    /// </summary>
    Task ProcessAllCompaniesAsync();

    /// <summary>
    /// Processa notificações para uma empresa específica
    /// </summary>
    Task ProcessCompanyAsync(TB_CMCORP_ORGANIZACAO organizacao);
}
