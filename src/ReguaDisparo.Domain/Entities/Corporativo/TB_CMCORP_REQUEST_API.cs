using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_REQUEST_API
{
    public long ID_REQUEST_API { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public DateTime DT_REQUEST { get; set; }

    public string DS_REQUEST_URL { get; set; } = null!;

    public string DS_REQUEST_AUTHORITY { get; set; } = null!;

    public string DS_REQUEST_PATH { get; set; } = null!;

    public string DS_REQUEST_QUERY { get; set; } = null!;

    public long NR_TAMANHO { get; set; }

    public virtual TB_CMCORP_ORGANIZACAO ID_ORGANIZACAONavigation { get; set; } = null!;
}
