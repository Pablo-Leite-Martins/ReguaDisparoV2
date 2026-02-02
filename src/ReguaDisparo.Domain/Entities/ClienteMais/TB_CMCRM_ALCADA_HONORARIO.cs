using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_HONORARIO
{
    public int ID_ALCADA_HONORARIO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public decimal NUM_PERCENTUAL_HONORARIO { get; set; }

    public int? ID_GRUPO { get; set; }
}
