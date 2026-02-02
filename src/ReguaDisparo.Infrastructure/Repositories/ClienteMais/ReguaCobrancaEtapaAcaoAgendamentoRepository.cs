using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ReguaCobrancaEtapaAcaoAgendamentoRepository : IReguaCobrancaEtapaAcaoAgendamentoRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaEtapaAcaoAgendamentoRepository> _logger;

    public ReguaCobrancaEtapaAcaoAgendamentoRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaEtapaAcaoAgendamentoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum>> ListarAsync()
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum>> ListarPorEtapaAcaoAsync(int idEtapaAcao)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs
            .AsNoTracking()
            .Where(x => x.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO == idEtapaAcao && !x.FL_ENVIADO)
            .ToListAsync();
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum?> BuscarAsync(int idAgenda)
    {
        return await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs
            .FindAsync(idAgenda);
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum entidade)
    {
        await _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs.AddAsync(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum entidade)
    {
        _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExecutarAgendamentoAsync(int idAgenda)
    {
        var entidade = await BuscarAsync(idAgenda);
        if (entidade != null)
        {
            entidade.FL_ENVIADO = true;
            entidade.DT_ENVIO = DateTime.Now;
            await AtualizarAsync(entidade);
        }
    }

    public async Task ExcluirAsync(int idAgenda)
    {
        var entidade = await BuscarAsync(idAgenda);
        if (entidade != null)
        {
            _context.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDAs.Remove(entidade);
            await _context.SaveChangesAsync();
        }
    }
}
