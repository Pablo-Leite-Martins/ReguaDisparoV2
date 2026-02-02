using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_NOTIFICACAO_EMAIL_SLA_SLO
{
    public int ID_NOTIFICACAO_EMAIL_SLA_SLO { get; set; }

    public int ID_CASO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int? ID_USUARIO_ACOMPANHAMENTO { get; set; }

    public bool? FL_SLA { get; set; }

    public bool? FL_SLO { get; set; }

    public int? ID_ETAPA_ETIPO_CASO { get; set; }
}
