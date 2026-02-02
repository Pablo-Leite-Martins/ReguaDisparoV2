using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CAMPANHA_DISCADOR
{
    public int ID_LOG { get; set; }

    public int ID_CAMPANHA { get; set; }

    public DateTime? DT_ACAO { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public bool FL_DISCADOR_ATIVO { get; set; }

    public int ID_USUARIO { get; set; }
}
