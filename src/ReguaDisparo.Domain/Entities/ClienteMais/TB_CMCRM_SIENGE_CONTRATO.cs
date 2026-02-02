using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CONTRATO
{
    public long ID_SIENGE_CONTRATO { get; set; }

    public int? id { get; set; }

    /// <summary>
    /// Código do empreendimento
    /// </summary>
    public int? enterpriseId { get; set; }

    public int? receivableBillId { get; set; }

    public DateTime? contractDate { get; set; }

    public DateTime? issueDate { get; set; }

    public string? number { get; set; }

    public string? externalId { get; set; }

    public string? correctionType { get; set; }

    public string? situation { get; set; }

    public string? discountType { get; set; }

    public decimal? discountPercentage { get; set; }

    public decimal? value { get; set; }

    public decimal? totalSellingValue { get; set; }

    public DateTime? cancellationDate { get; set; }

    public string? cancellationReason { get; set; }

    public int? proRataIndexer { get; set; }

    public string? interestType { get; set; }

    public decimal? interestPercentage { get; set; }

    public decimal? fineRate { get; set; }

    public string? lateInterestCalculationType { get; set; }

    public decimal? dailyLateInterestValue { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
