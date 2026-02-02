using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.Corporativo;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;

namespace ReguaDisparo.Infrastructure.Repositories.Corporativo;

public class EtlRepository : IEtlRepository
{
    private readonly CorporativoDbContext _context;
    private readonly ILogger<EtlRepository> _logger;

    public EtlRepository(
        CorporativoDbContext context,
        ILogger<EtlRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TB_CMCORP_ETL?> BuscarPorOrgAsync(string idOrganizacao)
    {
        try
        {
            _logger.LogDebug("Buscando ETL por organização {IdOrganizacao}", idOrganizacao);

            // Usando a procedure customizada do contexto
            var etls = await _context.CMCORP_sp_BuscaEtlPorOrganizacao_Results
                .FromSqlRaw("EXEC CMCORP_sp_BuscaEtlPorOrganizacao @ID_ORGANIZACAO", 
                    new Microsoft.Data.SqlClient.SqlParameter("@ID_ORGANIZACAO", idOrganizacao))
                .ToListAsync();

            if (etls.Count == 0)
            {
                _logger.LogWarning("ETL não encontrado para organização {IdOrganizacao}", idOrganizacao);
                return null;
            }

            // Buscar o ETL completo da tabela
            var etl = await _context.TB_CMCORP_ETLs
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID_ETL == etls[0].ID_ETL);

            return etl;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ETL por organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }
}
