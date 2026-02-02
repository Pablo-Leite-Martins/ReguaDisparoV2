using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIG_MODELO_RENEGOCIACAO
{
    public int ID_CONFIG_MODELO_RENEGOCIACAO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string DS_OBRA { get; set; } = null!;

    public string? DS_INDICE { get; set; }

    public DateTime DT_UTILIZADA { get; set; }
}
