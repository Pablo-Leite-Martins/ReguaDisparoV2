using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_CLAUSULA
{
    public int ID_CASO_CLAUSULA { get; set; }

    public string DS_CASO_CLAUSULA { get; set; } = null!;

    public DateTime DT_CASO_CLAUSULA { get; set; }

    public int ID_CASO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
