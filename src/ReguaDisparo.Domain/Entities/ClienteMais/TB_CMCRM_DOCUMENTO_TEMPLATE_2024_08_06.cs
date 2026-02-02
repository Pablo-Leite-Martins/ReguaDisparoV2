using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_2024_08_06
{
    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public string DS_DOCUMENTO { get; set; } = null!;

    public string DS_TEMPLATE { get; set; } = null!;

    public int ID_TIPO_DOCUMENTO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool? FL_CONTRATO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public string? DS_ASSUNTO { get; set; }

    public int? ID_TIPO_PRODUTO { get; set; }

    public int? ID_ESTRUTURA_COMISSAO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_TIPO_INTEGRACAO { get; set; }

    public string? DS_TIPO_TEMPLATE { get; set; }
}
