using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_SERVICO
{
    public int ID_TIPO_SERVICO { get; set; }

    public string DS_TIPO_SERVICO { get; set; } = null!;

    public decimal? VL_MATERIAL { get; set; }

    public decimal? VL_SERVICO { get; set; }

    public virtual ICollection<TB_CMCRM_ORCAMENTO_ITEM> TB_CMCRM_ORCAMENTO_ITEMs { get; set; } = new List<TB_CMCRM_ORCAMENTO_ITEM>();
}
