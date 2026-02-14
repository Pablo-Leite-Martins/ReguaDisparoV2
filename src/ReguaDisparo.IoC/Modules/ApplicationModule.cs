using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Core.Interfaces.UAU;
using ReguaDisparo.Core.Services;
using ReguaDisparo.Core.Services.UAU;
using ReguaDisparo.Infrastructure.Services;
using ReguaDisparo.IoC.Modules;

namespace ReguaDisparo.IoC
{
    public static partial class ApplicationServicesDependencyInjection
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguration(configuration);

            // Infraestrutura (EF Core, Repositories, Services)
            services.AddInfrastructureModule(configuration);

            // Serviços de Aplicação
            services.AddServices();
            services.AddEmailSettings(configuration);

            // Core (Use Cases)
            services.AddOrchestrators();
        }
        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurações
            services.Configure<EmailSettings>(configuration.GetSection("Email"));
            services.Configure<EmailSettings>(options =>
            {
                var sendGridSection = configuration.GetSection("SendGrid");
                var smtpSection = configuration.GetSection("Smtp");

                options.SendGridApiKey = sendGridSection["ApiKey"] ?? string.Empty;
                options.SmtpHost = smtpSection["Host"] ?? string.Empty;
                options.SmtpPort = int.Parse(smtpSection["Port"] ?? "587");
                options.SmtpUser = smtpSection["User"] ?? string.Empty;
                options.SmtpPassword = smtpSection["Password"] ?? string.Empty;
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<Scheduler.NotificationScheduler>();
            
            // Serviços de domínio
            services.AddScoped<IOrganizacaoService, OrganizacaoService>();
            services.AddScoped<IConfigGeralService, ConfigGeralService>();
            services.AddScoped<IEtlService, EtlService>();
            
            // Serviços de integração
            services.AddScoped<IUauIntegracaoService, UauIntegracaoService>();
            
            // Serviços de régua de cobrança
            services.AddScoped<IReguaCobrancaService, ReguaCobrancaService>();
            services.AddScoped<IReguaFiltroService, ReguaFiltroService>();
            services.AddScoped<IComunicacaoService, ComunicacaoService>();
            
            // Serviços de comunicação
            services.AddScoped<ISmsService, TwilioSmsService>();
            services.AddScoped<IWhatsAppService, TwilioWhatsAppService>();
        }

        public static void AddOrchestrators(this IServiceCollection services)
        {
            services.AddScoped<INotificationOrchestrator, NotificationOrchestrator>();
        }
        public static void AddEmailSettings(this IServiceCollection services, IConfiguration configuration)
        {

            // Infrastructure Services - Email
            var useSendGrid = configuration.GetValue<bool>("Email:UseSendGrid");
            if (useSendGrid)
            {
                services.AddScoped<IEmailService, SendGridEmailService>();
            }
            else
            {
                services.AddScoped<IEmailService, SmtpEmailService>();
            }
        }
    }
}

