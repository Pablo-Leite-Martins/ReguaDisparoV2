using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IDEIAS_PUBLICACAO
{
    public int ID_PUBLICACAO { get; set; }

    public int? ID_IDEIA { get; set; }

    public DateTime DT_PUBLICACAO { get; set; }

    public string DS_PUBLICACAO { get; set; } = null!;

    public virtual TB_CMCRM_IDEIA? ID_IDEIANavigation { get; set; }
}
