using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_HONORARIO_GRUPO
{
    public int ID_ALCADA_HONORARIO_GRUPO { get; set; }

    public decimal NR_PERCENTUAL_ALCADA_HONORARIO { get; set; }

    public int ID_GRUPO { get; set; }
}
