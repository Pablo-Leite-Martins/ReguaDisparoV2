using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_URA_TELEFONE
{
    public int ID_RAMAL { get; set; }

    public string? NR_RAMAL { get; set; }

    public int? ID_USUARIO { get; set; }

    public string? DS_STATUS { get; set; }

    public DateTime? DT_OCUPACAO { get; set; }
}
