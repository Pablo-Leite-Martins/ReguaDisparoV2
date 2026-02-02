using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO_URA
{
    public string NR_CPF { get; set; } = null!;

    public int ID_TIPO_CASO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public int ID_RAMAL { get; set; }
}
