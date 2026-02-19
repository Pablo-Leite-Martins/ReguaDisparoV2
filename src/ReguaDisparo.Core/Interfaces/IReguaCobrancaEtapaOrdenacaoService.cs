using System.Data;
using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de ordenação de régua de cobrança
/// </summary>
public interface IReguaCobrancaEtapaOrdenacaoService
{
    /// <summary>
    /// Lista ordenações configuradas para uma etapa
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarPorEtapaAsync(int idEtapa, string nomeBancoCrm);

    /// <summary>
    /// Aplica ordenações em um DataTable
    /// </summary>
    /// <param name="dtDados">DataTable com os dados a serem ordenados</param>
    /// <param name="listaOrdenacao">Lista de ordenações a aplicar</param>
    /// <returns>DataTable ordenado</returns>
    DataTable AplicarOrdenacao(DataTable dtDados, List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO> listaOrdenacao);
}
