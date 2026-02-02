using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_NOTIFICACAO_USUARIO
{
    public int ID_TIPO_NOTIFICACAO_USUARIO { get; set; }

    public int? ID_TIPO_NOTIFICACAO { get; set; }

    public int? ID_USUARIO { get; set; }

    public virtual TB_CMCRM_TIPO_NOTIFICACAO? ID_TIPO_NOTIFICACAONavigation { get; set; }
}
