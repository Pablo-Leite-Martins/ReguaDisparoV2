using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MOTIVO_NAO_PROCEDENCIum
{
    public int ID_MOTIVO_NAO_PROCEDENCIA { get; set; }

    public string DS_MOTIVO_NAO_PROCEDENCIA { get; set; } = null!;

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIum> TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIa { get; set; } = new List<TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIum>();
}
