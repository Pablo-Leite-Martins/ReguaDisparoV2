using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_TITULOS_ABERTO
{
    public long ID_TITULO_SIENGE { get; set; }

    public long? receivableBillId { get; set; }

    public DateTime? issueDate { get; set; }

    public string? documentNumber { get; set; }

    public string? units { get; set; }

    public decimal? receivableBillValue { get; set; }

    public DateTime? dt_mes_referencia { get; set; }

    public int? companyId { get; set; }

    public int? clientId { get; set; }

    public string? clientName { get; set; }
}
