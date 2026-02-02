using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO
{
    public int ID_CASO { get; set; }

    public string DS_CASO { get; set; } = null!;

    public int? ID_PRODUTO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public bool FL_CASO_RECORRENTE { get; set; }

    public int? ID_TIPO_RECORRENCIA { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_GARANTIA { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int ID_CONTA { get; set; }

    public int? ID_CONTATO { get; set; }

    public bool? FL_NAO_PROCEDENTE { get; set; }

    public int? ID_MOTIVO_CANCELAMENTO { get; set; }

    public int? ID_MOTIVO_NAO_PROCEDENCIA { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool? FL_SINCRONIZADO { get; set; }

    public int? NUM_ATENDIMENTO_UAU { get; set; }

    public int? ID_SUBCATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL_ACOMPANHAMENTO { get; set; }

    public int? ID_TIPO_PESO_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO ID_CATEGORIA_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual TB_CMCRM_SUBCATEGORIA_ATENDIMENTO? ID_SUBCATEGORIA_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_CANAL_ATENDIMENTO ID_TIPO_CANAL_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CASO ID_TIPO_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PESO_ATENDIMENTO? ID_TIPO_PESO_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_RECORRENCIum? ID_TIPO_RECORRENCIANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ANALISE_CREDITO> TB_CMCRM_ANALISE_CREDITOs { get; set; } = new List<TB_CMCRM_ANALISE_CREDITO>();

    public virtual ICollection<TB_CMCRM_CASO_ATIVIDADE> TB_CMCRM_CASO_ATIVIDADEs { get; set; } = new List<TB_CMCRM_CASO_ATIVIDADE>();

    public virtual ICollection<TB_CMCRM_CASO_CAMINHO> TB_CMCRM_CASO_CAMINHOs { get; set; } = new List<TB_CMCRM_CASO_CAMINHO>();

    public virtual ICollection<TB_CMCRM_CASO_CLAUSULA> TB_CMCRM_CASO_CLAUSULAs { get; set; } = new List<TB_CMCRM_CASO_CLAUSULA>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_DADO> TB_CMCRM_CASO_COBRANCA_DADOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_DADO>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE> TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISEs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO> TB_CMCRM_CASO_COBRANCA_NEGOCIACAOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_NEGOCIACAO>();

    public virtual ICollection<TB_CMCRM_CASO_COMODO_ASSISTENCIA_TEC> TB_CMCRM_CASO_COMODO_ASSISTENCIA_TECs { get; set; } = new List<TB_CMCRM_CASO_COMODO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_CASO_DADOS_FECHAMENTO> TB_CMCRM_CASO_DADOS_FECHAMENTOs { get; set; } = new List<TB_CMCRM_CASO_DADOS_FECHAMENTO>();

    public virtual ICollection<TB_CMCRM_CASO_DOCUMENTO_GERADO> TB_CMCRM_CASO_DOCUMENTO_GERADOs { get; set; } = new List<TB_CMCRM_CASO_DOCUMENTO_GERADO>();

    public virtual ICollection<TB_CMCRM_CASO_DOCUMENTO> TB_CMCRM_CASO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_CASO_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_CASO_HISTORICO> TB_CMCRM_CASO_HISTORICOs { get; set; } = new List<TB_CMCRM_CASO_HISTORICO>();

    public virtual ICollection<TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIum> TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIa { get; set; } = new List<TB_CMCRM_CASO_PARALIZACAO_SLA_VISTORIum>();

    public virtual ICollection<TB_CMCRM_CASO_PARALIZACAO_SLA> TB_CMCRM_CASO_PARALIZACAO_SLAs { get; set; } = new List<TB_CMCRM_CASO_PARALIZACAO_SLA>();

    public virtual ICollection<TB_CMCRM_CASO_REPASSE_DADO> TB_CMCRM_CASO_REPASSE_DADOID_CASONavigations { get; set; } = new List<TB_CMCRM_CASO_REPASSE_DADO>();

    public virtual ICollection<TB_CMCRM_CASO_REPASSE_DADO> TB_CMCRM_CASO_REPASSE_DADOID_CASO_VENDASNavigations { get; set; } = new List<TB_CMCRM_CASO_REPASSE_DADO>();

    public virtual ICollection<TB_CMCRM_CASO_SLA> TB_CMCRM_CASO_SLAs { get; set; } = new List<TB_CMCRM_CASO_SLA>();

    public virtual ICollection<TB_CMCRM_CASO_SLO> TB_CMCRM_CASO_SLOs { get; set; } = new List<TB_CMCRM_CASO_SLO>();

    public virtual ICollection<TB_CMCRM_CASO_STATUS> TB_CMCRM_CASO_STATUSes { get; set; } = new List<TB_CMCRM_CASO_STATUS>();

    public virtual ICollection<TB_CMCRM_CASO_VENDAS_DADO> TB_CMCRM_CASO_VENDAS_DADOs { get; set; } = new List<TB_CMCRM_CASO_VENDAS_DADO>();

    public virtual ICollection<TB_CMCRM_CASO_VINCULADO> TB_CMCRM_CASO_VINCULADOID_CASO_PAINavigations { get; set; } = new List<TB_CMCRM_CASO_VINCULADO>();

    public virtual ICollection<TB_CMCRM_CASO_VINCULADO> TB_CMCRM_CASO_VINCULADOID_CASO_VINCULADONavigations { get; set; } = new List<TB_CMCRM_CASO_VINCULADO>();

    public virtual ICollection<TB_CMCRM_CASO_VISITum> TB_CMCRM_CASO_VISITa { get; set; } = new List<TB_CMCRM_CASO_VISITum>();

    public virtual ICollection<TB_CMCRM_CASO_VISTORIA_CODIGO_ASSINATURA> TB_CMCRM_CASO_VISTORIA_CODIGO_ASSINATURAs { get; set; } = new List<TB_CMCRM_CASO_VISTORIA_CODIGO_ASSINATURA>();

    public virtual ICollection<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC> TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TECs { get; set; } = new List<TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC>();

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO_PROPONENTE> TB_CMCRM_CONTA_PRODUTO_PROPONENTEs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO_PROPONENTE>();

    public virtual ICollection<TB_CMCRM_EMAIL> TB_CMCRM_EMAILs { get; set; } = new List<TB_CMCRM_EMAIL>();

    public virtual ICollection<TB_CMCRM_EMPREENDIMENTO_PA_CASO> TB_CMCRM_EMPREENDIMENTO_PA_CASOs { get; set; } = new List<TB_CMCRM_EMPREENDIMENTO_PA_CASO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN> TB_CMCRM_ENVELOPE_DOCUSIGNs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN>();

    public virtual ICollection<TB_CMCRM_NOTIFICACAO> TB_CMCRM_NOTIFICACAOs { get; set; } = new List<TB_CMCRM_NOTIFICACAO>();

    public virtual ICollection<TB_CMCRM_OPORTUNIDADE> TB_CMCRM_OPORTUNIDADEs { get; set; } = new List<TB_CMCRM_OPORTUNIDADE>();

    public virtual ICollection<TB_CMCRM_ORCAMENTO> TB_CMCRM_ORCAMENTOs { get; set; } = new List<TB_CMCRM_ORCAMENTO>();

    public virtual ICollection<TB_CMCRM_RESPOSTA_FORMULARIO> TB_CMCRM_RESPOSTA_FORMULARIOs { get; set; } = new List<TB_CMCRM_RESPOSTA_FORMULARIO>();

    public virtual ICollection<TB_CMCRM_SINCRONIZACAO_LOG> TB_CMCRM_SINCRONIZACAO_LOGs { get; set; } = new List<TB_CMCRM_SINCRONIZACAO_LOG>();

    public virtual ICollection<TB_CMCRM_TAG_CASO> TB_CMCRM_TAG_CASOs { get; set; } = new List<TB_CMCRM_TAG_CASO>();

    public virtual ICollection<TB_CMCRM_TEMPO_CONSLUSAO_REAL> TB_CMCRM_TEMPO_CONSLUSAO_REALs { get; set; } = new List<TB_CMCRM_TEMPO_CONSLUSAO_REAL>();

    public virtual ICollection<TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAO> TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAOs { get; set; } = new List<TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAO>();
}
