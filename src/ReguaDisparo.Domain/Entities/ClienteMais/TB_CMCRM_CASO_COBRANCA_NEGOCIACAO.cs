using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_NEGOCIACAO
{
    public int ID_CASO_COBRANCA_NEGOCIACAO { get; set; }

    public int ID_CASO { get; set; }

    public decimal VL_TOTAL_NEGOCIADO { get; set; }

    public int ID_USUARIO_RESPONSAVEL { get; set; }

    public string DS_STATUS_NEGOCIACAO { get; set; } = null!;

    public DateTime? DT_INICIO_NEGOCIACAO { get; set; }

    public DateTime? DT_FIM_NEGOCIACAO { get; set; }

    public bool? FL_RENEGOCIADO_UAU { get; set; }

    public decimal? VL_CONTRATO { get; set; }

    public decimal? VL_CUSTAS { get; set; }

    public decimal? VL_SEGURO { get; set; }

    public decimal? VL_HONORARIO { get; set; }

    public decimal? VL_HONORARIO_PERC { get; set; }

    public decimal? VL_DESCONTO_HONORARIO { get; set; }

    public decimal? VL_ACRESCIMO { get; set; }

    public decimal? VL_DESCONTO { get; set; }

    public decimal? VL_DESCONTO_PERC { get; set; }

    public int? ID_MODELO_RENEGOCIACAO_UAU { get; set; }

    public int? ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int? ID_VENDA { get; set; }

    public bool? FL_APROVADO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELAS_NEGOCIADA> TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELAS_NEGOCIADAs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELAS_NEGOCIADA>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELA> TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELAs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELA>();
}
