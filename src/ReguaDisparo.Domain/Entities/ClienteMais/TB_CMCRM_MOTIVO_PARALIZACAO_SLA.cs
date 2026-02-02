using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MOTIVO_PARALIZACAO_SLA
{
    public int ID_MOTIVO_PARALIZACAO_SLA { get; set; }

    public string DS_MOTIVO_PARALIZACAO_SLA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_PARALIZACAO_SLA> TB_CMCRM_CASO_PARALIZACAO_SLAs { get; set; } = new List<TB_CMCRM_CASO_PARALIZACAO_SLA>();
}
