using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Entities.Corporativo;
using System.Data;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de processamento de filtros e dados de réguas
/// </summary>
public interface IReguaFiltroService
{
    /// <summary>
    /// Executa filtros em um DataTable baseado nas configurações da ação da etapa
    /// </summary>
    DataTable ExecutarFiltros(
        DataTable dados, 
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO> filtros);

    /// <summary>
    /// Executa ordenação em um DataTable
    /// </summary>
    DataTable ExecutarOrdenacao(
        DataTable dados,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO> ordenacoes);

    /// <summary>
    /// Verifica e aplica validações da régua (modo teste vs produção)
    /// </summary>
    void VerificarValidacao(
        ref DataTable dados,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG config,
        string tipoAcao);
}
