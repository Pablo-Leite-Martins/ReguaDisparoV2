using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTO
{
    public int ID_ORIGEM_LEAD_FILA_ATENDIMENTO { get; set; }

    public int ID_ORIGEM_LEAD { get; set; }

    public int ID_FILA_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_FILA_ATENDIMENTO ID_FILA_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ORIGEM_LEAD ID_ORIGEM_LEADNavigation { get; set; } = null!;
}
