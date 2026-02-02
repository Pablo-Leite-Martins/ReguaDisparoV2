using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_DASHBOARD_ESTOQUE
{
    public int ID_PRODUTO { get; set; }

    public string DS_PRODUTO { get; set; } = null!;

    public int QTDE_TOTAL_UNIDADES { get; set; }

    public int QTDE_TOTAL_UNIDADES_DISPONIVEIS { get; set; }

    public int QTDE_TOTAL_UNIDADES_VENDIDAS { get; set; }

    public decimal VGV_TOTAL { get; set; }

    public decimal VGV_DISPONIVEL { get; set; }

    public decimal VGV_VENDIDO { get; set; }

    public decimal? PERC_QTDE_DISPONIVEL { get; set; }

    public decimal? PERC_QTDE_VENDIDO { get; set; }

    public decimal? PERC_VGV_DISPONIVEL { get; set; }

    public decimal? PERC_VGV_VENDIDO { get; set; }
}
