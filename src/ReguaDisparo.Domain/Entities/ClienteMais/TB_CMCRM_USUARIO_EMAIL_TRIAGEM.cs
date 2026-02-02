using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_USUARIO_EMAIL_TRIAGEM
{
    public int ID_USUARIO_EMAIL_TRIAGEM { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_EMAIL { get; set; }

    public int? ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_EMAIL ID_EMAILNavigation { get; set; } = null!;
}
