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
}
