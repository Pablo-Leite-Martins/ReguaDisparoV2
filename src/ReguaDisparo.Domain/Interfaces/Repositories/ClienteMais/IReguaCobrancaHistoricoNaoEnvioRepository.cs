using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

/// <summary>
/// Interface para repositório de histórico de não envios da régua de cobrança
/// </summary>
public interface IReguaCobrancaHistoricoNaoEnvioRepository
{
    /// <summary>
    /// Lista todos os históricos de não envio
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarAsync();

    /// <summary>
    /// Lista históricos de não envio por ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarPorAcaoAsync(int idAcao);

    /// <summary>
    /// Busca histórico de não envio por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO?> BuscarAsync(int id);

    /// <summary>
    /// Insere um novo histórico de não envio
    /// </summary>
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade);

    /// <summary>
    /// Atualiza um histórico de não envio existente
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade);

    /// <summary>
    /// Exclui um histórico de não envio
    /// </summary>
    Task ExcluirAsync(int id);
}
