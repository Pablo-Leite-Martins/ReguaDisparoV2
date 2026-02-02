using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_RENEGOCIACAO_GRUPO
{
    public int ID_MODELO_RENEGOCIACAO_GRUPO { get; set; }

    public int ID_MODELO_RENEGOCIACAO { get; set; }

    public int ID_GRUPO { get; set; }

    public int? ID_USUARIO { get; set; }

    public string DS_MODELO_RENEGOCIACAO { get; set; } = null!;
}
