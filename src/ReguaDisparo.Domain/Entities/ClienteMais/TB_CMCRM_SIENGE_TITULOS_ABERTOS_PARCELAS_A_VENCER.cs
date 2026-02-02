using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_TITULOS_ABERTOS_PARCELAS_A_VENCER
{
    public int ID_TITULO_ABERTO_PARCELA_A_VENCER { get; set; }

    public int? companyId { get; set; }

    public string? companyName { get; set; }

    public int? businessAreaId { get; set; }

    public string? businessAreaName { get; set; }

    public int? projectId { get; set; }

    public string? projectName { get; set; }

    public int? groupCompanyId { get; set; }

    public string? groupCompanyName { get; set; }

    public int? holdingId { get; set; }

    public string? holdingName { get; set; }

    public int? subsidiaryId { get; set; }

    public string? subsidiaryName { get; set; }

    public int? businessTypeId { get; set; }

    public string? businessTypeName { get; set; }

    public int? clientId { get; set; }

    public string? clientName { get; set; }

    public int? billId { get; set; }

    public int? installmentId { get; set; }

    public string? documentIdentificationId { get; set; }

    public string? documentIdentificationName { get; set; }

    public string? documentNumber { get; set; }

    public string? originId { get; set; }

    public string? originalAmount { get; set; }

    public string? discountAmount { get; set; }

    public string? taxAmount { get; set; }

    public int? indexerId { get; set; }

    public string? indexerName { get; set; }

    public DateTime? dueDate { get; set; }

    public DateTime? issueDate { get; set; }

    public string? installmentBaseDate { get; set; }

    public string? balanceAmount { get; set; }

    public string? correctedBalanceAmount { get; set; }

    public string? periodicityType { get; set; }

    public string? embeddedInterestAmount { get; set; }

    public string? interestType { get; set; }

    public string? interestRate { get; set; }

    public string? correctionType { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
