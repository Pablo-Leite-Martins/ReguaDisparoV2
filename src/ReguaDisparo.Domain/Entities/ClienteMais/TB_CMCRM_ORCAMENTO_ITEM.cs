using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORCAMENTO_ITEM
{
    public int ID_ORCAMENTO_ITEM { get; set; }

    public int ID_ORCAMENTO { get; set; }

    public int ID_TIPO_SERVICO { get; set; }

    public decimal VL_MATERIAL { get; set; }

    public decimal VL_SERVICO { get; set; }

    public string? DS_LOCAL { get; set; }

    public virtual TB_CMCRM_ORCAMENTO ID_ORCAMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_SERVICO ID_TIPO_SERVICONavigation { get; set; } = null!;
}
