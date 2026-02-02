using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_FUNCAO_20230119
{
    public int ID_GRUPO_FUNCAO { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_FUNCAO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;
}
