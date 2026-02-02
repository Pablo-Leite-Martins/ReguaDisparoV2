using Hangfire;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;

namespace ReguaDisparo.Scheduler;

public class NotificationScheduler
{
    private readonly ILogger<NotificationScheduler> _logger;

    public NotificationScheduler(ILogger<NotificationScheduler> logger)
    {
        _logger = logger;
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

    public void ExecuteNow()
    {
        _logger.LogInformation("Executando job imediatamente");
        BackgroundJob.Enqueue<INotificationOrchestrator>(
            orchestrator => orchestrator.ProcessAllCompaniesAsync());
    }
}
