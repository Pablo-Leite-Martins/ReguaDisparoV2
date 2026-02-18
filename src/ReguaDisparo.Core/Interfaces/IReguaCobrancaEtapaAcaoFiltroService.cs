using System.Data;
using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para gerenciamento de filtros de ações de régua de cobrança
/// </summary>
public interface IReguaCobrancaEtapaAcaoFiltroService
{
    /// <summary>
    /// Lista todos os filtros de ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Lista filtros por ação de régua
    /// </summary>
    /// <param name="idAcao">ID da ação</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM do tenant</param>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm);

    /// <summary>
    /// Busca um filtro específico por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO?> BuscarAsync(int idFiltro, string nomeBancoCrm);

    /// <summary>
    /// Aplica filtros em um DataTable de forma performática
    /// Baseado no método ExecutaFiltroRegua do projeto original
    /// </summary>
    /// <param name="dtDados">DataTable com dados a serem filtrados</param>
    /// <param name="listaFiltros">Lista de filtros a aplicar</param>
    /// <returns>DataTable filtrado</returns>
    DataTable AplicarFiltros(DataTable dtDados, List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO> listaFiltros);
}
