using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class tb_cmcrm_atributo_etapa_tipo_caso_20230102
{
    public int ID_ATRIBUTO_ETAPA_TIPO_CASO { get; set; }

    public int ID_ATRIBUTO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_OBRIGATORIO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool FL_APENAS_LEITURA { get; set; }
}
