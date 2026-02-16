using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaAcaoAgendamentoRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarPorEtapaAcaoAsync(int idEtapaAcao);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA?> BuscarAsync(int idAgenda);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade);
    Task ExecutarAgendamentoAsync(int idAgenda);
    Task ExcluirAsync(int idAgenda);
}
