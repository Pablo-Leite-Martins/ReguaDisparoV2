using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PARCELA
{
    public int ID_TIPO_PARCELA { get; set; }

    public string DS_DESCRICAO { get; set; } = null!;

    public int NR_PERIODICIDADE { get; set; }

    public string? DS_TIPO { get; set; }

    public bool FL_GERAR_BOLETO { get; set; }

    public bool? FL_FINANCIAMENTO_PROPRIO { get; set; }

    public bool? FL_FGTS { get; set; }

    public bool? FL_FINANCIAMENTO { get; set; }

    public bool? FL_SINAL { get; set; }

    public bool? FL_SUBSIDIO { get; set; }

    public bool? FL_COMISSIONAR { get; set; }

    public bool? FL_BONUS { get; set; }

    public bool? FL_PRO_SOLUTO { get; set; }

    public bool? FL_MENSAL { get; set; }

    public bool? FL_ANUAL { get; set; }

    public decimal? MAX_PRO_SOLUTO { get; set; }

    public decimal? MAX_RENDA { get; set; }

    public decimal? MIN_RENDA { get; set; }

    public bool? FL_ENTRADA { get; set; }

    public bool? FL_SEMESTRAL { get; set; }

    public bool? FL_UNICA { get; set; }

    public bool? FL_INTERMEDIARIA { get; set; }

    public bool? FL_TRIMESTRAL { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool? FL_PAGAMENTO_REPASSE { get; set; }

    public bool? FL_FORA_EXTRATO { get; set; }

    public int? FL_CARTAO_CREDITO { get; set; }

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA> TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELAs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA>();

    public virtual ICollection<TB_CMCRM_FORMA_PAGAMENTO> TB_CMCRM_FORMA_PAGAMENTOs { get; set; } = new List<TB_CMCRM_FORMA_PAGAMENTO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO> TB_CMCRM_PROPOSTA_FORMA_PAGAMENTOs { get; set; } = new List<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO>();
}
