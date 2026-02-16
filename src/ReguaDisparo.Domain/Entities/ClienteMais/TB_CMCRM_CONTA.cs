using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA
{
    public int ID_CONTA { get; set; }

    public string DS_NOME { get; set; } = null!;

    public int? ID_CONTA_PAI { get; set; }

    public int ID_TIPO_CONTA { get; set; }

    public int? ID_SETOR { get; set; }

    public string? DS_SITE_WEB { get; set; }

    public int? NR_QUANTIDADE_FUNCIONARIO { get; set; }

    public decimal? VL_RECEITA_ANUAL { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public int? ID_CIDADE_COBRANCA { get; set; }

    public string? DS_BAIRRO_COBRANCA { get; set; }

    public string? DS_LOGRADOURO_COBRANCA { get; set; }

    public int? NR_ENDERECO_COBRANCA { get; set; }

    public string? DS_COMPLEMENTO_COBRANCA { get; set; }

    public string? NR_CEP_COBRANCA { get; set; }

    public int? ID_CIDADE_ENTREGA { get; set; }

    public string? DS_BAIRRO_ENTREGA { get; set; }

    public string? DS_LOGRADOURO_ENTREGA { get; set; }

    public int? NR_ENDERECO_ENTREGA { get; set; }

    public string? DS_COMPLEMENTO_ENTREGA { get; set; }

    public string? NR_CEP_ENTREGA { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? ID_USUARIO_PROPRIETARIO { get; set; }

    public string? DS_SAUDACAO { get; set; }

    public DateTime? DT_NASCIMENTO { get; set; }

    public string? DS_FAIXA_ETARIA { get; set; }

    public int? ID_PROFISSAO_CONTA { get; set; }

    public string? DS_SEXO { get; set; }

    public string? DS_ESTADO_CIVIL { get; set; }

    public int? NR_FILHOS { get; set; }

    public int? NR_SCORE { get; set; }

    public string? DS_IMOVEL_PROPRIO { get; set; }

    public string? DS_VEICULO_PROPRIO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public decimal? VL_RENDA { get; set; }

    public int? NR_DEPENDENTES { get; set; }

    public string? NR_CPF { get; set; }

    public string? NR_RG { get; set; }

    public string? DS_RG_ORGAO_EMISSOR { get; set; }

    public string? DS_RG_UF_EMISSOR { get; set; }

    public DateTime? DT_RG_EMISSAO { get; set; }

    public string? DS_NACIONALIDADE { get; set; }

    public string? DS_EMAIL { get; set; }

    public string? DS_TITULO { get; set; }

    public string? DS_MELHOR_HORARIO_ATENDIMENTO { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public string? DS_PROFISSAO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public string? DS_NATURALIDADE { get; set; }

    public string? DS_REGIME_COMUNHAO { get; set; }

    public DateTime? DT_CASAMENTO { get; set; }

    public string? DS_NOME_PAI { get; set; }

    public string? DS_NOME_MAE { get; set; }

    public bool? FL_WEB_TO_LEAD { get; set; }

    public bool? FL_CHAT_TO_LEAD { get; set; }

    public string? DS_CIDADE_COBRANCA { get; set; }

    public bool? FL_RECEBER_COBRANCA { get; set; }

    public DateTime? DT_ALTERACAO_RECEBER_COBRANCA { get; set; }

    public int? ID_USUARIO_ALTERACAO_RECEBER_COBRANCA { get; set; }

    public string? DS_RG_TIPO { get; set; }

    public string? DS_RG_CATEGORIA { get; set; }

    public DateTime? DT_RG_VALIDADE { get; set; }

    public bool? FL_TERRENEIRO { get; set; }

    public bool? FL_CLIENTE_PRIORITARIO { get; set; }

    public string? DS_TIPO_VEICULO { get; set; }

    public bool? FL_ACEITE_TERMO { get; set; }

    public bool? FL_PACTO_ANTE_NUPCIAL { get; set; }

    public string? DS_RAZAO_SOCIAL { get; set; }

    public string? DS_PACTO_ANTE_NUPCIAL { get; set; }

    public DateTime? DT_INICIO_ANTENUPCIAL { get; set; }

    public DateTime? DT_FIM_ANTENUPCIAL { get; set; }

    public bool? FL_FGTS { get; set; }

    public decimal? VL_FGTS { get; set; }

    public string? DS_BAIRRO_OCUPACAO { get; set; }

    public int? ID_MOTIVO_COMPRA { get; set; }

    public int? ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public string? NR_INSCRICAO_MUNICIPAL { get; set; }

    public string? NR_INSCRICAO_ESTADUAL { get; set; }

    public string? NR_REGISTRO_JUNTA { get; set; }

    public string? DS_EMPRESA_EMPREGADORA { get; set; }

    public int? ID_PRODUTO_ORIGEM_LEAD { get; set; }

    public string? DS_LOGIN_PORTAL { get; set; }

    public string? DS_SENHA_PORTAL { get; set; }

    public bool? FL_LOGIN_PORTAL_VALIDADO { get; set; }

    public bool? FL_INTERNACIONAL { get; set; }

    public string? DS_PAIS_COBRANCA { get; set; }

    public string? DS_PAIS_ENTREGA { get; set; }

    public string? DS_ESTADO_ENTREGA { get; set; }

    public string? DS_ESTADO_COBRANCA { get; set; }

    public string? DS_CIDADE_ENTREGA { get; set; }

    public bool? FL_INTERNACIONAL_COBRANCA { get; set; }

    public string? DS_ESCOLARIDADE { get; set; }

    public DateTime? DT_ADMISSAO { get; set; }

    public string? DS_TEMPO_RESIDENCIA { get; set; }

    public int? ID_BANCO { get; set; }

    public string? NR_AGENCIA_BANCO { get; set; }

    public string? NR_CONTA_BANCO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int? ID_PERFIL_FINANCEIRO_CONTA { get; set; }

    public int? ID_PERFIL_TIPO_CONTA { get; set; }

    public string? DS_FORMA_CONTATO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_MOTIVO_COMPRA? ID_MOTIVO_COMPRANavigation { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD? ID_ORIGEM_LEADNavigation { get; set; }

    public virtual TB_CMCRM_PERFIL_FINANCEIRO_CONTA? ID_PERFIL_FINANCEIRO_CONTANavigation { get; set; }

    public virtual TB_CMCRM_PERFIL_TIPO_CONTA? ID_PERFIL_TIPO_CONTANavigation { get; set; }

    public virtual TB_CMCRM_TIPO_CANAL_ATENDIMENTO? ID_TIPO_CANAL_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_CONTA ID_TIPO_CONTANavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();

    public virtual ICollection<TB_CMCRM_CONTA_CHAT> TB_CMCRM_CONTA_CHATs { get; set; } = new List<TB_CMCRM_CONTA_CHAT>();

    public virtual ICollection<TB_CMCRM_CONTA_CONTATO> TB_CMCRM_CONTA_CONTATOs { get; set; } = new List<TB_CMCRM_CONTA_CONTATO>();

    public virtual ICollection<TB_CMCRM_CONTA_FILA_ENTREGA> TB_CMCRM_CONTA_FILA_ENTREGAs { get; set; } = new List<TB_CMCRM_CONTA_FILA_ENTREGA>();

    public virtual ICollection<TB_CMCRM_CONTA_LIGACAO> TB_CMCRM_CONTA_LIGACAOs { get; set; } = new List<TB_CMCRM_CONTA_LIGACAO>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO_PROPONENTE> TB_CMCRM_CONTA_PRODUTO_PROPONENTEs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO_PROPONENTE>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO> TB_CMCRM_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_CONTA_TELEFONE> TB_CMCRM_CONTA_TELEFONEs { get; set; } = new List<TB_CMCRM_CONTA_TELEFONE>();

    public virtual ICollection<TB_CMCRM_EMAIL_REGUA_PESQUISA> TB_CMCRM_EMAIL_REGUA_PESQUISAs { get; set; } = new List<TB_CMCRM_EMAIL_REGUA_PESQUISA>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO> TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG> TB_CMCRM_ENVELOPE_DOCUSIGN_LOGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG>();

    public virtual ICollection<TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOG> TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOGs { get; set; } = new List<TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOG>();

    public virtual ICollection<TB_CMCRM_INTERESSE_CONTA_PRODUTO> TB_CMCRM_INTERESSE_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_INTERESSE_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_OPORTUNIDADE> TB_CMCRM_OPORTUNIDADEs { get; set; } = new List<TB_CMCRM_OPORTUNIDADE>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_CONVERSAO> TB_CMCRM_ORIGEM_LEAD_CONVERSAOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_CONVERSAO>();

    public virtual ICollection<TB_CMCRM_PARCELAS_SERASA> TB_CMCRM_PARCELAS_SERASAs { get; set; } = new List<TB_CMCRM_PARCELAS_SERASA>();

    public virtual ICollection<TB_CMCRM_PERFIL_CONTA> TB_CMCRM_PERFIL_CONTa { get; set; } = new List<TB_CMCRM_PERFIL_CONTA>();

    public virtual ICollection<TB_CMCRM_PRODUTO_RESERVA> TB_CMCRM_PRODUTO_RESERVAs { get; set; } = new List<TB_CMCRM_PRODUTO_RESERVA>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_CONTA> TB_CMCRM_PROPOSTA_CONTa { get; set; } = new List<TB_CMCRM_PROPOSTA_CONTA>();

    public virtual ICollection<TB_CMCRM_TAG_CONTA> TB_CMCRM_TAG_CONTa { get; set; } = new List<TB_CMCRM_TAG_CONTA>();
}
