using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AREA_COMUM_PRODUTO
{
    public int ID_AREA_COMUM_PRODUTO { get; set; }

    public int ID_AREA_COMUM { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_AREA_COMUM ID_AREA_COMUMNavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
