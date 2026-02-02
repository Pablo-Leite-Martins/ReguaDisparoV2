using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_ATENDIMENTO_TIPO_CASO
{
    public int ID_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO ID_CATEGORIA_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CASO ID_TIPO_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO> TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASOs { get; set; } = new List<TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO>();
}
