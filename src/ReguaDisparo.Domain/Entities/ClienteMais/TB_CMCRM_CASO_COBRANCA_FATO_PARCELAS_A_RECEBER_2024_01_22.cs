using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FATO_PARCELAS_A_RECEBER_2024_01_22
{
    public int ID_CASO_COBRANCA_FATO_PARCELAS_A_RECEBER { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public int ID_PARCELA { get; set; }

    public string ID_TIPO_PARCELA { get; set; } = null!;

    public string DS_TIPO_PARCELA { get; set; } = null!;

    public int ID_PARCELA_GERAL { get; set; }

    public decimal VL_PARCELA { get; set; }

    public decimal VL_PARCELA_PRINCIPAL { get; set; }

    public decimal VL_JUROS_ATRASO { get; set; }

    public decimal VL_MULTA_ATRASO { get; set; }

    public decimal VL_CORRECAO_ATRASO { get; set; }

    public int NR_AGING_PARCELA { get; set; }

    public int NR_AGING_PARCELA_PRORROGACAO { get; set; }

    public DateTime DT_MES_REFERENCIA { get; set; }

    public DateTime DT_VENCIMENTO { get; set; }

    public DateTime DT_PRORROGACAO { get; set; }

    public string DS_INDICE_REAJUSTE { get; set; } = null!;

    public decimal NR_JUROS_PARCELA { get; set; }

    public DateTime DT_ATUALIZACAO { get; set; }

    public string? DS_LINHA_DIGITAVEL { get; set; }
}
