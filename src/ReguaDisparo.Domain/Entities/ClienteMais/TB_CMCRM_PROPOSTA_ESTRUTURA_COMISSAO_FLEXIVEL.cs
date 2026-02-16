using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL
{
    public int ID_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; }

    public int ID_PROPOSTA { get; set; }

    public int ID_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; }

    public int ID_CARGO_USUARIO { get; set; }

    public decimal? VL_PERCENTUAL { get; set; }

    public decimal? VL_COMISSAO { get; set; }

    public bool FL_DIRETA { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL ID_ESTRUTURA_COMISSAO_FLEXIVELNavigation { get; set; } = null!;

    public virtual TB_CMCRM_PROPOSTA ID_PROPOSTANavigation { get; set; } = null!;
}
