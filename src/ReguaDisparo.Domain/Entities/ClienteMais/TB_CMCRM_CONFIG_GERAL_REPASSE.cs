using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIG_GERAL_REPASSE
{
    public int ID_CONFIG_GERAL_REPASSE { get; set; }

    public string DS_CONFIGURACAO { get; set; } = null!;

    public string VL_CONFIGURACAO { get; set; } = null!;

    public string? VL_ITEM_CONFIGURACAO { get; set; }

    public string? DS_CATEGORIA_CONFIGURACAO { get; set; }

    public string? DS_OBSERVACAO { get; set; }
}
