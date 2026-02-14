using Microsoft.Extensions.Logging;
using ReguaDisparo.Common.Extensions;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Orquestrador principal para processamento de notifica��es de r�gua de cobran�a
/// </summary>
public class NotificationOrchestrator : INotificationOrchestrator
{
    private readonly ILogger<NotificationOrchestrator> _logger;
    private readonly IOrganizacaoService _organizacaoService;
    private readonly IReguaCobrancaService _reguaCobrancaService;

    public NotificationOrchestrator(
        ILogger<NotificationOrchestrator> logger,
        IOrganizacaoService organizacaoService,
        IReguaCobrancaService reguaCobrancaService)
    {
        _logger = logger;
        _organizacaoService = organizacaoService;
        _reguaCobrancaService = reguaCobrancaService;
    }

    public async Task ProcessAllCompaniesAsync()
    {
        try
        {
            _logger.LogInformation("Iniciando execução da Régua de Cobrança para todas as organizações");

            await _reguaCobrancaService.ExecutarReguaCobrancaAsync();

            _logger.LogInformation("Execução de todas as empresas concluído");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar todas as empresas");
            throw;
        }
    }
}

