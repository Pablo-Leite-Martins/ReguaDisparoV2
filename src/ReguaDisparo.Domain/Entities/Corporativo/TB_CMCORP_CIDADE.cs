using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_CIDADE
{
    public int ID_CIDADE { get; set; }

    public string DS_CIDADE { get; set; } = null!;

    public int ID_ESTADO { get; set; }

    public bool FL_CAPITAL { get; set; }

    public virtual TB_CMCORP_ESTADO ID_ESTADONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_ORGANIZACAO> TB_CMCORP_ORGANIZACAOs { get; set; } = new List<TB_CMCORP_ORGANIZACAO>();
}
