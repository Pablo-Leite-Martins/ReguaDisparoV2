using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CUSTO_PREVISTO_VGV
{
    public int ID_CUSTO_PREVISTO_VGV { get; set; }

    public int? ID_MES { get; set; }

    public int? ID_ANO { get; set; }

    public int? ID_RESIDENCIAL { get; set; }

    public virtual ICollection<TB_CMCRM_CUSTO_PREVISTO_VL> TB_CMCRM_CUSTO_PREVISTO_VLs { get; set; } = new List<TB_CMCRM_CUSTO_PREVISTO_VL>();
}
