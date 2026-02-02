using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_REPASSE_DADO
{
    public int ID_CASO_REPASSE_DADOS { get; set; }

    public decimal? VL_FINANCIAMENTO { get; set; }

    public int? ID_BANCO { get; set; }

    public int ID_CASO { get; set; }

    public decimal? VL_FGTS { get; set; }

    public decimal? VL_SUBSIDIO { get; set; }

    public decimal? VL_FINANCIAMENTO_CONFIRMADO { get; set; }

    public decimal? VL_FGTS_CONFIRMADO { get; set; }

    public decimal? VL_SUBSIDIO_CONFIRMADO { get; set; }

    public int? ID_CASO_VENDAS { get; set; }

    public DateTime? DT_ASSINATURA_CAIXA { get; set; }

    public DateTime? DT_REGISTRO_CONFORME { get; set; }

    public DateTime? DT_ENTRADA { get; set; }

    public DateTime? DT_PREVISAO_SAIDA { get; set; }

    public DateTime? DT_RETIRADA { get; set; }

    public DateTime? DT_PREVISAO_CONFORMIDADE { get; set; }

    public string? NR_CONTRATO { get; set; }

    public decimal? VL_TERRENO { get; set; }

    public decimal? VL_RECURSO_LIBERADO { get; set; }

    public string? NR_PROTOCOLO { get; set; }

    public string? DS_CARTORIO { get; set; }

    public string? NR_MATRICULA { get; set; }

    public decimal? VL_ITBI { get; set; }

    public decimal? VL_DESPESAS_REGISTRO { get; set; }

    public DateTime? DT_ENVIO_CEHOP { get; set; }

    public DateTime? DT_CONFORMIDADE_CEHOP { get; set; }

    public DateTime? DT_RECEBIMENTO_KIT { get; set; }

    public DateTime? DT_SOLICITACAO_ITBI { get; set; }

    public DateTime? DT_EMISSAO_GUIA_ITBI { get; set; }

    public DateTime? DT_ENVIO_PARA_FINANCEIRO { get; set; }

    public DateTime? DT_PAGAMENTO { get; set; }

    public DateTime? DT_PRENOTACAO { get; set; }

    public DateTime? DT_RECEBIMENTO_COMPROVANTE { get; set; }

    public DateTime? DT_LIBERACAO_CARTORIO { get; set; }

    public DateTime? DT_SOLICITACAO_QUITACAO_ITBI { get; set; }

    public DateTime? DT_ORCAMENTO_CARTORIO { get; set; }

    public DateTime? DT_RECEBIMENTO_GARANTIA_CEHOP { get; set; }

    public DateTime? DT_EMISSAO_ERP { get; set; }

    public DateTime? DT_ASSINATURA_ERP { get; set; }

    public DateTime? DT_MINUTA_CAIXA { get; set; }

    public DateTime? DT_DISTRATO { get; set; }

    public decimal? VL_ORIGINAL { get; set; }

    public decimal? VL_A_CONFIRMAR { get; set; }

    public DateTime? DT_VALIDADE_SICAQ { get; set; }

    public int? ID_AGENCIA_VINCULACAO { get; set; }

    public DateTime? DT_SOLICITACAO_ISENCAO_ITBI { get; set; }

    public decimal? VL_A_CONFIRMAR_MAX { get; set; }

    public decimal? VL_FINANCIAMENTO_CONFIRMADO_MAX { get; set; }

    public decimal? VL_FGTS_CONFIRMADO_MAX { get; set; }

    public decimal? VL_SUBSIDIO_CONFIRMADO_MAX { get; set; }

    public decimal? VL_EMULENTOS { get; set; }

    public decimal? VL_LAUDEMIO { get; set; }

    public int? ID_TIPO_MODALIDADE { get; set; }

    public int? ID_USUARIO_CCA { get; set; }

    public int? ID_CARTORIO { get; set; }

    public decimal? VL_RENDA_PROPONENTE { get; set; }

    public DateTime? DT_SOLICITACAO_LAUDEMIO { get; set; }

    public DateTime? DT_EMISSÂO_GUIA_LAUDEMIO { get; set; }

    public DateTime? DT_ENVIO_LAUDEMIO_FINANCEIRO { get; set; }

    public DateTime? DT_NUM_RIP_SPU { get; set; }

    public string? NR_RIP_SPU { get; set; }

    public DateTime? DT_PAGAMENTO_LAUDEMIO { get; set; }

    public DateTime? DT_COMPROV_LAUDEMIO { get; set; }

    public DateTime? DT_TQ_CAT_SPU { get; set; }

    public decimal? VL_RENDA_FAMILIAR_HYPNO { get; set; }

    public string? DS_CATEGORIA_USO { get; set; }

    public int? ID_TIPO_CONTRATO_REPASSE { get; set; }

    public DateTime? DT_FINALIZACAO { get; set; }

    public DateTime? DT_APROVACAO { get; set; }

    public string? DS_MATRICULA_VAGA { get; set; }

    public string? DS_MATRICULA_UNIDADE { get; set; }

    public string? DS_MATRICULA_CCI_UNIDADE { get; set; }

    public string? DS_MATRICULA_CCI_VAGA { get; set; }

    public string? DS_IPTU_VAGA { get; set; }

    public string? DS_IPTU_UNIDADE { get; set; }

    public decimal? VL_VMD { get; set; }

    public decimal? VL_AVALIACAO_VISTORIA_BANCO { get; set; }

    public decimal? VL_SALDO_DEVEDOR { get; set; }

    public decimal? VL_AVALIACAO_BANCO_UNIDADE { get; set; }

    public decimal? VL_AVALIACAO_BANCO_VAGA { get; set; }

    public virtual TB_CMCRM_AGENCIA_VINCULACAO? ID_AGENCIA_VINCULACAONavigation { get; set; }

    public virtual TB_CMCRM_CARTORIO? ID_CARTORIONavigation { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_CASO? ID_CASO_VENDASNavigation { get; set; }

    public virtual TB_CMCRM_TIPO_MODALIDADE? ID_TIPO_MODALIDADENavigation { get; set; }
}
