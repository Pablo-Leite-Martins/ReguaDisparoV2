using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_CHAT_HISTORICO
{
    public int ID_CONTA_CHAT_HISTORICO { get; set; }

    public int ID_CONTA_CHAT { get; set; }

    public string DS_HISTORICO { get; set; } = null!;

    public string? DS_URL { get; set; }

    public string? DS_CONTENT_TYPE { get; set; }

    public DateTime DT_HISTORICO { get; set; }

    public bool FL_USUARIO { get; set; }

    public int? ID_USUARIO { get; set; }

    public bool? FL_SINC_UAU { get; set; }

    public virtual TB_CMCRM_CONTA_CHAT ID_CONTA_CHATNavigation { get; set; } = null!;
}
