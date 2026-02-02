using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_INTEGRACAO_BUG
{
    public int ID_INTEGRACAO_BUG { get; set; }

    public int ID_TIPO_INTEGRACAO { get; set; }

    public string? DS_VERSAO { get; set; }

    public string? DS_MENSAGEM { get; set; }

    public virtual TB_CMCORP_TIPO_INTEGRACAO ID_TIPO_INTEGRACAONavigation { get; set; } = null!;
}
