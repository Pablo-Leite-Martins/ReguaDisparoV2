using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_TITULOS_ABERTO_PARCELA
{
    public long ID_TITULO_ABERTO_PARCELA { get; set; }

    public long? receivableBillId { get; set; }

    public long? installmentId { get; set; }

    public string? conditionType { get; set; }

    public DateTime? dueDate { get; set; }

    public string? daysOfDelay { get; set; }

    public decimal? correctedValueWithoutAdditions { get; set; }

    public decimal? proRata { get; set; }

    public decimal? interest { get; set; }

    public decimal? fine { get; set; }

    public decimal? totalAdditions { get; set; }

    public decimal? correctedValueWithAdditions { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
