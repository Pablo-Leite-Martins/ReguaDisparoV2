using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO_HISTORICO_CHAMADA_API
{
    public int ID_HISTORICO { get; set; }

    public int? ID_TIPO_INTEGRACAO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public DateTime DT_ACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public int? ID_CASO { get; set; }

    public string? DS_TOKEN_EMPRESA { get; set; }

    public string? DS_KEY_EMPRESA { get; set; }

    public string DS_AGENTE { get; set; } = null!;

    public string DS_URL_API { get; set; } = null!;

    public string DS_RESPOSTA_API { get; set; } = null!;
}
