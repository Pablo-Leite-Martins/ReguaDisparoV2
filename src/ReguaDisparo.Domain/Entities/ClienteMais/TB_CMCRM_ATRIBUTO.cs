using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ATRIBUTO
{
    public int ID_ATRIBUTO { get; set; }

    public string DS_TABELA { get; set; } = null!;

    public string DS_ATRIBUTO { get; set; } = null!;

    public string? DS_DESCRICAO { get; set; }

    public virtual ICollection<TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO> TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_ATRIBUTO_ETAPA_TIPO_CASO>();
}
