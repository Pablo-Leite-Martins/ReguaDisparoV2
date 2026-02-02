using ReguaDisparo.Domain.Entities.ControleAcesso;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

public interface IGrupoRepository
{
    Task<List<TB_CMC_GRUPO>> ListarAsync();
    Task<List<TB_CMC_GRUPO>> ListarAtivosPorOrganizacaoAsync(string idOrganizacao);
    Task<TB_CMC_GRUPO?> BuscarAsync(int idGrupo);
    Task<List<TB_CMC_GRUPO_USUARIO>> ListarUsuariosDoGrupoAsync(int idGrupo);
    Task<List<TB_CMC_GRUPO_FUNCAO>> ListarFuncoesDoGrupoAsync(int idGrupo);
    Task InserirAsync(TB_CMC_GRUPO entidade);
    Task AtualizarAsync(TB_CMC_GRUPO entidade);
    Task ExcluirAsync(int idGrupo);
}
