using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CUSTO
{
    public int ID_CUSTOS { get; set; }

    public int? ID_MES { get; set; }

    public int? ID_ANO { get; set; }

    public int ID_OFICIAL_FUNCIONARIO { get; set; }

    public decimal? VL_FINAL { get; set; }

    public string? DS_PRACA { get; set; }
}
