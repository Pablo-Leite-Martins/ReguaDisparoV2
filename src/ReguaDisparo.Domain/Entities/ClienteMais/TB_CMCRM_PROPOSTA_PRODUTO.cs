using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTA_PRODUTO
{
    public int ID_PROPOSTA_PRODUTO { get; set; }

    public int ID_PROPOSTA { get; set; }

    public int ID_PRODUTO { get; set; }

    public decimal VL_PRECO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PROPOSTA ID_PROPOSTANavigation { get; set; } = null!;
}
