using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_STATUS_COBRANCA_ERP_LOG
{
    public int ID_STATUS_COBRANCA_ERP_LOG { get; set; }

    public string COD_STATUS_COBRANCA { get; set; } = null!;

    public string DS_STATUS_COBRANCA { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public DateTime DT_USUARIO_CADASTRO { get; set; }

    public DateTime DT_ACAO { get; set; }
}
