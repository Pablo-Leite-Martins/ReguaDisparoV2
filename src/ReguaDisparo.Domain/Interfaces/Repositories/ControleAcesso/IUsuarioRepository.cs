using ReguaDisparo.Domain.Entities.ControleAcesso;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ControleAcesso;

public interface IUsuarioRepository
{
    Task<List<TB_CMC_USUARIO>> ListarAsync();
    Task<List<TB_CMC_USUARIO>> ListarAtivosPorOrganizacaoAsync(string idOrganizacao);
    Task<TB_CMC_USUARIO?> BuscarAsync(int idUsuario);
    Task<TB_CMC_USUARIO?> BuscarPorLoginAsync(string login);
    Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha);
    Task<List<TB_CMC_USUARIO_ORGANIZACAO>> ListarOrganizacoesDoUsuarioAsync(int idUsuario);
    Task InserirAsync(TB_CMC_USUARIO entidade);
    Task AtualizarAsync(TB_CMC_USUARIO entidade);
    Task ExcluirAsync(int idUsuario);
}
