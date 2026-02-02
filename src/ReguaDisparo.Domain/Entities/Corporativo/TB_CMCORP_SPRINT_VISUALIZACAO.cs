using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_SPRINT_VISUALIZACAO
{
    public int ID_SPRINT_VISUALIZACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public int? NR_RELEVANCIA { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public bool FL_AVALIADO { get; set; }

    public int ID_SPRINT { get; set; }

    public virtual TB_CMCORP_SPRINT ID_SPRINTNavigation { get; set; } = null!;
}
