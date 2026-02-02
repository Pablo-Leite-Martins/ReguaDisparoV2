using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RESPOSTAS_CHAT
{
    public int ID_RESPOSTA_CHAT { get; set; }

    public string DS_RESPOSTA_CHAT { get; set; } = null!;

    public int ID_CATEGORIA_RESPOSTA_CHAT { get; set; }

    public virtual TB_CMCRM_CATEGORIA_RESPOSTAS_CHAT ID_CATEGORIA_RESPOSTA_CHATNavigation { get; set; } = null!;
}
