using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO_2023_12_14
{
    public int ID_ATRIBUTO_ETAPA_TIPO_CASO { get; set; }

    public int ID_ATRIBUTO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_OBRIGATORIO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool FL_APENAS_LEITURA { get; set; }
}
