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

            // Buscar o ETL completo da tabela
            var etl = await _context.TB_CMCORP_ETLs
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID_ORGANIZACAO == idOrganizacao && e.FL_ETL_ATIVO);

            if (etl is null)
            {
                _logger.LogWarning("ETL não encontrado para organização {IdOrganizacao}", idOrganizacao);
                return null;
            }
            return etl;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ETL por organização {IdOrganizacao}", idOrganizacao);
            throw;
        }
    }
}
