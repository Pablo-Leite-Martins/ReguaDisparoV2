using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IReguaCobrancaRepository
{
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA>> ListarAsync();
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA>> ListarReguasAtivasAsync();
    Task<TB_CMCRM_CASO_COBRANCA_REGUA?> BuscarAsync(int idRegua);
    Task<int> InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA entidade);
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA entidade);
    Task ExcluirAsync(int idRegua);
    Task RemoveAdimplenciaDasFilasAsync();
}
