using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_CONSULTA_UAUCLOUD_PARAMETRO
{
    public int ID_CONSULTA_UAUCLOUD_PARAMETRO { get; set; }

    public int ID_CONSULTA_UAUCLOUD { get; set; }

    public string DS_PARAMETRO { get; set; } = null!;

    public string? DS_CAMPO { get; set; }

    public virtual TB_CMCORP_CONSULTA_UAUCLOUD ID_CONSULTA_UAUCLOUDNavigation { get; set; } = null!;
}
