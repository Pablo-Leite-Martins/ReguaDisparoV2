using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMODO_ASSISTENCIA_TEC
{
    public int ID_COMODO_ASSISTENCIA_TEC { get; set; }

    public string DS_COMODO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_COMODO_ASSISTENCIA_TEC> TB_CMCRM_CASO_COMODO_ASSISTENCIA_TECs { get; set; } = new List<TB_CMCRM_CASO_COMODO_ASSISTENCIA_TEC>();
}
