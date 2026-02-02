using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_LOG_IMPORTACAO_DOCUMENTO
{
    public int ID_LOG { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public DateTime DT_IMPORTACAO { get; set; }
}
