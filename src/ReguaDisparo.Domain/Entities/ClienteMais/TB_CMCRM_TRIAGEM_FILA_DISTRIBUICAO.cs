using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAO
{
    public int ID_TRIAGEM_FILA_DISTRIBUICAO { get; set; }

    public int ID_TRIAGEM_FILA { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_DISTRIBUICAO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TRIAGEM_FILA ID_TRIAGEM_FILANavigation { get; set; } = null!;
}
