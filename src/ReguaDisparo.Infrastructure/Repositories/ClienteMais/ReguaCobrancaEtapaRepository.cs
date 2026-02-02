using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaEtapaRepository : IReguaCobrancaEtapaRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaEtapaRepository> _logger;

    public ReguaCobrancaEtapaRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaEtapaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarAsync()
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarPorReguaAsync(int idRegua)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs
            .AsNoTracking()
            .Where(x => x.ID_CASO_COBRANCA_REGUA == idRegua)
            .OrderBy(x => x.NR_ETAPA)
            .ToListAsync();
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA?> BuscarAsync(int idEtapa)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs
            .FindAsync(idEtapa);
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade)
    {
        await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade)
    {
        _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int idEtapa)
    {
        var entidade = await BuscarAsync(idEtapa);
        if (entidade != null)
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
