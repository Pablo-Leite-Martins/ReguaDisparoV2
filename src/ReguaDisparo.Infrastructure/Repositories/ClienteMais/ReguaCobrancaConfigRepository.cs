using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaConfigRepository : IReguaCobrancaConfigRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaConfigRepository> _logger;

    public ReguaCobrancaConfigRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaConfigRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG>> ListarAsync()
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarPorReguaAsync(int idRegua)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID_CASO_COBRANCA_REGUA == idRegua);
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarAsync(int idConfig)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs
            .FindAsync(idConfig);
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade)
    {
        await _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade)
    {
        _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int idConfig)
    {
        var entidade = await BuscarAsync(idConfig);
        if (entidade != null)
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
