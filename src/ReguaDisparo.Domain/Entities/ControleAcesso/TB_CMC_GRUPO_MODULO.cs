using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_MODULO
{
    public int ID_GRUPO_SISTEMA { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_MODULO { get; set; }

    public virtual TB_CMC_GRUPO ID_GRUPONavigation { get; set; } = null!;

    public virtual TB_CMC_MODULO ID_MODULONavigation { get; set; } = null!;
}
