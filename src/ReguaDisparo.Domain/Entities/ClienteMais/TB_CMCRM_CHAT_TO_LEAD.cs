using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CHAT_TO_LEAD
{
    public int ID_CHAT_TO_LEAD { get; set; }

    public int ID_ORIGEM_LEAD { get; set; }

    public string? DS_LINK_DRIVE { get; set; }

    public string? DS_CHAT_TO_LEAD { get; set; }

    public bool? FL_FILA_POR_EQUIPE_VENDAS { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;
}
