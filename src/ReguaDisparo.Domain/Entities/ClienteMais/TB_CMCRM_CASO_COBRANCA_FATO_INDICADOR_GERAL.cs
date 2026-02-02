using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FATO_INDICADOR_GERAL
{
    public int ID_CASO_COBRANCA_FATO_INDICADOR_GERAL { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int? ID_VENDA { get; set; }

    public int? NR_CONTRATOS_ATIVOS { get; set; }

    public int? NR_CONTRATOS_INADIMPLENTES1 { get; set; }

    public decimal? VL_INADIMPLENCIA1 { get; set; }

    public decimal? NR_PERC_INADIMPLENCIA1 { get; set; }

    public int? NR_CONTRATOS_INADIMPLENTES2 { get; set; }

    public decimal? VL_INADIMPLENCIA2 { get; set; }

    public decimal? NR_PERC_INADIMPLENCIA2 { get; set; }

    public decimal? VL_TOTAL_CARTEIRA { get; set; }

    public decimal? NR_PERC_INADIMPLENCIA_CARTEIRA { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }
}
