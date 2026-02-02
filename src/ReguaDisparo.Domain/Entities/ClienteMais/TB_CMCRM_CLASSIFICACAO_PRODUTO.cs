using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CLASSIFICACAO_PRODUTO
{
    public int ID_CLASSIFICACAO_PRODUTO { get; set; }

    public string DS_CLASSIFICACAO_PRODUTO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_PRODUTO> TB_CMCRM_PRODUTOs { get; set; } = new List<TB_CMCRM_PRODUTO>();
}
