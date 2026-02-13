using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Core.Services;

namespace ReguaDisparo.Scheduler;

public class NotificationScheduler
{
    private readonly ILogger<NotificationScheduler> _logger;
    private readonly IServiceProvider _serviceProvider;

    public NotificationScheduler(
        ILogger<NotificationScheduler> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public void ConfigureJobs()
    {
        _logger.LogInformation("Configurando jobs do Hangfire");

        RecurringJob.AddOrUpdate<INotificationOrchestrator>(
            "daily-notifications",
            orchestrator => orchestrator.ProcessAllCompaniesAsync(),
            "0 8 * * *",
            new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
            });

        _logger.LogInformation("Jobs configurados com sucesso");
    }

    public async Task ExecuteNowAsync(bool useHangfire = false)
    {
        _logger.LogInformation("Executando job imediatamente");
        
        if (useHangfire)
        {
            ConfigureJobs();
        }
        else
        {
            // Executa diretamente para permitir debug
            using var scope = _serviceProvider.CreateScope();
            var orchestrator = scope.ServiceProvider.GetRequiredService<INotificationOrchestrator>();
            await orchestrator.ProcessAllCompaniesAsync();
        }
    }
}
