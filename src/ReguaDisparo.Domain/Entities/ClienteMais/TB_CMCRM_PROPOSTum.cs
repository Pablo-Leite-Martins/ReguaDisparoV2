using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PROPOSTum
{
    public int ID_PROPOSTA { get; set; }

    public string? DS_DESCRICAO { get; set; }

    public DateTime DT_CRIACAO { get; set; }

    public DateTime DT_VALIDADE { get; set; }

    public decimal VL_TOTAL { get; set; }

    public string DS_STATUS { get; set; } = null!;

    public int ID_USUARIO_RESPONSAVEL { get; set; }

    public int? ID_USUARIO_APROVACAO { get; set; }

    public int ID_OPORTUNIDADE { get; set; }

    public int ID_UNIDADE_PRECO { get; set; }

    public int ID_MODELO_VENDA { get; set; }

    public decimal? VL_DESCONTO { get; set; }

    public decimal? VL_COMISSAO_DIRETA { get; set; }

    public bool? FL_SIMULACAO { get; set; }

    public decimal? VL_TOTAL_CAPITALIZADO { get; set; }

    public int? ID_ESTRUTURA_COMISSAO { get; set; }

    public string? NR_CONTRATO_FINANCIAMENTO { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public bool? FL_SEM_DESCONTO { get; set; }

    public decimal? VL_BONUS_INADIMPLENCIA { get; set; }

    public decimal? VL_VPL_MODELO { get; set; }

    public decimal? VL_VPL_PROPOSTA { get; set; }

    public DateTime? DT_APROVACAO { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public virtual TB_CMCRM_EQUIPE_VENDA? ID_EQUIPE_VENDASNavigation { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO? ID_ESTRUTURA_COMISSAONavigation { get; set; }

    public virtual TB_CMCRM_MODELO_VENDum ID_MODELO_VENDANavigation { get; set; } = null!;

    public virtual TB_CMCRM_OPORTUNIDADE ID_OPORTUNIDADENavigation { get; set; } = null!;

    public virtual TB_CMCRM_UNIDADE_PRECO ID_UNIDADE_PRECONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO> TB_CMCRM_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_CONTRATO> TB_CMCRM_CONTRATOs { get; set; } = new List<TB_CMCRM_CONTRATO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_CONTum> TB_CMCRM_PROPOSTA_CONTa { get; set; } = new List<TB_CMCRM_PROPOSTA_CONTum>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL> TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVELs { get; set; } = new List<TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO> TB_CMCRM_PROPOSTA_FORMA_PAGAMENTOs { get; set; } = new List<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_LOG> TB_CMCRM_PROPOSTA_LOGs { get; set; } = new List<TB_CMCRM_PROPOSTA_LOG>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_PRODUTO> TB_CMCRM_PROPOSTA_PRODUTOs { get; set; } = new List<TB_CMCRM_PROPOSTA_PRODUTO>();
}
