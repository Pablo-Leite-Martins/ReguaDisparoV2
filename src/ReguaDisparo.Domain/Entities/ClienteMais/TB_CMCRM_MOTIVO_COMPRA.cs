using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MOTIVO_COMPRA
{
    public int ID_MOTIVO_COMPRA { get; set; }

    public string DS_MOTIVO_COMPRA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CONTA> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTA>();
}
