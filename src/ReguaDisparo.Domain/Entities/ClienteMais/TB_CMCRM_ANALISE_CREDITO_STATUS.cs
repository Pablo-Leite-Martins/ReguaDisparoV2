using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ANALISE_CREDITO_STATUS
{
    public int ID_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_ANALISE_CREDITO_STATUS { get; set; }

    public virtual ICollection<TB_CMCRM_ANALISE_CREDITO> TB_CMCRM_ANALISE_CREDITOs { get; set; } = new List<TB_CMCRM_ANALISE_CREDITO>();
}
