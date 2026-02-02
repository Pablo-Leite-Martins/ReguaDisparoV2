using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PUNICAO_USUARIO_LOG
{
    public int ID_PUNICAO_USUARIO_LOG { get; set; }

    public string DS_PUNICAO_USUARIO_LOG { get; set; } = null!;

    public DateTime DT_PUNICAO_USUARIO { get; set; }

    public int ID_PUNICAO_USUARIO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_PUNICAO_USUARIO ID_PUNICAO_USUARIONavigation { get; set; } = null!;
}
