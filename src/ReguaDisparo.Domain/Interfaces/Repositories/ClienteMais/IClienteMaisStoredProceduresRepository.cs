using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

/// <summary>
/// Interface para repositório de stored procedures do banco ClienteMais CRM
/// </summary>
public interface IClienteMaisStoredProceduresRepository
{
    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA
    /// Busca base de dados para mensageria de cobrança (títulos vencidos)
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <returns>Lista de dados para mensageria</returns>
    Task<List<BaseMensageriaCobranca>> BuscarBaseMensageriaCobrancaAsync(DateTime dataInicio);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS
    /// Busca base de dados para mensageria de parcelas
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <param name="incluirTodasEmpresas">Flag para incluir todas empresas</param>
    /// <returns>Lista de dados para mensageria de parcelas</returns>
    Task<List<BaseMensageriaParcelas>> BuscarBaseMensageriaParcelasAsync(DateTime dataInicio, bool incluirTodasEmpresas = false);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER
    /// Busca base de dados para mensageria preventiva (a receber)
    /// </summary>
    /// <param name="dataInicio">Data inicial para filtragem</param>
    /// <param name="incluirTodasEmpresas">Flag para incluir todas empresas</param>
    /// <returns>Lista de dados para mensageria preventiva</returns>
    Task<List<BaseMensageriaAReceber>> BuscarBaseMensageriaAReceberAsync(DateTime dataInicio, bool incluirTodasEmpresas = false);

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL
    /// Busca base de dados para mensageria pós-ocupacional
    /// </summary>
    /// <returns>Lista de dados para mensageria pós-ocupacional</returns>
    Task<List<BaseMensageriaPosOcupacional>> BuscarBaseMensageriaPosOcupacionalAsync();

    /// <summary>
    /// SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO
    /// Busca base de dados para mensageria de relacionamento com cliente
    /// </summary>
    /// <param name="apenasAniversariantes">Se true, retorna apenas aniversariantes</param>
    /// <returns>Lista de dados para mensageria de relacionamento</returns>
    Task<List<BaseMensageriaRelacionamento>> BuscarBaseMensageriaRelacionamentoAsync(bool apenasAniversariantes);
}

/// <summary>
/// DTO para base de mensageria de cobrança
/// </summary>
public class BaseMensageriaCobranca
{
    public int? ID_EMPRESA { get; set; }
    public string? ID_OBRA { get; set; }
    public int? ID_VENDA { get; set; }
    public string? DS_CLIENTE { get; set; }
    public string? DS_EMAIL { get; set; }
    public string? COD_DDD { get; set; }
    public string? NR_TELEFONE { get; set; }
    public string? DS_PRODUTO { get; set; }
    public string? ID_CHAVE_ERP { get; set; }
    public string? DS_IDENTIFICADOR { get; set; }
    public string? DS_CLASSIFICACAO_CONTRATO { get; set; }
    public int? NR_AGING_DIAS_CONTRATO { get; set; }
    public decimal? VL_TOTAL_VENCIDO { get; set; }
    public decimal? VL_TOTAL_A_VENCER { get; set; }
    public DateTime? DT_VENCIMENTO_MAIS_ANTIGO { get; set; }
    public int? QT_PARCELAS_VENCIDAS { get; set; }
}

/// <summary>
/// DTO para base de mensageria de parcelas
/// </summary>
public class BaseMensageriaParcelas
{
    public int? ID_EMPRESA { get; set; }
    public string? ID_OBRA { get; set; }
    public int? ID_VENDA { get; set; }
    public string? DS_CLIENTE { get; set; }
    public string? DS_EMAIL { get; set; }
    public string? COD_DDD { get; set; }
    public string? NR_TELEFONE { get; set; }
    public string? DS_PRODUTO { get; set; }
    public string? NR_PARCELA { get; set; }
    public DateTime? DT_VENCIMENTO { get; set; }
    public decimal? VL_PARCELA { get; set; }
    public string? DS_CLASSIFICACAO_CONTRATO { get; set; }
}

/// <summary>
/// DTO para base de mensageria a receber (preventiva)
/// </summary>
public class BaseMensageriaAReceber
{
    public int? ID_EMPRESA { get; set; }
    public string? ID_OBRA { get; set; }
    public int? ID_VENDA { get; set; }
    public string? DS_CLIENTE { get; set; }
    public string? DS_EMAIL { get; set; }
    public string? COD_DDD { get; set; }
    public string? NR_TELEFONE { get; set; }
    public string? DS_PRODUTO { get; set; }
    public DateTime? DT_VENCIMENTO_PROXIMO { get; set; }
    public decimal? VL_PROXIMO_VENCIMENTO { get; set; }
    public int? DIAS_ATE_VENCIMENTO { get; set; }
}

/// <summary>
/// DTO para base de mensageria pós-ocupacional
/// </summary>
public class BaseMensageriaPosOcupacional
{
    public int? ID_EMPRESA { get; set; }
    public string? ID_OBRA { get; set; }
    public int? ID_VENDA { get; set; }
    public string? DS_CLIENTE { get; set; }
    public string? DS_EMAIL { get; set; }
    public string? COD_DDD { get; set; }
    public string? NR_TELEFONE { get; set; }
    public DateTime? DT_ENTREGA_CHAVES { get; set; }
}

/// <summary>
/// DTO para base de mensageria de relacionamento
/// </summary>
public class BaseMensageriaRelacionamento
{
    public int? ID_EMPRESA { get; set; }
    public string? ID_OBRA { get; set; }
    public int? ID_VENDA { get; set; }
    public string? DS_CLIENTE { get; set; }
    public string? DS_EMAIL { get; set; }
    public string? COD_DDD { get; set; }
    public string? NR_TELEFONE { get; set; }
    public DateTime? DT_NASCIMENTO { get; set; }
    public bool? FL_ANIVERSARIANTE_MES { get; set; }
}
