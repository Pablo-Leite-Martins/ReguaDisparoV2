using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_NOTIFICACAO
{
    public int ID_TIPO_NOTIFICACAO { get; set; }

    public string DS_TIPO_NOTIFICACAO { get; set; } = null!;

    public int ID_SISTEMA { get; set; }

    public virtual ICollection<TB_CMCRM_NOTIFICACAO> TB_CMCRM_NOTIFICACAOs { get; set; } = new List<TB_CMCRM_NOTIFICACAO>();

    public virtual ICollection<TB_CMCRM_TIPO_NOTIFICACAO_USUARIO> TB_CMCRM_TIPO_NOTIFICACAO_USUARIOs { get; set; } = new List<TB_CMCRM_TIPO_NOTIFICACAO_USUARIO>();
}
