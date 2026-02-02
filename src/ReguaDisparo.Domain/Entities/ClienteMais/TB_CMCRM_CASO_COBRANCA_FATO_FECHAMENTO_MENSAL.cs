using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FATO_FECHAMENTO_MENSAL
{
    public int ID_CASO_COBRANCA_FATO_FECHAMENTO_MENSAL { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public DateTime DT_MES_REFERENCIA { get; set; }

    public decimal? VL_FATURADO_MES { get; set; }

    public decimal? VL_RECEBIDO_MES { get; set; }

    public decimal? VL_INADIMPLENCIA_MES { get; set; }

    public decimal? VL_PERC_INADIMPLENCIA_MES { get; set; }

    public decimal? VL_ESTOQUE_ANTERIOR { get; set; }

    public decimal? VL_RECUPERACAO_MES { get; set; }

    public decimal? VL_PERC_RECUPERACAO_MES { get; set; }

    public decimal? VL_ESTOQUE_ACUMULADO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }
}
