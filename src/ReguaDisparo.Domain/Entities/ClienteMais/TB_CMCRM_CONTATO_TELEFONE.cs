using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTATO_TELEFONE
{
    public int ID_CONTATO_TELEFONE { get; set; }

    public int ID_CONTATO { get; set; }

    public int ID_TIPO_TELEFONE { get; set; }

    public string NR_TELEFONE { get; set; } = null!;

    public string? COD_DDI { get; set; }

    public string? COD_DDD { get; set; }

    public int? NR_RAMAL { get; set; }

    public string? DS_OBS { get; set; }

    public bool? FL_HOT_NUMBER { get; set; }
}
