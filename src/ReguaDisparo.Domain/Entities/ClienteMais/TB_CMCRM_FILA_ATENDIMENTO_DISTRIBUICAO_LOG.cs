using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOG
{
    public int ID_FILA_ATENDIMENTO_DISTRIBUICAO_LOG { get; set; }

    public int ID_FILA_ATENDIMENTO { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_CONTA { get; set; }

    public string? ID_LIGACAO { get; set; }

    public DateTime DT_DISTRIBUICAO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_FILA_ATENDIMENTO ID_FILA_ATENDIMENTONavigation { get; set; } = null!;
}
