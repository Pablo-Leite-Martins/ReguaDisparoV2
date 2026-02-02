using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_TITULOS_PAGO
{
    public int ID_SIENGE_TITULOS_PAGOS { get; set; }

    public string? companyId { get; set; }

    public string? costCenterId { get; set; }

    public string? billId { get; set; }

    public string? installmentId { get; set; }

    public DateTime? paymentDate { get; set; }

    public decimal? grossAmount { get; set; }

    public string? operationalTypeId { get; set; }

    public string? operationalTypeName { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
