using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_PAI
{
    public int ID_PAIS { get; set; }

    public string DS_PAIS { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_ESTADO> TB_CMCORP_ESTADOs { get; set; } = new List<TB_CMCORP_ESTADO>();
}
