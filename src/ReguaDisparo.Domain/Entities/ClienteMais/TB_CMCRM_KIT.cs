using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_KIT
{
    public int ID_KIT { get; set; }

    public string DS_TIPO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_KIT_UNIDADE> TB_CMCRM_KIT_UNIDADEs { get; set; } = new List<TB_CMCRM_KIT_UNIDADE>();
}
