using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_LOG
{
    public int ID_CONTA_LOG { get; set; }

    public string DS_CONTA_LOG { get; set; } = null!;

    public DateTime DT_CONTA_LOG { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_USUARIO { get; set; }
}
