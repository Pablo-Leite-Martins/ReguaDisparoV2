using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaEtapaRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarPorReguaAsync(int idRegua);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA?> BuscarAsync(int idEtapa);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade);
    Task ExcluirAsync(int idEtapa);
}
