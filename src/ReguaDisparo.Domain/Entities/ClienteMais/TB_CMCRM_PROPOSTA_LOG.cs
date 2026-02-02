using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTA_LOG
{
    public int ID_PROPOSTA_LOG { get; set; }

    public string DS_PROPOSTA_LOG { get; set; } = null!;

    public DateTime DT_PROPOSTA_LOG { get; set; }

    public int ID_PROPOSTA { get; set; }

    public int? ID_USUARIO { get; set; }

    public virtual TB_CMCRM_PROPOSTum ID_PROPOSTANavigation { get; set; } = null!;
}
