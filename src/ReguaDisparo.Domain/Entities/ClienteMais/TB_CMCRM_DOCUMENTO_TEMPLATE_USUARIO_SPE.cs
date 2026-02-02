using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_USUARIO_SPE
{
    public int ID_DOCUMENTO_TEMPLATE_USUARIO_SPE { get; set; }

    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public int ID_USUARIO_SPE { get; set; }
}
