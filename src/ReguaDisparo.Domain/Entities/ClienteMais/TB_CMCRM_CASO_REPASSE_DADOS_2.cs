using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_REPASSE_DADOS_2
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

    public int? NR_PROTOCOLO { get; set; }

    public string? DS_CARTORIO { get; set; }

    public string? NR_MATRICULA { get; set; }

    public decimal? VL_ITBI { get; set; }

    public decimal? VL_DESPESAS_REGISTRO { get; set; }
}
