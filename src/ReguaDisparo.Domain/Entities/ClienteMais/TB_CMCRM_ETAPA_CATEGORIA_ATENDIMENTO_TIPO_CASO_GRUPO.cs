using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_GRUPO
{
    public int ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO_GRUPO { get; set; }

    public int ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int ID_GRUPO { get; set; }

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; } = null!;
}
