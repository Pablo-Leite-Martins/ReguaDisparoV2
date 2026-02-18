using System.Data;
using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de busca de base de mensageria
/// Coordena a busca de dados base conforme tipo de ação da régua
/// Retorna DataTable com os dados para processamento
/// </summary>
public interface IMensageriaService
{
    /// <summary>
    /// Busca base de dados para mensageria conforme tipo de ação
    /// </summary>
    /// <param name="acao">Ação da etapa da régua</param>
    /// <param name="cobrancaPreventiva">Se é cobrança preventiva</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM</param>
    /// <returns>DataTable com dados para mensageria</returns>
    Task<DataTable> BuscarBaseMensageriaAsync(
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        bool cobrancaPreventiva,
        string nomeBancoCrm);
}
