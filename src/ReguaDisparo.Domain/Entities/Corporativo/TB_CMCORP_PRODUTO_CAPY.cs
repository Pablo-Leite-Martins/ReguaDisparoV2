using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_PRODUTO_CAPY
{
    public int ID_PRODUTO_CAPYS { get; set; }

    public string DS_PRODUTO_CAPYS { get; set; } = null!;

    public int? ID_SISTEMA { get; set; }
}
