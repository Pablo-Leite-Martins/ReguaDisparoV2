using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_TELEFONE
{
    public int ID_CONTA_TELEFONE { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_TIPO_TELEFONE { get; set; }

    public string NR_TELEFONE { get; set; } = null!;

    public string? COD_DDI { get; set; }

    public string? COD_DDD { get; set; }

    public int? NR_RAMAL { get; set; }

    public string? DS_OBS { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;
}
