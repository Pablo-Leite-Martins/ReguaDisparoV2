using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_LOG_USUARIO
{
    public int ID_ETL_LOG_USUARIO { get; set; }

    public DateTime DT_EXECUCAO { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_ETL { get; set; }

    public virtual TB_CMCORP_ETL ID_ETLNavigation { get; set; } = null!;
}
