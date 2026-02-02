using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_CARTA_MR
{
    public int ID_MODELO_CARTA_MRS { get; set; }

    public int ID_CARTA { get; set; }

    public string DS_CARTA { get; set; } = null!;
}
