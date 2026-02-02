using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaHistoricoEnvioRepository
{
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO?> BuscarAsync(int idHistorico);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorReguaAsync(int idRegua);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorTemplateAsync(int idTemplate);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorReguaEtapaAcaoAsync(int idReguaEtapaAcao);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorContaAsync(int idConta);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> VerificaDadoEnviadoDiaAsync(string idChaveErp, int idReguaEtapaAcao);
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> VerificaDadoEnviadoDiaPorContaAsync(int idConta, int idReguaEtapaAcao);
    Task<int> QuantidadeRegistrosDataAsync(int idReguaEtapaAcao, DateTime data);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO entidade);
}
