using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_KIT_UNIDADE
{
    public int ID_KIT_UNIDADE { get; set; }

    public decimal VL_PRECO { get; set; }

    public int ID_KIT { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_KIT ID_KITNavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
