using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_TIPO_CONTA
{
    public int ID_PERFIL_TIPO_CONTA { get; set; }

    public string DS_PERFIL_TIPO_CONTA { get; set; } = null!;

    public string? HX_COR_PERFIL_TIPO_CONTA { get; set; }

    public string? DS_ICON_PERFIL_TIPO_CONTA { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual ICollection<TB_CMCRM_CONTA> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTA>();
}
