using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaConfigRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG>> ListarAsync();
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarPorReguaAsync(int idRegua);
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarAsync(int idConfig);
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade);
    Task ExcluirAsync(int idConfig);
}
