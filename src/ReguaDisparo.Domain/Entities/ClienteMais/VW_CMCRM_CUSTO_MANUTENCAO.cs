using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class VW_CMCRM_CUSTO_MANUTENCAO
{
    public DateTime? DATABAIXA { get; set; }

    public int? ANO { get; set; }

    public int? MES { get; set; }

    public decimal? VALOR_ORIGINAL_M { get; set; }

    public decimal? VALOR_LIQUIDO_M { get; set; }

    public string? PRACA { get; set; }

    public int? VIST { get; set; }

    public int? MANUT { get; set; }

    public int? NAO_EXEC { get; set; }

    public decimal? VLR_POR_VIST { get; set; }

    public decimal? VLR_POR_MANUT { get; set; }

    public int ID_CALENDARIO { get; set; }
}
