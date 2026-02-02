using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_CARTEIRA
{
    public int ID_CARTEIRA { get; set; }

    public string DS_CARTEIRA { get; set; } = null!;

    public int? NR_ORDEM { get; set; }
}
