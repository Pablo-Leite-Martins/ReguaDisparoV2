using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_LOG_AUDIT
{
    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public DateTime DT_MODIFICACAO { get; set; }

    public string DS_DOCUMENTO_ORIGINAL { get; set; } = null!;

    public string? DS_TEMPLATE_ORIGINAL { get; set; }

    public int ID_TIPO_DOCUMENTO_ORIGINAL { get; set; }

    public int? ID_ETAPA_TIPO_CASO_ORIGINAL { get; set; }

    public bool? FL_CONTRATO_ORIGINAL { get; set; }

    public int? ID_PRODUTO_ORIGINAL { get; set; }

    public string? DS_ASSUNTO_ORIGINAL { get; set; }

    public int? ID_TIPO_PRODUTO_ORIGINAL { get; set; }

    public int? ID_ESTRUTURA_COMISSAO_ORIGINAL { get; set; }

    public bool FL_ATIVO_ORIGINAL { get; set; }

    public string DS_DOCUMENTO_NOVO { get; set; } = null!;

    public string? DS_TEMPLATE_NOVO { get; set; }

    public int ID_TIPO_DOCUMENTO_NOVO { get; set; }

    public int? ID_ETAPA_TIPO_CASO_NOVO { get; set; }

    public bool? FL_CONTRATO_NOVO { get; set; }

    public int? ID_PRODUTO_NOVO { get; set; }

    public string? DS_ASSUNTO_NOVO { get; set; }

    public int? ID_TIPO_PRODUTO_NOVO { get; set; }

    public int? ID_ESTRUTURA_COMISSAO_NOVO { get; set; }

    public bool FL_ATIVO_NOVO { get; set; }
}
