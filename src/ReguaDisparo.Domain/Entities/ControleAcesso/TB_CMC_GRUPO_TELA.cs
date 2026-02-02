using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_TELA
{
    public int ID_GRUPO_TELA { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_TELA { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public virtual TB_CMC_GRUPO ID_GRUPONavigation { get; set; } = null!;

    public virtual TB_CMC_TELA ID_TELANavigation { get; set; } = null!;
}
