using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CONTRATO_PAGAMENTO
{
    public long ID_SIENGE_CONTRATO_PAGAMENTO { get; set; }

    public string? conditionTypeId { get; set; }

    public string? conditionTypeName { get; set; }

    public decimal? totalValue { get; set; }

    public int? installmentsNumber { get; set; }

    public DateTime? firstPayment { get; set; }

    public string? bearerId { get; set; }

    public string? bearerName { get; set; }

    public string? unitsGrouping { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
