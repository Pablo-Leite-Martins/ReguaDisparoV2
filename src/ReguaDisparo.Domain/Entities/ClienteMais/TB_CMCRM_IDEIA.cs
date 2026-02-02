using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IDEIA
{
    public int ID_IDEIA { get; set; }

    public string DS_TITULO_IDEIA { get; set; } = null!;

    public string DS_IDEIA { get; set; } = null!;

    public string DS_STATUS_IDEIA { get; set; } = null!;

    public DateTime DT_ABERTURA { get; set; }

    public int ID_CONTA_CONTATO { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_CONTA_CONTATO ID_CONTA_CONTATONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_IDEIAS_PUBLICACAO> TB_CMCRM_IDEIAS_PUBLICACAOs { get; set; } = new List<TB_CMCRM_IDEIAS_PUBLICACAO>();

    public virtual ICollection<TB_CMCRM_IDEIAS_VOTO> TB_CMCRM_IDEIAS_VOTOs { get; set; } = new List<TB_CMCRM_IDEIAS_VOTO>();
}
