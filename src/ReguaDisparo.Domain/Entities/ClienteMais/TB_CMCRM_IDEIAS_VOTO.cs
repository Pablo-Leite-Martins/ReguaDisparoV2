using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IDEIAS_VOTO
{
    public int ID_VOTOS { get; set; }

    public int ID_IDEIA { get; set; }

    public int ID_CONTA_CONTATO { get; set; }

    public DateTime DT_VOTO { get; set; }

    public virtual TB_CMCRM_CONTA_CONTATO ID_CONTA_CONTATONavigation { get; set; } = null!;

    public virtual TB_CMCRM_IDEIA ID_IDEIANavigation { get; set; } = null!;
}
