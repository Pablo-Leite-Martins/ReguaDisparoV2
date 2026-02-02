using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_PARCELAS_PAGA
{
    public int ID_CASO_COBRANCA_FATO_PARCELAS_A_RECEBER { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public int? ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int? ID_VENDA { get; set; }

    public int? ID_PARCELA { get; set; }

    public int? ID_TIPO_PARCELA { get; set; }

    public string? DS_TIPO_PARCELA { get; set; }

    public int? ID_PARCELA_GERAL { get; set; }

    public int? NUMERO_PARCELA { get; set; }

    public decimal? VL_ORIGINAL { get; set; }

    public DateTime? DATA_PAGAMENTO { get; set; }

    public decimal? VL_PARCELA { get; set; }

    public decimal? VL_DESCONTO_BOLETO { get; set; }

    public decimal? VL_HONORARIO { get; set; }

    public decimal? VL_HONORARIO_A_RECEBER { get; set; }

    public decimal? VL_HONORARIO_RECEBIDO { get; set; }

    public decimal? VL_PARCELA_PRINCIPAL { get; set; }

    public decimal? VL_MULTA_ATRASO { get; set; }

    public decimal? VL_JUROS_ATRASO { get; set; }

    public decimal? VL_CORRECAO_ATRASO { get; set; }

    public decimal? VL_TOTAL_RECEBIDO { get; set; }

    public int? NR_AGING_PARCELA { get; set; }

    public int? NR_AGING_PARCELA_PRORROGACAO { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }

    public DateTime? DT_VENCIMENTO { get; set; }

    public DateTime? DT_PRORROGACAO { get; set; }

    public int? DS_INDICE_REAJUSTE { get; set; }

    public int? NR_JUROS_PARCELA { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public string? STATUS_PARCELA { get; set; }

    public string? DS_NOME { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_BAIRRO { get; set; }

    public string? DS_LOGRADOURO { get; set; }

    public string? NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string? NR_CEP { get; set; }

    public string? BOLETO_BANCO { get; set; }

    public string? BOLETO_TEXTO_4 { get; set; }

    public string? BOLETO_NUMERODOCUMENTO { get; set; }

    public string? BOLETO_ESPECIE { get; set; }

    public string? BOLETO_CARTEIRA { get; set; }

    public string? BOLETO_ACEITE { get; set; }

    public string? BOLETO_MOEDA { get; set; }

    public string? STATUS_BOLETO { get; set; }

    public int? COD_STATUS_BOLETO { get; set; }

    public DateTime? VENCIMENTO_BOLETO { get; set; }

    public decimal? VALOR_BOLETO { get; set; }

    public string? BOLETO_NOME_CEDENTE { get; set; }

    public string? BOLETO_AGENCIA_CEDENTE { get; set; }

    public string? BOLETO_NOSSONUMERO { get; set; }

    public string? BOLETO_TEXTO_1 { get; set; }

    public string? BOLETO_TEXTO_2 { get; set; }

    public string? BOLETO_TEXTO_3 { get; set; }

    public string? DS_LINHA_DIGITAVEL { get; set; }

    public string? CODIGOBARRA { get; set; }

    public string? PIX_COPIA_COLA { get; set; }

    public string? QRCODE_PIX { get; set; }
}
