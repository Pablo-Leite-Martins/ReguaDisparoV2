using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaAcaoFiltroRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarPorAcaoAsync(int idAcao);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO?> BuscarAsync(int idFiltro);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO entidade);
    Task ExcluirAsync(int idFiltro);
}
