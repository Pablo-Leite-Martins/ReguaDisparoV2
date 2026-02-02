using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE
{
    public int ID_CASO_COBRANCA_NEGOCIACAO_ANALISE { get; set; }

    public int ID_CASO { get; set; }

    public decimal VL_TOTAL_NEGOCIADO { get; set; }

    public int ID_USUARIO_REQUISICAO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public string DS_STATUS { get; set; } = null!;

    public DateTime DT_PEDIDO_NEGOCIACAO { get; set; }

    public DateTime? DT_APROVACAO_NEGOCIACAO { get; set; }

    public decimal? VL_CONTRATO { get; set; }

    public decimal? VL_CUSTAS { get; set; }

    public decimal? VL_SEGURO { get; set; }

    public decimal? VL_HONORARIO { get; set; }

    public decimal? VL_DESCONTO { get; set; }

    public int ID_MODELO_RENEGOCIACAO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public DateTime? DT_VENCIMENTO_ENTRADA { get; set; }

    public int? NR_DIA_PAGAMENTO { get; set; }

    public decimal? VL_ENTRADA { get; set; }

    public decimal? VL_ACRESCIMO { get; set; }

    public DateTime? DT_ULTIMO_VENCIMENTO { get; set; }

    public decimal? VL_PERCENTUAL_ENTRADA { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELAS_NEGOCIADA> TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELAS_NEGOCIADAs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELAS_NEGOCIADA>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELA> TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELAs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELA>();
}
