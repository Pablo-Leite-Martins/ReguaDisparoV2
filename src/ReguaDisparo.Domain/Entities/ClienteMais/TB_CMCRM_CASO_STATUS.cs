using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_STATUS
{
    public int ID_CASO_STATUS { get; set; }

    public int ID_STATUS_ETAPA { get; set; }

    public DateTime DT_CASO_STATUS { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_CASO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_STATUS_ETAPA ID_STATUS_ETAPANavigation { get; set; } = null!;
}
