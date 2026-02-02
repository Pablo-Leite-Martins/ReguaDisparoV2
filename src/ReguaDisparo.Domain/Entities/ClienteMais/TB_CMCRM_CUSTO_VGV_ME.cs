using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CUSTO_VGV_ME
{
    public int ID_CUSTO_VGV_MES { get; set; }

    public int? ID_MES { get; set; }

    public int? ID_ANO { get; set; }

    public int? ID_PRACA { get; set; }

    public string? DS_PRACA { get; set; }

    public decimal? VL_VENDA { get; set; }
}
