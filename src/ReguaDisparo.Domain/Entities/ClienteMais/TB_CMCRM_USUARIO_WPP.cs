using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_USUARIO_WPP
{
    public int ID_USUARIO_WPP { get; set; }

    public int ID_USUARIO { get; set; }

    public string NR_TELEFONE_WPP { get; set; } = null!;

    public string? COD_DDD { get; set; }

    public string? COD_DDI { get; set; }
}
