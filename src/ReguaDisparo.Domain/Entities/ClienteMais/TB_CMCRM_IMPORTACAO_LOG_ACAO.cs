using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_IMPORTACAO_LOG_ACAO
{
    public int? ID_IMPORTACAO_LOG { get; set; }

    public string? DS_TIPO { get; set; }

    public string? DS_ACAO { get; set; }

    public string? DS_RESULTADO { get; set; }
}
