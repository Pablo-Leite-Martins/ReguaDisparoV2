using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMUNICADO_AGENDAMENTO
{
    public int ID_COMUNICADO_AGENDAMENTO { get; set; }

    public DateTime DT_AGENDAMENTO { get; set; }

    public int ID_TIPO_COMUNICADO { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public string? DS_MENSAGEM { get; set; }

    public string DS_ASSUNTO { get; set; } = null!;

    public bool FL_EXECUTADO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual ICollection<TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA> TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIa { get; set; } = new List<TB_CMCRM_COMUNICADO_AGENDAMENTO_AUDIENCIA>();
}
