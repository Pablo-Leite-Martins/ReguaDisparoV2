using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PLAN_VENDA
{
    public int ID_PLAN_VENDAS { get; set; }

    public int ID_PRODUTO { get; set; }

    public DateOnly DT_MES_REFERENCIA { get; set; }

    public int NR_VENDAS_PLAN { get; set; }

    public decimal VL_FINANCEIRO_PLAN { get; set; }
}
