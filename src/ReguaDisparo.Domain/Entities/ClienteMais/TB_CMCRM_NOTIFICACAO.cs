using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_NOTIFICACAO
{
    public int ID_NOTIFICACAO { get; set; }

    public string DS_NOTIFICACAO { get; set; } = null!;

    public DateTime DT_CRIACAO { get; set; }

    public DateTime? DT_LEITURA { get; set; }

    public bool FL_LIDO { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_TIPO_NOTIFICACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public int? ID_USUARIO_ANTERIOR { get; set; }

    public int? ID_USUARIO_ACAO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_NOTIFICACAO? ID_TIPO_NOTIFICACAONavigation { get; set; }
}
