using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_ALCADA_CONFIGURACAO
{
    public int ID_ALCADA_CONFIGURACAO { get; set; }

    public int? ID_USUARIO { get; set; }

    public int ID_ALCADA { get; set; }

    public decimal VL_ALCADA_MINIMO { get; set; }

    public decimal VL_ALCADA_MAXIMO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool? FL_PORCENTAGEM { get; set; }

    public int? ID_PRODUTO { get; set; }

    public virtual TB_CMC_ALCADum ID_ALCADANavigation { get; set; } = null!;

    public virtual TB_CMC_USUARIO? ID_USUARIONavigation { get; set; }
}
