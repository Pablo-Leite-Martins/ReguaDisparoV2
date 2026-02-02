using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UNIDADE_PRECO_LOG_SERVICO
{
    public int ID_UNIDADE_PRECO_LOG_SERVICO { get; set; }

    public string? DS_UNIDADE_PRECO_PRECO_LOG_SERVICO { get; set; }

    public DateTime? DT_UNIDADE_PRECO_LOG_SERVICO { get; set; }

    public int? ID_UNIDADE_PRECO_LOG { get; set; }
}
