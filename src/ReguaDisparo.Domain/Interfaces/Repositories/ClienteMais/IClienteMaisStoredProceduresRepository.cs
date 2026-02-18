using System.Data;
using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

/// <summary>
/// Interface para repositório de stored procedures do banco ClienteMais CRM
/// Retorna DataTable para compatibilidade com lógica original
/// </summary>
public interface IClienteMaisStoredProceduresRepository
{
    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA
    /// Busca base de dados para mensageria de cobrança (títulos vencidos)
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <returns>DataTable com dados para mensageria</returns>
    Task<DataTable> BuscarBaseMensageriaCobrancaAsync(DateTime dataInicio);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS
    /// Busca base de dados para mensageria de parcelas
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <returns>DataTable com dados para mensageria de parcelas</returns>
    Task<DataTable> BuscarBaseMensageriaParcelasAsync(DateTime dataInicio);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER
    /// Busca base de dados para mensageria preventiva (a receber)
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <returns>DataTable com dados para mensageria preventiva</returns>
    Task<DataTable> BuscarBaseMensageriaAReceberAsync(DateTime dataInicio);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL
    /// Busca base de dados para mensageria pós-ocupacional
    /// </summary>
    /// <returns>DataTable com dados para mensageria pós-ocupacional</returns>
    Task<DataTable> BuscarBaseMensageriaPosOcupacionalAsync();

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO
    /// Busca base de dados para mensageria de relacionamento com cliente
    /// </summary>
    /// <param name="apenasAniversariantes">Se true, retorna apenas aniversariantes</param>
    /// <returns>DataTable com dados para mensageria de relacionamento</returns>
    Task<DataTable> BuscarBaseMensageriaRelacionamentoAsync(bool apenasAniversariantes);
}
