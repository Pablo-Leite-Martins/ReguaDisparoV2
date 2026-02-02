using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_GRUPO_CAMPANHA
{
    public int ID_ALCADA_GRUPO_CAMPANHA { get; set; }

    public int ID_GRUPO { get; set; }

    public int ID_CASO_COBRANCA_CAMPANHA { get; set; }

    public decimal? NR_VALOR_ACRESCIMO { get; set; }

    public decimal? NR_VALOR_DESCONTO { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_MULTA_ATE_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_MULTA_MAIOR_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_JUROS_ATE_50 { get; set; }

    public decimal? NR_PERCENTUAL_DESCONTO_JUROS_MAIOR_50 { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_CAMPANHA ID_CASO_COBRANCA_CAMPANHANavigation { get; set; } = null!;
}
