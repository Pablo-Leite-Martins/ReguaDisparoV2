using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AREA_COMUM
{
    public int ID_AREA_COMUM { get; set; }

    public string DS_AREA_COMUM { get; set; } = null!;

    public decimal VL_PESO { get; set; }

    public virtual ICollection<TB_CMCRM_AREA_COMUM_INTERESSE> TB_CMCRM_AREA_COMUM_INTERESSEs { get; set; } = new List<TB_CMCRM_AREA_COMUM_INTERESSE>();

    public virtual ICollection<TB_CMCRM_AREA_COMUM_PRODUTO> TB_CMCRM_AREA_COMUM_PRODUTOs { get; set; } = new List<TB_CMCRM_AREA_COMUM_PRODUTO>();
}
