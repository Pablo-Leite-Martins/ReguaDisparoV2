using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_HELP_DESK_GERENCIA
{
    public int ID_EQUIPE_GERENCIA { get; set; }

    public int ID_EQUIPE_HELP_DESK { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_EQUIPE_HELP_DESK ID_EQUIPE_HELP_DESKNavigation { get; set; } = null!;
}
