using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_PARALIZACAO_SLA
{
    public int ID_CASO_PARALIZACAO_SLA { get; set; }

    public int ID_CASO { get; set; }

    public int ID_MOTIVO_PARALIZACAO_SLA { get; set; }

    public DateTime DT_INICIO_PARALIZACAO_SLA { get; set; }

    public DateTime? DT_FIM_PARALIZACAO_SLA { get; set; }

    public bool FL_APROVADO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_MOTIVO_PARALIZACAO_SLA ID_MOTIVO_PARALIZACAO_SLANavigation { get; set; } = null!;
}
