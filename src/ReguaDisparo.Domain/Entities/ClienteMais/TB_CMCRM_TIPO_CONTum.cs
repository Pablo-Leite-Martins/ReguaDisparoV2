using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_CONTum
{
    public int ID_TIPO_CONTA { get; set; }

    public string DS_TIPO_CONTA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CONTum> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTum>();
}
