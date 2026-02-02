using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_PARAMENTRO_COMISSAO
{
    public int ID_PARAMETRO_COMISSAO { get; set; }

    public int NR_AGING_DIAS_MENOR { get; set; }

    public int NR_AGING_DIAS_MAIOR { get; set; }

    public string? VL_PERC_COMISSAO { get; set; }

    public int? ID_CARTEIRA { get; set; }

    public decimal? VL_ADICIONAL { get; set; }

    public string DS_NOME { get; set; } = null!;

    public int NR_TIPO { get; set; }
}
