using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_APROVACAO_PROPOSTum
{
    public int ID_CASO { get; set; }

    public int? ID_EQUIPE { get; set; }

    public string? EQUIPE { get; set; }

    public string CLIENTE { get; set; } = null!;

    public string STATUS { get; set; } = null!;

    public DateTime DT_CRIACAO { get; set; }

    public decimal VL_TOTAL { get; set; }

    public string DS_EMPREENDIMENTO { get; set; } = null!;

    public string DS_UNIDADE { get; set; } = null!;

    public decimal? VL_DESCONTO { get; set; }

    public decimal? VL_TOTAL_CAPITALIZADO { get; set; }

    public decimal? VL_SUBSIDIO { get; set; }

    public int? NR_QTD_SUBSIDIO { get; set; }

    public decimal? VL_FGTS { get; set; }

    public int? NR_QTD_FGTS { get; set; }

    public decimal? VL_SINAL { get; set; }

    public int? NR_QTD_SINAL { get; set; }

    public decimal? VL_FINANCIAMENTO { get; set; }

    public int? NR_QTD_FINANCIAMENTO { get; set; }

    public decimal? VL_FINANCIAMENTO_PROP { get; set; }

    public int? NR_QTD_FINANCIAMENTO_PROP { get; set; }
}
