using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_LOG
{
    public int ID_ETL_LOG { get; set; }

    public int ID_ETL { get; set; }

    public DateTime DT_HORARIO { get; set; }

    public string DS_LOG_EXECUCAO { get; set; } = null!;

    public bool FL_ERRO { get; set; }
}
