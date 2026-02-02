using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_UNIDADE_FILHA
{
    public int ID_UNIDADE_FILHA { get; set; }

    public string? name { get; set; }

    public string? order { get; set; }

    public decimal? privateArea { get; set; }

    public decimal? commonArea { get; set; }

    public decimal? idealFraction { get; set; }

    public decimal? idealFractionSquareMeter { get; set; }

    public string? locationName { get; set; }

    public string? note { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
