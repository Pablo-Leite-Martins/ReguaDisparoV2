using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FILA_ATENDIMENTO_USUARIO
{
    public int ID_FILA_ATENDIMENTO_USUARIO { get; set; }

    public int ID_FILA_ATENDIMENTO { get; set; }

    public int ID_USUARIO { get; set; }

    public bool FL_ULTIMO { get; set; }

    public int NR_ORDEM { get; set; }

    public virtual TB_CMCRM_FILA_ATENDIMENTO ID_FILA_ATENDIMENTONavigation { get; set; } = null!;
}
