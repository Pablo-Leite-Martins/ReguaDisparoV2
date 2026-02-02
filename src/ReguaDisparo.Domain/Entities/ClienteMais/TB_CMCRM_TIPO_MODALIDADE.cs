using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_MODALIDADE
{
    public int ID_TIPO_MODALIDADE { get; set; }

    public string? DS_TIPO_MODALIDADE { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_REPASSE_DADO> TB_CMCRM_CASO_REPASSE_DADOs { get; set; } = new List<TB_CMCRM_CASO_REPASSE_DADO>();
}
