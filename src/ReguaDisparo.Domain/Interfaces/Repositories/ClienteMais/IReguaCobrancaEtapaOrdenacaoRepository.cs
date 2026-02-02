using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaOrdenacaoRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarPorEtapaAsync(int idEtapa);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO?> BuscarAsync(int idOrdenacao);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO entidade);
    Task ExcluirAsync(int idOrdenacao);
}
