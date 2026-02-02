using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_LOG_ERRO_APLICACAO
{
    public int ID_ERRO { get; set; }

    public string? ID_ORGANIZACAO { get; set; }

    public int? ID_SISTEMA { get; set; }

    public string? DS_ERRO { get; set; }

    public string? DS_SOURCE { get; set; }

    public string? DS_INNER_EX { get; set; }

    public string? DS_LOGIN { get; set; }

    public string? DS_PAGINA { get; set; }

    public string? DS_PILHA_EX { get; set; }

    public DateTime? DT_ERRO { get; set; }
}
