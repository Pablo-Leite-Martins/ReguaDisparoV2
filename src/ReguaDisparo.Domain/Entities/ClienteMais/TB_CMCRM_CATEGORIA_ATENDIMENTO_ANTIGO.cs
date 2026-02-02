using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_ATENDIMENTO_ANTIGO
{
    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public string DS_CATEGORIA_ATENDIMENTO { get; set; } = null!;

    public int? ID_CATEGORIA_ATENDIMENTO_PAI { get; set; }

    public int? NR_SLA { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO_COMP { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? NR_GARANTIA_MESES { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? NR_GARANTIA_MESES_NOVA { get; set; }

    public int? NR_SLA_AREA_COMUM { get; set; }

    public bool? FL_ATIVO_PORTAL { get; set; }

    public int? NR_URGENCIA { get; set; }

    public int? NR_IMPACTO { get; set; }

    public string? DS_MENSAGEM_ORIENTATIVA { get; set; }

    public bool? FL_BLOCK_ABERTURA_ATENDIMENTO_CONTA_PRODUTO_CATEGORIA { get; set; }
}
