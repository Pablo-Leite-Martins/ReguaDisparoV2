using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaAcaoAgendamentoRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum>> ListarPorEtapaAcaoAsync(int idEtapaAcao);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum?> BuscarAsync(int idAgenda);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDum entidade);
    Task ExecutarAgendamentoAsync(int idAgenda);
    Task ExcluirAsync(int idAgenda);
}
