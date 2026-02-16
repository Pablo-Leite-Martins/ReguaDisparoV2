using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTA_CONTA
{
    public int ID_PROPOSTA_CONTA { get; set; }

    public int ID_PROPOSTA { get; set; }

    public int ID_CONTA { get; set; }

    public decimal VL_PARTICIPACAO { get; set; }

    public bool? FL_CLIENTE_PRINCIPAL { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_PROPOSTA ID_PROPOSTANavigation { get; set; } = null!;
}
