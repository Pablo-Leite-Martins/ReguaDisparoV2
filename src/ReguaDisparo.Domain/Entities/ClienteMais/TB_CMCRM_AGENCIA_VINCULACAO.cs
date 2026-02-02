using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AGENCIA_VINCULACAO
{
    public int ID_AGENCIA_VINCULACAO { get; set; }

    public string? DS_AGENCIA_VINCULACAO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_REPASSE_DADO> TB_CMCRM_CASO_REPASSE_DADOs { get; set; } = new List<TB_CMCRM_CASO_REPASSE_DADO>();
}
