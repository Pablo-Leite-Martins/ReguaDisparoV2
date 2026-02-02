using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ReguaDisparo.Infrastructure.Data.Factories;

/// <summary>
/// Factory para criar DbContext do cliente (multi-tenant) baseado na organização
/// </summary>
public class TenantDbContextFactory : ITenantDbContextFactory
{
    private readonly CorporativoDbContext _corporativoDb;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TenantDbContextFactory> _logger;

    public TenantDbContextFactory(
        CorporativoDbContext corporativoDb,
        IConfiguration configuration,
        ILogger<TenantDbContextFactory> logger)
    {
        _corporativoDb = corporativoDb;
        _configuration = configuration;
        _logger = logger;
    }

    /// <summary>
    /// Cria um ClienteMaisDbContext para a organização especificada
    /// </summary>
    public async Task<ClienteMaisDbContext> CreateDbContextAsync(string organizationId)
    {
        _logger.LogInformation("Criando DbContext para organização {OrganizationId}", organizationId);

        // Buscar organização no banco Corporativo
        var organizacao = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
            .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == organizationId && o.FL_ATIVO);

        if (organizacao == null)
        {
            _logger.LogError("Organização {OrganizationId} não encontrada", organizationId);
            throw new InvalidOperationException($"Organização '{organizationId}' não encontrada");
        }

        if (string.IsNullOrWhiteSpace(organizacao.NOME_BANCO_CRM))
        {
            _logger.LogError("Organização {OrganizationId} não possui NOME_BANCO_CRM configurado", organizationId);
            throw new InvalidOperationException($"Organização '{organizationId}' não possui banco CRM configurado");
        }

        _logger.LogInformation("Banco CRM da organização {OrganizationId}: {DatabaseName}", 
            organizationId, organizacao.NOME_BANCO_CRM);

        return CreateDbContextByDatabaseName(organizacao.NOME_BANCO_CRM);
    }

    /// <summary>
    /// Cria um ClienteMaisDbContext usando o nome do banco diretamente
    /// </summary>
    public ClienteMaisDbContext CreateDbContextByDatabaseName(string databaseName)
    {
        _logger.LogDebug("Criando DbContext para banco {DatabaseName}", databaseName);

        // Obter template de connection string
        var connectionStringTemplate = _configuration.GetConnectionString("ClienteMaisConnection");
        
        if (string.IsNullOrWhiteSpace(connectionStringTemplate))
        {
            throw new InvalidOperationException("Connection string 'ClienteMaisConnection' não configurada");
        }

        // Substituir o Initial Catalog pelo nome do banco da organização
        var connectionString = ReplaceInitialCatalog(connectionStringTemplate, databaseName);

        _logger.LogDebug("Connection string criada para {DatabaseName}", databaseName);

        // Criar options com a connection string específica
        var optionsBuilder = new DbContextOptionsBuilder<ClienteMaisDbContext>();
        optionsBuilder.UseSqlServer(connectionString, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
            sqlOptions.CommandTimeout(30);
        });

        #if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
        #endif

        return new ClienteMaisDbContext(optionsBuilder.Options);
    }

    /// <summary>
    /// Substitui o Initial Catalog na connection string
    /// </summary>
    private string ReplaceInitialCatalog(string connectionString, string nomeBanco)
    {
        // Regex para substituir Initial Catalog ou Database
        var patterns = new[]
        {
            @"Initial Catalog=[^;]+",
            @"Database=[^;]+"
        };

        foreach (var pattern in patterns)
        {
            var regex = new System.Text.RegularExpressions.Regex(pattern, 
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            
            if (regex.IsMatch(connectionString))
            {
                return regex.Replace(connectionString, $"Initial Catalog={nomeBanco}");
            }
        }

        // Se não encontrou, adiciona no final
        return connectionString.TrimEnd(';') + $";Initial Catalog={nomeBanco}";
    }
}
