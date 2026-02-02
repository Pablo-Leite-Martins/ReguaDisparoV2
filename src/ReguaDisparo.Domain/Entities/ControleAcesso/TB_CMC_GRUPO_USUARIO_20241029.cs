using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_USUARIO_20241029
{
    public int ID_GRUPO_USUARIO { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_USUARIO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;
}
