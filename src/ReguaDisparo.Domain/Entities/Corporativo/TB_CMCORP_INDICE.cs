using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_INDICE
{
    public int ID_INDICE { get; set; }

    public int COD_INDICE { get; set; }

    public string DS_INDICE { get; set; } = null!;
}
