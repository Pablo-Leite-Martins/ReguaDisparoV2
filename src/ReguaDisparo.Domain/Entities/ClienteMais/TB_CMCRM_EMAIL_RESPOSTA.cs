using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_RESPOSTA
{
    public int ID_EMAIL_RESPOSTA { get; set; }

    public int ID_EMAIL_RESPONDIDO { get; set; }

    public string DS_ASSUNTO { get; set; } = null!;

    public string DS_REMETENTE { get; set; } = null!;

    public string DS_DESTINATARIO { get; set; } = null!;

    public string DS_MENSAGEM { get; set; } = null!;

    public DateTime DT_ENVIO { get; set; }

    public string? DS_COPIA { get; set; }

    public virtual TB_CMCRM_EMAIL ID_EMAIL_RESPONDIDONavigation { get; set; } = null!;
}
