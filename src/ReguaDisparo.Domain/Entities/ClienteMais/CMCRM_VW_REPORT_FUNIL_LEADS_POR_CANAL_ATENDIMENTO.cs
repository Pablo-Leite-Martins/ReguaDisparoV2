using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_FUNIL_LEADS_POR_CANAL_ATENDIMENTO
{
    public string DS_NOME { get; set; } = null!;

    public int CONTADOR { get; set; }

    public int FL_VIROU_ATENDIMENTO { get; set; }

    public int FL_VIROU_VISITA { get; set; }

    public int FL_VIROU_PROPOSTA { get; set; }

    public int FL_VIROU_VENDA { get; set; }

    public string? DS_TIPO_CANAL_ATENDIMENTO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_CORRETOR { get; set; }

    public int ID_PRODUTO { get; set; }
}
