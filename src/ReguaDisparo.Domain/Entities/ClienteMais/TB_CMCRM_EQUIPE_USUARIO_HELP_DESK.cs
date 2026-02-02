using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_USUARIO_HELP_DESK
{
    public int ID_EQUIPE_USUARIO_HELP_DESK { get; set; }

    public int ID_EQUIPE_HELP_DESK { get; set; }

    public int ID_USUARIO { get; set; }

    public int NR_ORDEM { get; set; }

    public int NR_LIMITE_CHAT { get; set; }

    public virtual TB_CMCRM_EQUIPE_HELP_DESK ID_EQUIPE_HELP_DESKNavigation { get; set; } = null!;
}
