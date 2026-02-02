using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_VALORES_REPASSE_2023_03_21
{
    public int ID_TOTVS_FATO_VALORES_REPASSE { get; set; }

    public int? NUM_VENDA { get; set; }

    public string? TOTAL_CEF { get; set; }

    public string? TOTAL_FGTS { get; set; }

    public string? TOTAL_SUBSIDIO { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
