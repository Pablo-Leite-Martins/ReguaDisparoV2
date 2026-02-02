using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_VARIAVEL_TEMPLATE
{
    public int ID_VARIAVEL_TEMPLATE { get; set; }

    public string DS_VARIAVEL_TEMPLATE { get; set; } = null!;

    public string DS_TABLE_VARIAVEL_TEMPLATE { get; set; } = null!;

    public string? DS_PARAMETRO_VARIAVEL_TEMPLATE { get; set; }

    public string DS_TIPO_PARAMETRO_VARIAVEL_TEMPLATE { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_MODULO_VARIAVEL_TEMPLATE> TB_CMCORP_MODULO_VARIAVEL_TEMPLATEs { get; set; } = new List<TB_CMCORP_MODULO_VARIAVEL_TEMPLATE>();
}
