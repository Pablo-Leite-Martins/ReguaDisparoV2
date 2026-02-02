using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaEtapaAcaoFiltroRepository : IReguaCobrancaEtapaAcaoFiltroRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaEtapaAcaoFiltroRepository> _logger;

    public ReguaCobrancaEtapaAcaoFiltroRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaEtapaAcaoFiltroRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarAsync()
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarPorAcaoAsync(int idAcao)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs
            .AsNoTracking()
            .Where(x => x.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idAcao)
            .ToListAsync();
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO?> BuscarAsync(int idFiltro)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs
            .FindAsync(idFiltro);
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO entidade)
    {
        await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO entidade)
    {
        _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int idFiltro)
    {
        var entidade = await BuscarAsync(idFiltro);
        if (entidade != null)
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTROs.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
