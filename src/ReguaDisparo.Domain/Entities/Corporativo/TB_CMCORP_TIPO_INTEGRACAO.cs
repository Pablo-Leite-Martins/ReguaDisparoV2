using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_TIPO_INTEGRACAO
{
    public int ID_TIPO_INTEGRACAO { get; set; }

    public string DS_TIPO_INTEGRACAO { get; set; } = null!;

    public string? DS_OBSERVACAO { get; set; }

    public bool? FL_URL_ATIVACAO { get; set; }

    public virtual ICollection<TB_CMCORP_INTEGRACAO_BUG> TB_CMCORP_INTEGRACAO_BUGs { get; set; } = new List<TB_CMCORP_INTEGRACAO_BUG>();

    public virtual ICollection<TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO> TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTOs { get; set; } = new List<TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO>();
}
