using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTRATO_STATUS
{
    public int ID_CONTRATO_STATUS { get; set; }

    public string? DS_CONTRATO_STATUS { get; set; }

    public virtual ICollection<TB_CMCRM_CONTRATO> TB_CMCRM_CONTRATOs { get; set; } = new List<TB_CMCRM_CONTRATO>();
}
