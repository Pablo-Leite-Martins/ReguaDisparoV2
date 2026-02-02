using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_PESQUISA_SATISFACAO
{
    public string ID_GUID { get; set; } = null!;

    public int? ID_CASO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public bool? FL_VISUALIZADO { get; set; }

    public DateTime? DT_REENVIO { get; set; }

    public int? ID_CONTA_CHAT { get; set; }

    public virtual TB_CMCRM_CONTA_CHAT? ID_CONTA_CHATNavigation { get; set; }
}
