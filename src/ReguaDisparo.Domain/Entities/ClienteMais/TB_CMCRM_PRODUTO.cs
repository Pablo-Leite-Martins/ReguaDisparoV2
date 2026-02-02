using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO
{
    public int ID_PRODUTO { get; set; }

    public string DS_PRODUTO { get; set; } = null!;

    public int ID_CLASSIFICACAO_PRODUTO { get; set; }

    public int? ID_PRODUTO_PAI { get; set; }

    public string? DS_PRODUTO_COMP { get; set; }

    public int? ID_ESTADO { get; set; }

    public int? ID_CIDADE { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public DateTime? DT_INICIO_GARANTIA { get; set; }

    public string? DS_PAIS { get; set; }

    public string? DS_ESTADO { get; set; }

    public string? DS_CIDADE { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? DS_CEP { get; set; }

    public int? NR_NUMERO { get; set; }

    public int? ID_LUGAR { get; set; }

    public string? DS_STATUS { get; set; }

    public int? NR_QUARTOS { get; set; }

    public int? NR_VAGAS { get; set; }

    public int? NR_QUADRAS { get; set; }

    public string? NR_QUADRA { get; set; }

    public int? NR_ANDARES { get; set; }

    public int? NR_ANDAR { get; set; }

    public string? DS_BLOCO { get; set; }

    public string? DS_TORRE { get; set; }

    public decimal? VL_METROS_QUADRADOS { get; set; }

    public decimal? VL_FRACAO_IDEAL { get; set; }

    public decimal? VL_PRECO { get; set; }

    public int? ID_TIPO_PRODUTO { get; set; }

    public string? DS_SPE_NOME { get; set; }

    public string? NR_SPE_CNPJ { get; set; }

    public string? DS_SPE_TELEFONE { get; set; }

    public string? DS_SPE_EMAIL { get; set; }

    public string? DS_SPE_PAIS { get; set; }

    public string? DS_SPE_ESTADO { get; set; }

    public string? DS_SPE_CIDADE { get; set; }

    public string? DS_SPE_BAIRRO { get; set; }

    public string? DS_SPE_LOGRADOURO { get; set; }

    public string? DS_SPE_CEP { get; set; }

    public int? NR_SPE_NUMERO { get; set; }

    public string? ID_SPE_LUGAR { get; set; }

    public string? NR_ALVARA { get; set; }

    public DateTime? DT_PREVISAO_CONCLUSAO { get; set; }

    public string? DS_REGISTRO_INCORPORACAO { get; set; }

    public string? DS_FICHA_TECNICA { get; set; }

    public DateTime? DT_RESERVA_FIM { get; set; }

    public int? ID_RESERVA_USUARIO { get; set; }

    public int? ID_RESERVA_CONTA { get; set; }

    public string? DS_VAGAS { get; set; }

    public decimal? VL_AVALIACAO_CAIXA { get; set; }

    public string? DS_MATRICULA_IMOVEL { get; set; }

    public DateTime? DT_RESERVA_INICIO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public string? DS_SPE_COMPLEMENTO { get; set; }

    public bool? FL_PRODUTO_ATIVO_VENDAS { get; set; }

    public string? NR_MATRICULA { get; set; }

    public string? ID_CHAVE_ERP_PRODUTO { get; set; }

    public string? ID_CHAVE_ERP_CONTRATO { get; set; }

    public string? DS_CAMINHO_IMAGEM_LOGO { get; set; }

    public string? DS_BONIFICACAO { get; set; }

    public DateTime? DT_INICIO_BONIFICACAO { get; set; }

    public DateTime? DT_FIM_BONIFICACAO { get; set; }

    public decimal? VL_AREA_PRIVATIVA { get; set; }

    public decimal? VL_AREA_COMUM { get; set; }

    public DateTime? DT_HABITESE { get; set; }

    public bool? FL_MIRROR { get; set; }

    public decimal? VL_PERCENTUAL_EMPRESA { get; set; }

    public decimal? VL_PERCENTUAL_TERRENEIRO { get; set; }

    public string? DS_IMAGEM_IMPLANTACAO { get; set; }

    public decimal? VL_IMAGEM_IMPLANTACAO_MARGEM_VERTICAL { get; set; }

    public decimal? VL_IMAGEM_IMPLANTACAO_MARGEM_HORIZONTAL { get; set; }

    public int? ID_CHAVE_ERP_PERSONALIZACAO { get; set; }

    public string? DS_TIPO_GARANTIA { get; set; }

    public string? DS_TAG_IMPORTACAO { get; set; }

    public int? NR_RESERVA_HORAS { get; set; }

    public string? NR_PRODUTO { get; set; }

    public string? DS_LOGRADOURO_PRODUTO { get; set; }

    public decimal? VL_MEDIDA_FRENTE { get; set; }

    public decimal? VL_MEDIDA_FUNDOS { get; set; }

    public decimal? VL_MEDIDA_DIREITA { get; set; }

    public decimal? VL_MEDIDA_ESQUERDA { get; set; }

    public string? DS_CONFRONTANTE_FRENTE { get; set; }

    public string? DS_CONFRONTANTE_FUNDOS { get; set; }

    public string? DS_CONFRONTANTE_DIREITA { get; set; }

    public string? DS_CONFRONTANTE_ESQUERDA { get; set; }

    public bool? FL_RESERVA_ESPELHO { get; set; }

    public decimal? VL_IPTU { get; set; }

    public decimal? VL_CONDOMINIO { get; set; }

    public bool? FL_MANTER_STATUS { get; set; }

    public int? NR_TAMANHO_PIXEL_MAPA { get; set; }

    public int? NR_TAMANHO_FONTE_MAPA { get; set; }

    public string? DS_INFO_HABITESE { get; set; }

    public string? DS_ESCANINHO { get; set; }

    public decimal? VL_ESCANINHO { get; set; }

    public decimal? VL_ACESSAO { get; set; }

    public bool? FL_PRODUTO_ATIVO_VISTORIA { get; set; }

    public string? DS_CIDADE_COMARCA { get; set; }

    public int? NR_VAGAS_PCD { get; set; }

    public decimal? VL_METRAGEM_UNIDADE { get; set; }

    public int? ID_ETAPA_JORNADA { get; set; }

    public DateTime? DT_ENTREGA_CHAVES { get; set; }

    public DateTime? DT_RAI { get; set; }

    public DateTime? DT_DEMANDA_MININA { get; set; }

    public int? ID_SEGMENTO { get; set; }

    public int? ID_TIPO_INCORPORACAO { get; set; }

    public string? DS_ENDERECO_SITE { get; set; }

    public int? ID_REGIAO { get; set; }

    public int? ID_SITUACAO_COMERCIAL { get; set; }

    public int? ID_SITUACAO_OBRA { get; set; }

    public string? VL_PRAZOS_FINANCIAMENTO_SEM_JUROS { get; set; }

    public string? VL_PRAZOS_FINANCIAMENTO_COM_JUROS { get; set; }

    public decimal? VL_TAXA_JUROS_MENSAL { get; set; }

    public decimal? VL_TAXA_JUROS_ANUAL { get; set; }

    public decimal? VL_PERCENTUAL_ENTRADA { get; set; }

    public decimal? VL_PERCENTUAL_ANUAIS { get; set; }

    public virtual TB_CMCRM_CLASSIFICACAO_PRODUTO ID_CLASSIFICACAO_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ETAPA_JORNADum? ID_ETAPA_JORNADANavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTO_PAINavigation { get; set; }

    public virtual TB_CMCRM_TIPO_PRODUTO? ID_TIPO_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_PRODUTO> InverseID_PRODUTO_PAINavigation { get; set; } = new List<TB_CMCRM_PRODUTO>();

    public virtual ICollection<TB_CMCRM_AREA_COMUM_PRODUTO> TB_CMCRM_AREA_COMUM_PRODUTOs { get; set; } = new List<TB_CMCRM_AREA_COMUM_PRODUTO>();

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();

    public virtual ICollection<TB_CMCRM_CONTA_PRODUTO> TB_CMCRM_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_DADOS_PRODUTO> TB_CMCRM_DADOS_PRODUTOs { get; set; } = new List<TB_CMCRM_DADOS_PRODUTO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_PRODUTO> TB_CMCRM_DOCUMENTO_PRODUTOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_PRODUTO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE> TB_CMCRM_DOCUMENTO_TEMPLATEs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE>();

    public virtual ICollection<TB_CMCRM_EMAIL_REGUA_PESQUISA> TB_CMCRM_EMAIL_REGUA_PESQUISAs { get; set; } = new List<TB_CMCRM_EMAIL_REGUA_PESQUISA>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG>();

    public virtual ICollection<TB_CMCRM_EQUIPE_VENDAS_PRODUTO> TB_CMCRM_EQUIPE_VENDAS_PRODUTOs { get; set; } = new List<TB_CMCRM_EQUIPE_VENDAS_PRODUTO>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTO> TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTOs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTO>();

    public virtual ICollection<TB_CMCRM_FINANCEIRO_EMPREENDIMENTO> TB_CMCRM_FINANCEIRO_EMPREENDIMENTOs { get; set; } = new List<TB_CMCRM_FINANCEIRO_EMPREENDIMENTO>();

    public virtual TB_CMCRM_FORMULARIO_PRODUTO? TB_CMCRM_FORMULARIO_PRODUTO { get; set; }

    public virtual ICollection<TB_CMCRM_FORMULARIO_UNIDADE> TB_CMCRM_FORMULARIO_UNIDADEs { get; set; } = new List<TB_CMCRM_FORMULARIO_UNIDADE>();

    public virtual ICollection<TB_CMCRM_GARANTIA_PRODUTO> TB_CMCRM_GARANTIA_PRODUTOs { get; set; } = new List<TB_CMCRM_GARANTIA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_IDEIA> TB_CMCRM_IDEIAs { get; set; } = new List<TB_CMCRM_IDEIA>();

    public virtual ICollection<TB_CMCRM_INTERESSE_CONTA_PRODUTO> TB_CMCRM_INTERESSE_CONTA_PRODUTOID_PRODUTO_PRINCIPALNavigations { get; set; } = new List<TB_CMCRM_INTERESSE_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_INTERESSE_CONTA_PRODUTO> TB_CMCRM_INTERESSE_CONTA_PRODUTOID_PRODUTO_SECUNDARIONavigations { get; set; } = new List<TB_CMCRM_INTERESSE_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_INTERESSE_CONTA_PRODUTO> TB_CMCRM_INTERESSE_CONTA_PRODUTOID_PRODUTO_TERCIARIONavigations { get; set; } = new List<TB_CMCRM_INTERESSE_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_KIT_UNIDADE> TB_CMCRM_KIT_UNIDADEs { get; set; } = new List<TB_CMCRM_KIT_UNIDADE>();

    public virtual ICollection<TB_CMCRM_MODELO_VENDA_PRODUTO> TB_CMCRM_MODELO_VENDA_PRODUTOs { get; set; } = new List<TB_CMCRM_MODELO_VENDA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_MODELO_VENDum> TB_CMCRM_MODELO_VENDa { get; set; } = new List<TB_CMCRM_MODELO_VENDum>();

    public virtual ICollection<TB_CMCRM_OPORTUNIDADE_PRODUTO> TB_CMCRM_OPORTUNIDADE_PRODUTOs { get; set; } = new List<TB_CMCRM_OPORTUNIDADE_PRODUTO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_PRODUTO> TB_CMCRM_ORIGEM_LEAD_PRODUTOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_PRODUTO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD> TB_CMCRM_ORIGEM_LEADs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD>();

    public virtual ICollection<TB_CMCRM_PRODUTO_ANUNCIO> TB_CMCRM_PRODUTO_ANUNCIOs { get; set; } = new List<TB_CMCRM_PRODUTO_ANUNCIO>();

    public virtual ICollection<TB_CMCRM_PRODUTO_CLIENTE> TB_CMCRM_PRODUTO_CLIENTEs { get; set; } = new List<TB_CMCRM_PRODUTO_CLIENTE>();

    public virtual ICollection<TB_CMCRM_PRODUTO_CONTATO> TB_CMCRM_PRODUTO_CONTATOs { get; set; } = new List<TB_CMCRM_PRODUTO_CONTATO>();

    public virtual ICollection<TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTO> TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTOs { get; set; } = new List<TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTO>();

    public virtual ICollection<TB_CMCRM_PRODUTO_RESERVA> TB_CMCRM_PRODUTO_RESERVAs { get; set; } = new List<TB_CMCRM_PRODUTO_RESERVA>();

    public virtual ICollection<TB_CMCRM_PRODUTO_SPE_USUARIO> TB_CMCRM_PRODUTO_SPE_USUARIOs { get; set; } = new List<TB_CMCRM_PRODUTO_SPE_USUARIO>();

    public virtual ICollection<TB_CMCRM_PRODUTO_TIPO_CARACTERISTICA> TB_CMCRM_PRODUTO_TIPO_CARACTERISTICAs { get; set; } = new List<TB_CMCRM_PRODUTO_TIPO_CARACTERISTICA>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_PRODUTO> TB_CMCRM_PROPOSTA_PRODUTOs { get; set; } = new List<TB_CMCRM_PROPOSTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_SUBCATEGORIA_ATENDIMENTO> TB_CMCRM_SUBCATEGORIA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_SUBCATEGORIA_ATENDIMENTO>();

    public virtual ICollection<TB_CMCRM_UNIDADE_PRECO> TB_CMCRM_UNIDADE_PRECOs { get; set; } = new List<TB_CMCRM_UNIDADE_PRECO>();

    public virtual ICollection<TB_CMCRM_UNIDADE> TB_CMCRM_UNIDADEs { get; set; } = new List<TB_CMCRM_UNIDADE>();
}
