using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_USUARIO_TELEFONE
{
    public int ID_USUARIO_TELEFONE { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_TIPO_TELEFONE { get; set; }

    public string NR_TELEFONE { get; set; } = null!;

    public string? COD_DDI { get; set; }

    public string? COD_DDD { get; set; }

    public int? NR_RAMAL { get; set; }

    public string? DS_OBS { get; set; }

    public virtual TB_CMC_USUARIO ID_USUARIONavigation { get; set; } = null!;
}
