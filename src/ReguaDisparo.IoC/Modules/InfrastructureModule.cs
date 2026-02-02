using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.Corporativo;
using ReguaDisparo.Infrastructure.Repositories.ControleAcesso;
using ReguaDisparo.Infrastructure.Services;
using ReguaDisparo.Infrastructure;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;
using ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

namespace ReguaDisparo.IoC.Modules
{
    public static class InfrastructureModule
    {
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration) 
        {
            // DbContexts
            services.AddDbContexts(configuration);

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

            // Repositories
            services.AddRepositories();
        }

        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            // ControleAcessoDbContext (CLIENTEMAIS_CONTROLE_ACESSO - Fixo)
            services.AddDbContext<ControleAcessoDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("ControleAcessoConnection");
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout(30);
                });

                #if DEBUG
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                #endif
            });

            // CorporativoDbContext (CLIENTEMAIS_CORPORATIVO - Fixo)
            services.AddDbContext<CorporativoDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("CorporativoConnection");
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout(30);
                });

                #if DEBUG
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
                #endif
            });

            // ClienteMaisDbContext (Multi-tenant - Dinâmico via Factory)
            // NÃO registrar diretamente - usar ITenantDbContextFactory
            services.AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            // Corporativo
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IEtlRepository, EtlRepository>();

            // Controle de Acesso
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<ISistemaRepository, SistemaRepository>();

            // ClienteMais (Multi-Tenant) - NÃO registrar no DI
            // Criar via TenantDbContextFactory conforme necessário:
            // using var crmDb = await _tenantFactory.CreateDbContextAsync(orgId);
            // var repo = new ConfigGeralRepository(crmDb, logger);
        }
    }
}


