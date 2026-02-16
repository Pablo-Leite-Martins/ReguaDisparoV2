using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIA
{
    public int ID_CASO_PARALIZACAO_SLA_VISTORIA { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_MOTIVO_NAO_PROCEDENCIA { get; set; }

    public DateTime? DT_INICIO_PARALIZACAO_SLA { get; set; }

    public DateTime? DT_FIM_PARALIZACAO_SLA { get; set; }

    public bool? FL_APROVADO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_MOTIVO_NAO_PROCEDENCIA? ID_MOTIVO_NAO_PROCEDENCIANavigation { get; set; }
}
