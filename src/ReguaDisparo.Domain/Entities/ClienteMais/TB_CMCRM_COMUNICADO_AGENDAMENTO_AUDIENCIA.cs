using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA
{
    public int ID_COMUNICADO_AGENDAMENTO_AUDIENCIA { get; set; }

    public int ID_COMUNICADO_AGENDAMENTO { get; set; }

    public int ID_AUDIENCIA { get; set; }

    public virtual TB_CMCRM_COMUNICADO_AGENDAMENTO ID_COMUNICADO_AGENDAMENTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA_LOG> TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA_LOGs { get; set; } = new List<TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA_LOG>();
}
