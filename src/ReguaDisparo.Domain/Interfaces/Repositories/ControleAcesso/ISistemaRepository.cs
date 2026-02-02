using ReguaDisparo.Domain.Entities.ControleAcesso;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

public interface ISistemaRepository
{
    Task<List<TB_CMC_SISTEMA>> ListarAsync();
    Task<List<TB_CMC_SISTEMA>> ListarAtivosAsync();
    Task<TB_CMC_SISTEMA?> BuscarAsync(int idSistema);
    Task InserirAsync(TB_CMC_SISTEMA entidade);
    Task AtualizarAsync(TB_CMC_SISTEMA entidade);
    Task ExcluirAsync(int idSistema);
}
