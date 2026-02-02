using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_DESCONTO_20220916
{
    public int ID_ALCADA_DESCONTO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int NUM_PERCENTUAL_MULTA { get; set; }

    public int NUM_PERCENTUAL_JUROS { get; set; }

    public int? NUM_MINIMO_PARCELAS { get; set; }

    public int? NR_INICIO_AGING { get; set; }

    public int? NR_FIM_AGING { get; set; }

    public int ID_GRUPO { get; set; }
}
