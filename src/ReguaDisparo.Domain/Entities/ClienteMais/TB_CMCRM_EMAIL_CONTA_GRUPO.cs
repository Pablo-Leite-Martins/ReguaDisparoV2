using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_CONTA_GRUPO
{
    public int ID_EMAIL_CONTA_GRUPO { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_EMAIL_CONTA { get; set; }

    public virtual TB_CMCRM_EMAIL_CONTum ID_EMAIL_CONTANavigation { get; set; } = null!;
}
