using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_LOG
{
    public int ID_PRODUTO_LOG { get; set; }

    public string DS_PRODUTO_LOG { get; set; } = null!;

    public DateTime DT_PRODUTO_LOG { get; set; }

    public int ID_PRODUTO { get; set; }

    public int? ID_USUARIO { get; set; }
}
