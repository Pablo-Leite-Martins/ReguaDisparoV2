using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CARTORIO
{
    public int ID_CARTORIO { get; set; }

    public string? DS_CARTORIO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_REPASSE_DADO> TB_CMCRM_CASO_REPASSE_DADOs { get; set; } = new List<TB_CMCRM_CASO_REPASSE_DADO>();
}
