using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_HONORARIO_20220929
{
    public int ID_ALCADA_HONORARIO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int NUM_PERCENTUAL_HONORARIO { get; set; }

    public int? ID_GRUPO { get; set; }
}
