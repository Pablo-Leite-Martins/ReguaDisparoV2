using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_CONTA
{
    public int ID_TIPO_CONTA { get; set; }

    public string DS_TIPO_CONTA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CONTA> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTA>();
}
