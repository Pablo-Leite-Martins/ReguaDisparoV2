using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_CONTATO
{
    public int ID_CONTA_CONTATO { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_CONTATO { get; set; }

    public int ID_TIPO_RELACAO_CLIENTE { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_CONTATO ID_CONTATONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_RELACAO_CLIENTE ID_TIPO_RELACAO_CLIENTENavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_IDEIAS_VOTO> TB_CMCRM_IDEIAS_VOTOs { get; set; } = new List<TB_CMCRM_IDEIAS_VOTO>();

    public virtual ICollection<TB_CMCRM_IDEIA> TB_CMCRM_IDEIAs { get; set; } = new List<TB_CMCRM_IDEIA>();
}
