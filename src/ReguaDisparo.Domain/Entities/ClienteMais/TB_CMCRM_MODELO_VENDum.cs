using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_VENDum
{
    public int ID_MODELO_VENDA { get; set; }

    public string DS_DESCRICAO { get; set; } = null!;

    public string? ID_CHAVE_ERP { get; set; }

    public decimal? VL_PRO_SOLUTO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public decimal? VL_DESCONTO { get; set; }

    public bool? FL_EXIGIR_APROVACAO { get; set; }

    public decimal? VL_DESCAPITALIZACAO { get; set; }

    public decimal? VL_COMISSAO_PREMIO { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool FL_VALIDAR_NOVAS_SERIES { get; set; }

    public bool FL_RENEGOCIACAO { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDum> TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDa { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDum>();

    public virtual ICollection<TB_CMCRM_FORMA_PAGAMENTO> TB_CMCRM_FORMA_PAGAMENTOs { get; set; } = new List<TB_CMCRM_FORMA_PAGAMENTO>();

    public virtual ICollection<TB_CMCRM_MODELO_VENDA_PRODUTO> TB_CMCRM_MODELO_VENDA_PRODUTOs { get; set; } = new List<TB_CMCRM_MODELO_VENDA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_MODELO_VENDA_UNIDADE_PRECO> TB_CMCRM_MODELO_VENDA_UNIDADE_PRECOs { get; set; } = new List<TB_CMCRM_MODELO_VENDA_UNIDADE_PRECO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO> TB_CMCRM_PROPOSTA_FORMA_PAGAMENTOs { get; set; } = new List<TB_CMCRM_PROPOSTA_FORMA_PAGAMENTO>();

    public virtual ICollection<TB_CMCRM_PROPOSTum> TB_CMCRM_PROPOSTa { get; set; } = new List<TB_CMCRM_PROPOSTum>();
}
