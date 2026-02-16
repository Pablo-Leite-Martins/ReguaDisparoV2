using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_VENDA
{
    public int ID_EQUIPE_VENDAS { get; set; }

    public string DS_EQUIPE_VENDAS { get; set; } = null!;

    public bool? FL_ATENDIMENTO_CHAT { get; set; }

    public string? DS_NOME_CHAT { get; set; }

    public string? DS_NOME_EQUIPE { get; set; }

    public string? DS_NOME_FANTASIA { get; set; }

    public string? NR_CNPJ { get; set; }

    public string? DS_PAIS { get; set; }

    public string? DS_ESTADO { get; set; }

    public string? DS_CIDADE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? DS_CEP { get; set; }

    public int? NR_NUMERO { get; set; }

    public string? DS_COMPLEMENTO { get; set; }

    public bool? FL_EQUIPE_GA { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public string? DS_CRECI { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? NR_TELEFONE { get; set; }

    public virtual ICollection<TB_CMCRM_EQUIPE_VENDAS_PRODUTO> TB_CMCRM_EQUIPE_VENDAS_PRODUTOs { get; set; } = new List<TB_CMCRM_EQUIPE_VENDAS_PRODUTO>();

    public virtual ICollection<TB_CMCRM_EQUIPE_VENDAS_USUARIO> TB_CMCRM_EQUIPE_VENDAS_USUARIOs { get; set; } = new List<TB_CMCRM_EQUIPE_VENDAS_USUARIO>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO> TB_CMCRM_ESTRUTURA_COMISSAOs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDA> TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDAs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_EQUIPE_VENDA>();

    public virtual ICollection<TB_CMCRM_PROPOSTA> TB_CMCRM_PROPOSTa { get; set; } = new List<TB_CMCRM_PROPOSTA>();
}
