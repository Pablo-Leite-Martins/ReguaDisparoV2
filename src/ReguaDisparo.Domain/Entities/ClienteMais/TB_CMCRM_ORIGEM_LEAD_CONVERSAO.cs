using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORIGEM_LEAD_CONVERSAO
{
    public int ID_ORIGEM_LEAD_CONVERSAO { get; set; }

    public int ID_ORIGEM_LEAD { get; set; }

    public int ID_CONTA { get; set; }

    public DateTime DT_CONVERSAO { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;
}
