using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MOTIVO_CANCELAMENTO
{
    public int ID_MOTIVO_CANCELAMENTO { get; set; }

    public string DS_MOTIVO_CANCELAMENTO { get; set; } = null!;

    public int? ID_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_TIPO_CASO? ID_TIPO_CASONavigation { get; set; }
}
