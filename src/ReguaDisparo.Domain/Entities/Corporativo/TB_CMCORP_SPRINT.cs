using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_SPRINT
{
    public int ID_SPRINT { get; set; }

    public string DS_NOME { get; set; } = null!;

    public DateTime DT_CADASTRO { get; set; }

    public virtual ICollection<TB_CMCORP_SPRINT_ITEM> TB_CMCORP_SPRINT_ITEMs { get; set; } = new List<TB_CMCORP_SPRINT_ITEM>();

    public virtual ICollection<TB_CMCORP_SPRINT_VISUALIZACAO> TB_CMCORP_SPRINT_VISUALIZACAOs { get; set; } = new List<TB_CMCORP_SPRINT_VISUALIZACAO>();
}
