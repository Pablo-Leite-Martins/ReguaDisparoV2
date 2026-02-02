using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_ATIVIDADE
{
    public int ID_TIPO_ATIVIDADE { get; set; }

    public string DS_TIPO_ATIVIDADE { get; set; } = null!;

    public string DS_ICONE { get; set; } = null!;

    public int? ID_TIPO_CASO { get; set; }

    public bool? FL_LIGACAO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_ATIVIDADE> TB_CMCRM_CASO_ATIVIDADEs { get; set; } = new List<TB_CMCRM_CASO_ATIVIDADE>();
}
