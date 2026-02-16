using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AUDIENCIA_CONTATO
{
    public int ID_AUDIENCIA_CONTATO { get; set; }

    public int ID_AUDIENCIA { get; set; }

    public int ID_CONTATO { get; set; }

    public virtual TB_CMCRM_AUDIENCIA ID_AUDIENCIANavigation { get; set; } = null!;

    public virtual TB_CMCRM_CONTATO ID_CONTATONavigation { get; set; } = null!;
}
