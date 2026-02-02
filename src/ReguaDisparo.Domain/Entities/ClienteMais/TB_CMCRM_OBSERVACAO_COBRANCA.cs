using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_OBSERVACAO_COBRANCA
{
    public int ID_OBSERVACAO_COBRANCA { get; set; }

    public string DS_OBSERVACAO_COBRANCA { get; set; } = null!;

    public int? NR_MIN_AGING { get; set; }

    public int? NR_MAX_AGING { get; set; }
}
