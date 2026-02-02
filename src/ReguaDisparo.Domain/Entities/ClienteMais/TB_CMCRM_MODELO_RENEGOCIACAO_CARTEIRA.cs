using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_RENEGOCIACAO_CARTEIRA
{
    public int ID_MODELO_RENEGOCIACAO_CARTEIRA { get; set; }

    public int ID_MODELO_RENEGOCIACAO { get; set; }

    public int ID_CARTEIRA { get; set; }

    public string? DS_MODELO_RENEGOCIACAO { get; set; }
}
