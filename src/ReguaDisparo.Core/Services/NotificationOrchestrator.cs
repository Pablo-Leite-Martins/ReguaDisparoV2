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
            _logger.LogInformation("Iniciando processamento de todas as empresas");

            await _reguaCobrancaService.ExecutarReguaCobrancaAsync();

            _logger.LogInformation("Processamento de todas as empresas concluído");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar todas as empresas");
            throw;
        }
    }

    public async Task ProcessCompanyAsync(TB_CMCORP_ORGANIZACAO organizacao)
    {
        try
        {
            _logger.LogInformation("Processando empresa {CompanyId}", organizacao.DS_NOME_FANTASIA);

            // Verificar se é dia de semana (lógica pode ser movida para configuração)
            
            if (!DateTime.Now.IsWeekday())
            {
                _logger.LogInformation("Fim de semana detectado para {Company}. Verificando configuração...", organizacao.DS_NOME_FANTASIA);
                // TODO: Verificar configuração de disparo em fim de semana
            }

            _logger.LogInformation("Iniciando processamento de r�guas para {Company}", organizacao.DS_NOME_FANTASIA);

            // Delegar o processamento para o servi�o de r�gua de cobran�a
            await _reguaCobrancaService.ExecutarReguaCobrancaOrganizacaoAsync(organizacao);

            _logger.LogInformation("Processamento concluído para {Company}", organizacao.DS_NOME_FANTASIA);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar empresa {CompanyId}", organizacao.DS_NOME_FANTASIA);
            throw;
        }
    }
}

