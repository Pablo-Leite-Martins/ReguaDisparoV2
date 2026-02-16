using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ETAPA_JORNADA
{
    public int ID_ETAPA_JORNADA { get; set; }

    public string DS_ETAPA_JORNADA { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public string? HX_COR_PERFIL_ETAPA_JORNADA { get; set; }

    public string? DS_ICON_PERFIL_ETAPA_JORNADA { get; set; }

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO> TB_CMCRM_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_PRODUTO> TB_CMCRM_PRODUTOs { get; set; } = new List<TB_CMCRM_PRODUTO>();
}
