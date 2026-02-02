using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_PORTAL_DASHBOARD_ATENDIMENTOS_POR_PRODUTO
{
    public int ID_CONTA { get; set; }

    public string DS_NOME { get; set; } = null!;

    public string DS_PRODUTO { get; set; } = null!;

    public int? QTDE_ATENDIMENTOS { get; set; }
}
