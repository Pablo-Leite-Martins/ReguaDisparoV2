using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO
{
    public int ID_ESTRUTURA_COMISSAO { get; set; }

    public string DS_DESCRICAO { get; set; } = null!;

    public decimal? VL_COMISSAO_CORRETOR { get; set; }

    public decimal? VL_COMISSAO_GERENTE { get; set; }

    public decimal? VL_COMISSAO_GERENTE_REGIONAL { get; set; }

    public decimal? VL_COMISSAO_DIRETOR { get; set; }

    public decimal? VL_COMISSAO_IMOBILIARIA { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public decimal? VL_COMISSAO_COORDENADOR_VENDAS { get; set; }

    public decimal? VL_COMISSAO_COORDENADOR_MARKETING { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public decimal? VL_COMISSAO_GERENTE_COMERCIAL { get; set; }

    public decimal? VL_COMISSAO_SUPERINTENDENTE { get; set; }

    public decimal? VL_COMISSAO_FIXA_CORRETOR { get; set; }

    public decimal? VL_COMISSAO_FIXA_GERENTE { get; set; }

    public decimal? VL_COMISSAO_FIXA_GERENTE_REGIONAL { get; set; }

    public decimal? VL_COMISSAO_FIXA_DIRETOR { get; set; }

    public decimal? VL_COMISSAO_FIXA_IMOBILIARIA { get; set; }

    public decimal? VL_COMISSAO_FIXA_COORDENADOR_VENDAS { get; set; }

    public decimal? VL_COMISSAO_FIXA_COORDENADOR_MARKETING { get; set; }

    public decimal? VL_COMISSAO_FIXA_GERENTE_COMERCIAL { get; set; }

    public decimal? VL_COMISSAO_FIXA_SUPERINTENDENTE { get; set; }

    public virtual TB_CMCRM_EQUIPE_VENDA? ID_EQUIPE_VENDASNavigation { get; set; }

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE> TB_CMCRM_DOCUMENTO_TEMPLATEs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_LOG> TB_CMCRM_ESTRUTURA_COMISSAO_LOGs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_LOG>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDA> TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDa { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDA>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTO> TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTOs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA> TB_CMCRM_PROPOSTa { get; set; } = new List<TB_CMCRM_PROPOSTA>();
}
