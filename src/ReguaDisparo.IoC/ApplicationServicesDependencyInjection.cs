using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReguaDisparo.IoC.Modules;

namespace ReguaDisparo.IoC;

public static partial class ApplicationServicesDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Chamar módulo principal que orquestra todos os outros módulos
        services.AddInfrastructureModule(configuration);
        services.AddApplicationModule(configuration);

        return services;
    }
}

