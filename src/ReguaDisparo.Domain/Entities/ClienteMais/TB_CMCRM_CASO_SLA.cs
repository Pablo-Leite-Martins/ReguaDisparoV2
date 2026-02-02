using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_SLA
{
    public int ID_CASO_SLA { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_SLA { get; set; }

    public bool FL_SLA_ATIVO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
