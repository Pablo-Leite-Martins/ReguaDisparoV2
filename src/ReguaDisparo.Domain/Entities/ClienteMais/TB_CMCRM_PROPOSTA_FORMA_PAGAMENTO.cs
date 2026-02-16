using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO
{
    public int ID_PROPOSTA_FORMA_PAGAMENTO { get; set; }

    public int? ID_MODELO_VENDA_PADRAO { get; set; }

    public int ID_TIPO_PARCELA { get; set; }

    public decimal VL_PARCELA { get; set; }

    public int NR_QUANTIDADE_PARCELAS { get; set; }

    public DateTime DT_VENCIMENTO_PRIMEIRA_PARCELA { get; set; }

    public int ID_PROPOSTA { get; set; }

    public decimal? VL_DESCONTO { get; set; }

    public string? DS_TIPO_AMORTIZACAO { get; set; }

    public string? DS_TIPO_FORMA_PAGAMENTO { get; set; }

    public bool? FL_REAJUSTAVEL { get; set; }

    public decimal? VL_TAXA_JUROS { get; set; }

    public int? ID_INDICE { get; set; }

    public string? NR_DIA_VENCIMENTO { get; set; }

    public DateTime? DT_INICIO_JUROS { get; set; }

    public DateTime? DT_INICIO_REAJUSTE { get; set; }

    public decimal? VL_COMISSAO_DIRETA { get; set; }

    public bool? FL_DEFINIR_VENCIMENTO_PRIMEIRA_PARCELA { get; set; }

    public DateTime? DT_VENCIMENTO_PRIMEIRA_PARCELA_SERIE { get; set; }

    public bool? FL_VENCIMENTO_DATA_VENDA_PRIMEIRA_PARCELA { get; set; }

    public int? NR_VENCIMENTO_MESES_DATA_VENDA_PRIMEIRA_PARCELA { get; set; }

    public int? NR_VENCIMENTO_DIAS_DATA_VENDA_PRIMEIRA_PARCELA { get; set; }

    public virtual TB_CMCRM_MODELO_VENDA? ID_MODELO_VENDA_PADRAONavigation { get; set; }

    public virtual TB_CMCRM_PROPOSTA ID_PROPOSTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PARCELA ID_TIPO_PARCELANavigation { get; set; } = null!;
}
