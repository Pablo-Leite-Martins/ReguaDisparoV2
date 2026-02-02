using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CUSTO_PREVISTO_VL
{
    public int ID_CUSTO_PREVISTO_PREVISTO_VL { get; set; }

    public int? ID_CUSTO_PREVISTO_VGV { get; set; }

    public decimal? VL_CUSTO_PREVISTO_1_8_PERC { get; set; }

    public decimal? VL_CUSTO_PREVISTO_1_5_PERC { get; set; }

    public decimal? VL_CUSTO_PREVISTO_1_0_PERC { get; set; }

    public virtual TB_CMCRM_CUSTO_PREVISTO_VGV? ID_CUSTO_PREVISTO_VGVNavigation { get; set; }
}
