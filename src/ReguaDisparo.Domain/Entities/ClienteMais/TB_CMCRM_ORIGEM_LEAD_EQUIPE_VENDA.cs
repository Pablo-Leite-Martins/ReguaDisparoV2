using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDA
{
    public int ID_ORIGEM_LEAD_EQUIPE_VENDAS { get; set; }

    public int ID_ORIGEM_LEAD { get; set; }

    public int ID_EQUIPE_VENDAS { get; set; }

    public virtual TB_CMCRM_EQUIPE_VENDA ID_EQUIPE_VENDASNavigation { get; set; } = null!;

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;
}
