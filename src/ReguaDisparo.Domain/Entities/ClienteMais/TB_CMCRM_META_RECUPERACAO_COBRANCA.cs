using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_META_RECUPERACAO_COBRANCA
{
    public int ID_META_RECUPERACAO_COBRANCA { get; set; }

    public decimal VL_META { get; set; }

    public DateTime DT_META { get; set; }
}
