using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_ASSINATURA
{
    public int ID_DOCUMENTO_ASSINATURA { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public int? ID_CASO_DOCUMENTO { get; set; }
}
