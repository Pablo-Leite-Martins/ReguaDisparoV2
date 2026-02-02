using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TRIAGEM_FILA_USUARIO
{
    public int ID_TRIAGEM_FILA_USUARIO { get; set; }

    public int ID_TRIAGEM_FILA { get; set; }

    public int ID_USUARIO { get; set; }

    public bool FL_ULTIMO { get; set; }

    public int NR_ORDEM { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_TRIAGEM_FILA ID_TRIAGEM_FILANavigation { get; set; } = null!;
}
