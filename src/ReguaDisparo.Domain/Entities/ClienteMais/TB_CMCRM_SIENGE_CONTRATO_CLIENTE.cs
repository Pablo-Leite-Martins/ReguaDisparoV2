using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CONTRATO_CLIENTE
{
    public long ID_SIENGE_CONTRATO_CLIENTE { get; set; }

    public long? idContrato { get; set; }

    /// <summary>
    /// Id do cliente do contrato
    /// </summary>
    public int? id { get; set; }

    public bool? main { get; set; }

    public bool? spouse { get; set; }

    public decimal? participationPercentage { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
