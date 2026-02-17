namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de busca de base de mensageria
/// Coordena a busca de dados base conforme tipo de ação da régua
/// </summary>
public interface IMensageriaService
{
    /// <summary>
    /// Busca base de dados para mensageria conforme tipo de ação
    /// </summary>
    /// <param name="tipoAcao">Tipo da ação (EMAIL, SMS, WHATSAPP, etc)</param>
    /// <param name="descricaoAcao">Descrição específica da ação</param>
    /// <param name="cobrancaPreventiva">Se é cobrança preventiva</param>
    /// <param name="nomeBancoCrm">Nome do banco CRM</param>
    /// <param name="idOrganizacao">ID da organização (para regras específicas)</param>
    /// <returns>Lista de destinatários com dados para mensageria</returns>
    Task<List<DestinatarioMensageria>> BuscarBaseMensageriaAsync(
        string tipoAcao,
        string? descricaoAcao,
        bool cobrancaPreventiva,
        string nomeBancoCrm,
        string idOrganizacao);
}

/// <summary>
/// DTO unificado para destinatários de mensageria
/// Consolida dados de diferentes bases em um formato único
/// </summary>
public class DestinatarioMensageria
{
    public int? IdEmpresa { get; set; }
    public string? IdObra { get; set; }
    public int? IdVenda { get; set; }
    public string? Cliente { get; set; }
    public string? Email { get; set; }
    public string? DDD { get; set; }
    public string? Telefone { get; set; }
    public string? Produto { get; set; }
    public string? ChaveErp { get; set; }
    public string? Identificador { get; set; }
    public string? ClassificacaoContrato { get; set; }
    public int? AgingDias { get; set; }
    public decimal? ValorVencido { get; set; }
    public decimal? ValorAVencer { get; set; }
    public DateTime? DataVencimento { get; set; }
    public int? QuantidadeParcelasVencidas { get; set; }
    public string? NumeroParcela { get; set; }
    public decimal? ValorParcela { get; set; }
    public int? DiasAteVencimento { get; set; }
    public DateTime? DataEntregaChaves { get; set; }
    public DateTime? DataNascimento { get; set; }
    public bool? Aniversariante { get; set; }
    
    // Propriedades calculadas
    public Dictionary<string, object>? DadosAdicionais { get; set; }
}
