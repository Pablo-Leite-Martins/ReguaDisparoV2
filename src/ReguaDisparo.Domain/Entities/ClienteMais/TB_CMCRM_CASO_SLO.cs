using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_SLO
{
    public int ID_CASO_SLO { get; set; }

    public int ID_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public DateTime DT_SLO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public bool? FL_ETAPA_ATIVA { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }
}
