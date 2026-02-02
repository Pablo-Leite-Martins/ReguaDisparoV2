using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORIGEM_LEAD_PRODUTO
{
    public int ID_ORIGEM_LEAD_PRODUTO { get; set; }

    public int ID_ORIGEM_LEAD { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
