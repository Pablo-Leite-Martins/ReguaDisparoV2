using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ATENDIMENTO_CHAT
{
    public int ID_ATENDIMENTO_CHAT { get; set; }

    public string DS_NOME { get; set; } = null!;

    public int ID_ORIGEM_LEAD { get; set; }

    public int ID_USUARIO { get; set; }

    public bool FL_GEROU_LEAD { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? DS_HISTORICO { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;
}
