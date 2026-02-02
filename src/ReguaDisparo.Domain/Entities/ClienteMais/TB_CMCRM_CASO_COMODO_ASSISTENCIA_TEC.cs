using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COMODO_ASSISTENCIA_TEC
{
    public int ID_CASO_COMODO_ASSISTENCIA_TEC { get; set; }

    public int ID_CASO { get; set; }

    public int ID_COMODO_ASSISTENCIA_TEC { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_COMODO_ASSISTENCIA_TEC ID_COMODO_ASSISTENCIA_TECNavigation { get; set; } = null!;
}
