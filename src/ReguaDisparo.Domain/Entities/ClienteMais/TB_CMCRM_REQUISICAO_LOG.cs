using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_REQUISICAO_LOG
{
    public int ID_REQUISICAO_LOG { get; set; }

    public string DS_INTEGRACAO { get; set; } = null!;

    public string DS_CHAMADA { get; set; } = null!;

    public string DS_BODY { get; set; } = null!;

    public string? DS_ERRO { get; set; }

    public string? DS_STACK_TRACE { get; set; }

    public DateTime DT_REGISTRO { get; set; }

    public int? ID_USUARIO { get; set; }
}
