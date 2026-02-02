using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_ETAPA
{
    public int ID_PRODUTO_ETAPA { get; set; }

    public int ID_ETAPA_TIPO_CASO { get; set; }

    public int ID_PRODUTO { get; set; }

    public string? CD_ETAPA { get; set; }
}
