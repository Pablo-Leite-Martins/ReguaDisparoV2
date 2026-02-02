using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO_LOG
{
    public int ID_INTEGRACAO_LOG { get; set; }

    public int ID_TIPO_INTEGRACAO { get; set; }

    public string DS_INTEGRACAO_LOG { get; set; } = null!;

    public DateTime DT_INTEGRACAO_LOG { get; set; }

    public int ID_USUARIO { get; set; }
}
