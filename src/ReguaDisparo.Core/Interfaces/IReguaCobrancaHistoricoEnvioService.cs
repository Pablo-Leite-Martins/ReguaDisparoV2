using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de histórico de envios das ações da régua de cobrança
/// </summary>
public interface IReguaCobrancaHistoricoEnvioService
{
    /// <summary>
    /// Lista todos os históricos de envio por ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm);

    /// <summary>
    /// Obtém um histórico de envio específico por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO?> ObterPorIdAsync(int id, string nomeBancoCrm);

    /// <summary>
    /// Adiciona um novo histórico de envio
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO> AdicionarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO historicoEnvio, string nomeBancoCrm);

    /// <summary>
    /// Atualiza um histórico de envio existente
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO historicoEnvio, string nomeBancoCrm);

    /// <summary>
    /// Remove um histórico de envio
    /// </summary>
    Task RemoverAsync(int id, string nomeBancoCrm);

    /// <summary>
    /// Verifica a quantidade de envios realizados no dia para uma ação específica
    /// </summary>
    Task<int> VerificarQuantidadeEnviosNoDiaAsync(int idAcao, DateTime data, string nomeBancoCrm);

    /// <summary>
    /// Lista os históricos de envio por período
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorPeriodoAsync(
        int idAcao, 
        DateTime dataInicio, 
        DateTime dataFim, 
        string nomeBancoCrm);
}
