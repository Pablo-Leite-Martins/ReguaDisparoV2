using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_GRUPO
{
    public int ID_ALCADA_GRUPO { get; set; }

    public int ID_GRUPO { get; set; }

    public decimal? NR_VALOR_ACRESCIMO { get; set; }

    public decimal? NR_VALOR_DESCONTO { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_MULTA_ATE_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_MULTA_MAIOR_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_JUROS_ATE_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_JUROS_MAIOR_50 { get; set; }
}
