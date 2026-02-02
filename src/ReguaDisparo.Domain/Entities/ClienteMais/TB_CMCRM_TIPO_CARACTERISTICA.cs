using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_CARACTERISTICA
{
    public int ID_TIPO_CARACTERISTICA { get; set; }

    public string DS_TIPO_CARACTERISTICA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_PRODUTO_TIPO_CARACTERISTICA> TB_CMCRM_PRODUTO_TIPO_CARACTERISTICAs { get; set; } = new List<TB_CMCRM_PRODUTO_TIPO_CARACTERISTICA>();
}
