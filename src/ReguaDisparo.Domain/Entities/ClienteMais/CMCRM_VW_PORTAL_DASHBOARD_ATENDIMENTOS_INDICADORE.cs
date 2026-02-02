using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_PORTAL_DASHBOARD_ATENDIMENTOS_INDICADORE
{
    public int ID_CONTA { get; set; }

    public int? QTDE_ATENDIMENTOS_ABERTOS { get; set; }

    public int? QTDE_ATENDIMENTOS_FECHADOS { get; set; }

    public int? QTDE_ATENDIMENTOS_TOTAL { get; set; }
}
