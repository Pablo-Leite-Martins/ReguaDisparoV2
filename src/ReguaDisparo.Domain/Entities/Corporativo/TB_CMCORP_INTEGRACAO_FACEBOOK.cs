using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_INTEGRACAO_FACEBOOK
{
    public int ID_INTEGRACAO_FACEBOOK { get; set; }

    public string ID_PAGINA { get; set; } = null!;

    public string ID_FORMULARIO { get; set; } = null!;

    public string DS_TOKEN { get; set; } = null!;

    public DateTime DT_VALIDADE_TOKEN { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;
}
