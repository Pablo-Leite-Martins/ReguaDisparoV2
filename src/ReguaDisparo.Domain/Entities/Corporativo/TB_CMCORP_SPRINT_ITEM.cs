using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_SPRINT_ITEM
{
    public int ID_SPRINT_ITEM { get; set; }

    public string DS_DESCRICAO { get; set; } = null!;

    public string DS_TIPO { get; set; } = null!;

    public int ID_MODULO { get; set; }

    public int ID_SPRINT { get; set; }

    public virtual TB_CMCORP_SPRINT ID_SPRINTNavigation { get; set; } = null!;
}
