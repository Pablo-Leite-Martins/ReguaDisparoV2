using Hangfire;
using Hangfire.SqlServer;
using ReguaDisparo.App;
using ReguaDisparo.IoC;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Iniciando ReguaDisparo Worker Service");
    var builder = Host.CreateApplicationBuilder(args);
    builder.Services.AddSerilog();
    builder.Services.AddApplicationServices(builder.Configuration);
    builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions { CommandBatchMaxTimeout = TimeSpan.FromMinutes(5), SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5), QueuePollInterval = TimeSpan.Zero, UseRecommendedIsolationLevel = true, DisableGlobalLocks = true }));
    builder.Services.AddHangfireServer();
    builder.Services.AddHostedService<Worker>();
    var host = builder.Build();
    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Aplicação encerrada inesperadamente");
}
finally
{
    Log.CloseAndFlush();
}
