using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

public interface IConfigGeralRepository
{
    Task<TB_CMCRM_CONFIG_GERAL?> ListarAsync();
    Task InserirAsync(TB_CMCRM_CONFIG_GERAL entidade);
    Task AtualizarAsync(TB_CMCRM_CONFIG_GERAL entidade);
}
