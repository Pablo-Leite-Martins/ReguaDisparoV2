using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_STATUS_ETAPA
{
    public int ID_STATUS_ETAPA { get; set; }

    public string DS_STATUS_ETAPA { get; set; } = null!;

    public bool FL_OBRIGATORIO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_STATUS> TB_CMCRM_CASO_STATUSes { get; set; } = new List<TB_CMCRM_CASO_STATUS>();
}
