using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Scheduler;

namespace ReguaDisparo.App;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly NotificationScheduler _scheduler;

    public Worker(ILogger<Worker> logger, NotificationScheduler scheduler)
    {
        _logger = logger;
        _scheduler = scheduler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker iniciado em: {time}", DateTimeOffset.Now);
        
        await _scheduler.ExecuteNowAsync();
        
        _logger.LogInformation("Jobs configurados com sucesso");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
