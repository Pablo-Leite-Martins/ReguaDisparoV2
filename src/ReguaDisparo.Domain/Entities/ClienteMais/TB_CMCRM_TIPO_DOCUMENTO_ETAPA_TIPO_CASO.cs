using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_DOCUMENTO_ETAPA_TIPO_CASO
{
    public int ID_TIPO_DOCUMENTO_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public int ID_TIPO_DOCUMENTO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_DOCUMENTO ID_TIPO_DOCUMENTONavigation { get; set; } = null!;
}
