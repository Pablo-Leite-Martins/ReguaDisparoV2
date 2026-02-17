using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de histórico de não envios da régua de cobrança
/// </summary>
public interface IReguaCobrancaHistoricoNaoEnvioService
{
    /// <summary>
    /// Lista todos os históricos de não envio
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Lista históricos de não envio por ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm);

    /// <summary>
    /// Busca histórico de não envio por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO?> BuscarAsync(int id, string nomeBancoCrm);

    /// <summary>
    /// Registra uma falha de envio
    /// </summary>
    Task RegistrarFalhaAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO falha, string nomeBancoCrm);

    /// <summary>
    /// Atualiza um histórico de não envio existente
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade, string nomeBancoCrm);

    /// <summary>
    /// Exclui um histórico de não envio
    /// </summary>
    Task ExcluirAsync(int id, string nomeBancoCrm);
}
