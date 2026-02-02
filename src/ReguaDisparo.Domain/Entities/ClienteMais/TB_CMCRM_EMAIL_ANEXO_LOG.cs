using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_ANEXO_LOG
{
    public int ID_EMAIL_ANEXO { get; set; }

    public int ID_EMAIL { get; set; }

    public string DS_LINK_DRIVE { get; set; } = null!;

    public string? DS_DOCUMENTO { get; set; }

    public string? DS_TIPO { get; set; }

    public DateTime DT_EXCLUSAO { get; set; }

    public int? ID_USUARIO_EXCLUSAO { get; set; }
}
