using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_USUARIO_PREFERENCIA
{
    public int ID_USUARIO { get; set; }

    public string DS_PREFERENCIA { get; set; } = null!;

    public string VL_PREFERENCIA { get; set; } = null!;

    public virtual TB_CMC_USUARIO ID_USUARIONavigation { get; set; } = null!;
}
