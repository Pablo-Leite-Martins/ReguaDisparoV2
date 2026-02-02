using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_FUNIL_LEADS_POR_CORRETOR
{
    public string DS_NOME { get; set; } = null!;

    public int CONTADOR { get; set; }

    public int FL_VIROU_ATENDIMENTO { get; set; }

    public int FL_VIROU_VISITA { get; set; }

    public int FL_VIROU_PROPOSTA { get; set; }

    public int FL_VIROU_VENDA { get; set; }

    public string? CORRETOR { get; set; }

    public int? ID_CORRETOR { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_PRODUTO { get; set; }
}
