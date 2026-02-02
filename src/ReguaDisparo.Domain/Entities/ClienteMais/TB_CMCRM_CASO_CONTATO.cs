using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_CONTATO
{
    public int ID_CASO_CONTATO { get; set; }

    public int ID_CASO { get; set; }

    public int ID_CONTATO { get; set; }

    public int ID_TIPO_RELACAO_CLIENTE { get; set; }
}
