using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELAS_NEGOCIADA
{
    public int ID_CASO_COBRANCA_NEGOCIACAO_PARCELAS_NEGOCIADAS { get; set; }

    public decimal VL_PARCELA { get; set; }

    public decimal VL_MULTA { get; set; }

    public decimal VL_JUROS { get; set; }

    public decimal VL_DESCONTO { get; set; }

    public decimal VL_HONORARIO { get; set; }

    public decimal VL_TOTAL_PARCELA { get; set; }

    public DateTime DT_VENCIMENTO { get; set; }

    public int ID_CASO_COBRANCA_NEGOCIACAO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public int NR_PARCELA { get; set; }

    public int NR_PARCELA_GERAL { get; set; }

    public string DS_TIPO { get; set; } = null!;

    public DateTime DT_CALCULO { get; set; }

    public decimal VL_DESCONTO_MULTA { get; set; }

    public decimal VL_DESCONTO_JUROS { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_NEGOCIACAO ID_CASO_COBRANCA_NEGOCIACAONavigation { get; set; } = null!;
}
