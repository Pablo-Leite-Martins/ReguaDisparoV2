using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaEtapaOrdenacaoRepository : IReguaCobrancaEtapaOrdenacaoRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaEtapaOrdenacaoRepository> _logger;

    public ReguaCobrancaEtapaOrdenacaoRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaEtapaOrdenacaoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarAsync()
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarPorEtapaAsync(int idEtapa)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs
            .AsNoTracking()
            .Where(x => x.ID_CASO_COBRANCA_REGUA_ETAPA == idEtapa)
            .OrderBy(x => x.NR_ORDEM)
            .ToListAsync();
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO?> BuscarAsync(int idOrdenacao)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs
            .FindAsync(idOrdenacao);
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO entidade)
    {
        await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO entidade)
    {
        _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int idOrdenacao)
    {
        var entidade = await BuscarAsync(idOrdenacao);
        if (entidade != null)
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
