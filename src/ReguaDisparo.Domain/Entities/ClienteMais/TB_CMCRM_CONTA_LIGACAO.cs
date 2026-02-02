using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_LIGACAO
{
    public int ID_CONTA_LIGACAO { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_USUARIO { get; set; }

    public string ID_LIGACAO { get; set; } = null!;

    public DateTime DT_LIGACAO { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;
}
