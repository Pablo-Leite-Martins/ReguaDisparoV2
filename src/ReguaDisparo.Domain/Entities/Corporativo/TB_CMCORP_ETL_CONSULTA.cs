using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_CONSULTA
{
    public int ID_ETL_CONSULTAS { get; set; }

    public string DS_NOME_CONSULTA { get; set; } = null!;

    public string DS_SQL_CONSULTA { get; set; } = null!;

    public int ID_ETL { get; set; }
}
