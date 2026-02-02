using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CONTRATO_UNIDADE
{
    public long ID_SIENGE_CONTRATO_UNIDADE { get; set; }

    public long? idContrato { get; set; }

    /// <summary>
    /// Id da unidade
    /// </summary>
    public int? id { get; set; }

    public bool? main { get; set; }

    public string? name { get; set; }

    public decimal? participationPercentage { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
