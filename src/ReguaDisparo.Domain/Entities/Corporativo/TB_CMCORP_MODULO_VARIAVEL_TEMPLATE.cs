using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_MODULO_VARIAVEL_TEMPLATE
{
    public int ID_MODULO_VARIAVEL_TEMPLATE { get; set; }

    public int ID_MODULO { get; set; }

    public int ID_VARIAVEL_TEMPLATE { get; set; }

    public virtual TB_CMCORP_VARIAVEL_TEMPLATE ID_VARIAVEL_TEMPLATENavigation { get; set; } = null!;
}
