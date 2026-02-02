using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTATO
{
    public int ID_CONTATO { get; set; }

    public string? DS_NOME { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_EMAIL { get; set; }

    public int? ID_CIDADE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public int? NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string? NR_CEP { get; set; }

    public string? DS_TITULO { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public string? DS_MELHOR_HORARIO_ATENDIMENTO { get; set; }

    public string? NR_RG { get; set; }

    public string? DS_RG_ORGAO_EMISSOR { get; set; }

    public string? DS_RG_UF_EMISSOR { get; set; }

    public DateTime? DT_RG_EMISSAO { get; set; }

    public string? DS_NACIONALIDADE { get; set; }

    public int? ID_PROFISSAO { get; set; }

    public string? DS_PROFISSAO { get; set; }

    public string? DS_NOME_PAI { get; set; }

    public string? DS_NOME_MAE { get; set; }

    public string? DS_RG_TIPO { get; set; }

    public string? DS_RG_CATEGORIA { get; set; }

    public DateTime? DT_RG_VALIDADE { get; set; }

    public decimal? VL_RENDA { get; set; }

    public string? DS_ESTADO_CIVIL { get; set; }

    public DateTime? DT_NASCIMENTO { get; set; }

    public string? DS_LOGIN_PORTAL { get; set; }

    public string? DS_SENHA_PORTAL { get; set; }

    public bool? FL_LOGIN_PORTAL_VALIDADO { get; set; }

    public string? DS_REGIME_COMUNHAO { get; set; }

    public string? DS_NOME_CONJUGE { get; set; }

    public string? NR_CPF_CONJUGE { get; set; }

    public string? NR_RG_CONJUGE { get; set; }

    public string? DS_RG_ORGAO_EMISSOR_CONJUGE { get; set; }

    public string? DS_RG_UF_EMISSOR_CONJUGE { get; set; }

    public DateTime? DT_RG_EMISSAO_CONJUGE { get; set; }

    public string? DS_RG_TIPO_CONJUGE { get; set; }

    public string? DS_RG_CATEGORIA_CONJUGE { get; set; }

    public DateTime? DT_RG_VALIDADE_CONJUGE { get; set; }

    public DateTime? DT_NASCIMENTO_CONJUGE { get; set; }

    public string? DS_NACIONALIDADE_CONJUGE { get; set; }

    public int? ID_PROFISSAO_CONJUGE { get; set; }

    public string? DS_PROFISSAO_CONJUGE { get; set; }

    public string? DS_EMAIL_CONJUGE { get; set; }

    public string? NR_TELEFONE_CONJUGE { get; set; }

    public string? DS_NATURALIDADE { get; set; }

    public string? DS_NATURALIDADE_CONJUGE { get; set; }

    public string? DS_SEXO { get; set; }

    public virtual ICollection<TB_CMCRM_AUDIENCIA_CONTATO> TB_CMCRM_AUDIENCIA_CONTATOs { get; set; } = new List<TB_CMCRM_AUDIENCIA_CONTATO>();

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();

    public virtual ICollection<TB_CMCRM_CONTATO_DOCUMENTO> TB_CMCRM_CONTATO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CONTATO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_CONTA_CONTATO> TB_CMCRM_CONTA_CONTATOs { get; set; } = new List<TB_CMCRM_CONTA_CONTATO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO> TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG> TB_CMCRM_ENVELOPE_DOCUSIGN_LOGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG>();

    public virtual ICollection<TB_CMCRM_PARCELAS_SERASA> TB_CMCRM_PARCELAS_SERASAs { get; set; } = new List<TB_CMCRM_PARCELAS_SERASA>();

    public virtual ICollection<TB_CMCRM_PRODUTO_CONTATO> TB_CMCRM_PRODUTO_CONTATOs { get; set; } = new List<TB_CMCRM_PRODUTO_CONTATO>();
}
