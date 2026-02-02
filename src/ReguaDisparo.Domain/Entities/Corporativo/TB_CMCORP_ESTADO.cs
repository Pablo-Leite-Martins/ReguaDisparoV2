using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ESTADO
{
    public int ID_ESTADO { get; set; }

    public string DS_SIGLA { get; set; } = null!;

    public string DS_ESTADO { get; set; } = null!;

    public int ID_PAIS { get; set; }

    public virtual TB_CMCORP_PAI ID_PAISNavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_CIDADE> TB_CMCORP_CIDADEs { get; set; } = new List<TB_CMCORP_CIDADE>();
}
