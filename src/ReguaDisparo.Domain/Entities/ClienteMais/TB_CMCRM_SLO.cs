using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SLO
{
    public int ID_SLO { get; set; }

    public int ID_ETAPA_TIPO_CASO { get; set; }

    public int NR_SLO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int? NR_SLO_AREA_COMUM { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO ID_ETAPA_TIPO_CASONavigation { get; set; } = null!;
}
