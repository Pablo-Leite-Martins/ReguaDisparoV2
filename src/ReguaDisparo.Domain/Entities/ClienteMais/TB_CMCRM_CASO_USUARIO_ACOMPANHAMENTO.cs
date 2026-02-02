using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_USUARIO_ACOMPANHAMENTO
{
    public int ID_CASO_USUARIO_ACOMPANHAMENTO { get; set; }

    public int ID_CASO { get; set; }

    public int ID_USUARIO { get; set; }
}
