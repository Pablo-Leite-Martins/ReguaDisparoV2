using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_MOTVO_INADIMPLENCIA
{
    public int ID_CASO_COBRANCA_MOTVO_INADIMPLENCIA { get; set; }

    public string DS_MOTIVO_INADIMPLENCIA { get; set; } = null!;
}
