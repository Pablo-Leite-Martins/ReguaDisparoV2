using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_GRUPO
{
    public int ID_PRODUTO_GRUPO { get; set; }

    public int ID_PRODUTO { get; set; }

    public int ID_GRUPO { get; set; }
}
