using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_FINANCEIRO_CONTum
{
    public int ID_PERFIL_FINANCEIRO_CONTA { get; set; }

    public string DS_PERFIL_FINANCEIRO_CONTA { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public string? HX_COR_PERFIL_FINANCEIRO_CONTA { get; set; }

    public string? DS_ICON_PERFIL_FINANCEIRO_CONTA { get; set; }

    public virtual ICollection<TB_CMCRM_CONTum> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTum>();
}
