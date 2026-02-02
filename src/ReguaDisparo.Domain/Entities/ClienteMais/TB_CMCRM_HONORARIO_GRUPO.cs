using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_HONORARIO_GRUPO
{
    public int ID_HONORARIO_GRUPO { get; set; }

    public int ID_GRUPO { get; set; }

    public decimal NR_PERCENTUAL_HONORARIO { get; set; }

    public bool? FL_CONTROLA_COLCHAO { get; set; }
}
