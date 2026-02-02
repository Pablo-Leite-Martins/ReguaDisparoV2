using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_INTEGRACAO_LOG
{
    public int ID_CONTA_INTEGRACAO_LOG { get; set; }

    public int? ID_CONTA { get; set; }

    public string? DS_DADOS { get; set; }

    public int ID_TIPO_INTEGRACAO { get; set; }

    public DateTime DT_CADASTRO { get; set; }
}
