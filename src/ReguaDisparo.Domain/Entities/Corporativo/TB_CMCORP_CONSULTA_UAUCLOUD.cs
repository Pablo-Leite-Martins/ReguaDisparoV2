using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_CONSULTA_UAUCLOUD
{
    public int ID_CONSULTA_UAUCLOUD { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string DS_CONSULTA { get; set; } = null!;

    public string ID_CONSULTA_UAU { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO> TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETROs { get; set; } = new List<TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO>();
}
