using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AREA_COMUM_INTERESSE
{
    public int ID_AREA_COMUM_INTERESSE { get; set; }

    public int ID_AREA_COMUM { get; set; }

    public int ID_INTERESSE_CONTA_PRODUTO { get; set; }

    public virtual TB_CMCRM_AREA_COMUM ID_AREA_COMUMNavigation { get; set; } = null!;

    public virtual TB_CMCRM_INTERESSE_CONTA_PRODUTO ID_INTERESSE_CONTA_PRODUTONavigation { get; set; } = null!;
}
