using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_FUNCAO
{
    public int ID_FUNCAO { get; set; }

    public string NM_FUNCAO { get; set; } = null!;

    public string DS_FUNCAO { get; set; } = null!;

    public int? ID_SISTEMA { get; set; }

    public virtual TB_CMC_SISTEMA? ID_SISTEMANavigation { get; set; }

    public virtual ICollection<TB_CMC_GRUPO_FUNCAO> TB_CMC_GRUPO_FUNCAOs { get; set; } = new List<TB_CMC_GRUPO_FUNCAO>();
}
