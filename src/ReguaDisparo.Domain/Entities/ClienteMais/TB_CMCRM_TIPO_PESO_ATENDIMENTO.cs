using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PESO_ATENDIMENTO
{
    public int ID_TIPO_PESO_ATENDIMENTO { get; set; }

    public string DS_TIPO_PESO_ATENDIMENTO { get; set; } = null!;

    public string? HX_COR_PESO_ATENDIMENTO { get; set; }

    public bool? FL_ALERTA_NOTIFICACAO { get; set; }

    public string? DS_ICON_PESO_ATENDIMENTO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_TIPO_CASO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();
}
