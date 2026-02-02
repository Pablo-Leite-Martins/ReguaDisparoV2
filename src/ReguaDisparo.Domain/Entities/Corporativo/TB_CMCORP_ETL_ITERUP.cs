using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_ITERUP
{
    public int ID_ETL_ITERUP { get; set; }

    public int? ID_ETL { get; set; }

    public string? DS_USUARIO { get; set; }

    public string? DS_SENHA { get; set; }

    public virtual TB_CMCORP_ETL? ID_ETLNavigation { get; set; }
}
