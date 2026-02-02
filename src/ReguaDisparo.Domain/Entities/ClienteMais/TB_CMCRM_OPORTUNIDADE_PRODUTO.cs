using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_OPORTUNIDADE_PRODUTO
{
    public int ID_OPORTUNIDADE_PRODUTO { get; set; }

    public int ID_OPORTUNIDADE { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_OPORTUNIDADE ID_OPORTUNIDADENavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
