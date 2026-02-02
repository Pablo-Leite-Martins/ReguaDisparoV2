using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INVESTIMENTO_MARKETING
{
    public int ID_MARKETING { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public string? DS_MARKETING { get; set; }

    public DateOnly? DT_REFERENCIA { get; set; }

    public decimal? VL_INVESTIMENTO { get; set; }
}
