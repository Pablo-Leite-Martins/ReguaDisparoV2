using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para gerenciamento de ações de etapas de régua de cobrança
/// </summary>
public interface IReguaCobrancaEtapaAcaoService
{
    /// <summary>
    /// Lista todas as ações de etapa de régua
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Lista ações por etapa de régua
    /// </summary>
    /// <param name="idReguaEtapa">ID da etapa de régua</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM do tenant</param>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorReguaEtapaAsync(int idReguaEtapa, string nomeBancoCrm);

    /// <summary>
    /// Lista ações por tipo de ação
    /// </summary>
    /// <param name="idTipoAcao">ID do tipo de ação</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM do tenant</param>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorTipoAcaoAsync(int idTipoAcao, string nomeBancoCrm);

    /// <summary>
    /// Busca uma ação específica por ID
    /// </summary>
    /// <param name="idAcao">ID da ação</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM do tenant</param>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO?> BuscarAsync(int idAcao, string nomeBancoCrm);
}
