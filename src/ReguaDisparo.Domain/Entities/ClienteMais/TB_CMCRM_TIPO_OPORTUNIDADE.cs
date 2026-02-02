using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_OPORTUNIDADE
{
    public int ID_TIPO_OPORTUNIDADE { get; set; }

    public string DS_TIPO_OPORTUNIDADE { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_OPORTUNIDADE> TB_CMCRM_OPORTUNIDADEs { get; set; } = new List<TB_CMCRM_OPORTUNIDADE>();
}
