using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_TIPO_INTEGRACAO_ATRIBUTO
{
    public int ID_TIPO_INTEGRACAO_ATRIBUTO { get; set; }

    public int ID_TIPO_INTEGRACAO { get; set; }

    public string DS_TIPO_INTEGRACAO_ATRIBUTO { get; set; } = null!;

    public string DS_FORMATO { get; set; } = null!;

    public virtual TB_CMCORP_TIPO_INTEGRACAO ID_TIPO_INTEGRACAONavigation { get; set; } = null!;
}
