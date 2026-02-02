using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ORGANIZACAO_FASE_IMPLANTACAO
{
    public int ID_ORGANIZACAO_FASE_IMPLANTACAO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string? DS_RAZAO_SOCIAL { get; set; }

    public int ID_PRODUTO_CAPYS { get; set; }

    public string? DS_PRODUTO_CAPYS { get; set; }

    public int ID_FASE_IMPLANTACAO { get; set; }

    public string? DS_FASE_IMPLANTACAO { get; set; }

    public string? DS_NOME_RESPONSAVEL_TI { get; set; }

    public string? DS_EMAIL_RESPONSAVEL_TI { get; set; }

    public string? DS_NOME_RESPONSAVEL_NEGOCIO { get; set; }

    public string? DS_EMAIL_RESPONSAVEL_NEGOCIO { get; set; }

    public string? DS_NOME_RESPONSAVEL_IMPLANTACAO { get; set; }

    public DateTime? DT_INICIO_PROJETO { get; set; }
}
