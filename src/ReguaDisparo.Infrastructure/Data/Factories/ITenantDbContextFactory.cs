namespace ReguaDisparo.Infrastructure.Data.Factories;

/// <summary>
/// Factory para criar DbContext do cliente (multi-tenant) baseado na organização
/// </summary>
public interface ITenantDbContextFactory
{
    /// <summary>
    /// Cria um ClienteMaisDbContext para a organização especificada
    /// </summary>
    /// <param name="organizationId">ID da organização</param>
    /// <returns>ClienteMaisDbContext configurado para o banco da organização</returns>
    Task<ClienteMaisDbContext> CreateDbContextAsync(string organizationId);

    /// <summary>
    /// Cria um ClienteMaisDbContext usando o nome do banco diretamente
    /// </summary>
    /// <param name="databaseName">Nome do banco de dados</param>
    /// <returns>ClienteMaisDbContext configurado para o banco especificado</returns>
    ClienteMaisDbContext CreateDbContextByDatabaseName(string databaseName);
}
