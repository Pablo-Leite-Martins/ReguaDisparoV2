using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA_LOG
{
    public int ID_COMUNICADO_AGENDAMENTO_AUDIENCIA_LOG { get; set; }

    public int ID_COMUNICADO_AGENDAMENTO_AUDIENCIA { get; set; }

    public int ID_CONTATO { get; set; }

    public DateTime? DT_EXECUCAO { get; set; }

    public bool FL_ENVIADO { get; set; }

    public virtual TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIum ID_COMUNICADO_AGENDAMENTO_AUDIENCIANavigation { get; set; } = null!;
}
