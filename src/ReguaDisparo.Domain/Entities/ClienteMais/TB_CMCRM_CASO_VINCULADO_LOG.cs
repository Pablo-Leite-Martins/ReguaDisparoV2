using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_VINCULADO_LOG
{
    public int ID_VINCULADO { get; set; }

    public int ID_CASO_PAI { get; set; }

    public int ID_CASO_VINCULADO { get; set; }

    public int ID_USUARIO { get; set; }

    public DateTime DT_EXCLUSAO { get; set; }

    public int ID_USUARIO_EXCLUSAO { get; set; }
}
