using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO
{
    public int ID_ATRIBUTO_ETAPA_TIPO_CASO { get; set; }

    public int ID_ATRIBUTO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_OBRIGATORIO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool FL_APENAS_LEITURA { get; set; }

    public bool FL_NAO_PERMITE_DATA_FUTURA { get; set; }

    public virtual TB_CMCRM_ATRIBUTO ID_ATRIBUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }
}
