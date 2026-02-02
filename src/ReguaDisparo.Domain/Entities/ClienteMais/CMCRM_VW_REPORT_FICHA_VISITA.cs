using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_FICHA_VISITA
{
    public int ID_CONTA { get; set; }

    public int ID_CASO_VISITA { get; set; }

    public bool FL_EFETIVADA { get; set; }

    public string CLIENTE { get; set; } = null!;

    public string? EMAIL { get; set; }

    public string? TELEFONE { get; set; }

    public string? ORIGEM { get; set; }

    public string? CORRETOR { get; set; }

    public int? ID_EQUIPE { get; set; }

    public string? EQUIPE { get; set; }

    public int? ID_PONTO_VENDA { get; set; }

    public string? PONTO_VENDA { get; set; }

    public string? TIPO_VISITA { get; set; }

    public DateTime? DATA_VISITA { get; set; }
}
