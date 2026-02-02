using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaAcaoRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorReguaEtapaAsync(int idReguaEtapa);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorTipoAcaoAsync(int idTipoAcao);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO?> BuscarAsync(int idAcao);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO entidade);
    Task ExcluirAsync(int idAcao);
}
