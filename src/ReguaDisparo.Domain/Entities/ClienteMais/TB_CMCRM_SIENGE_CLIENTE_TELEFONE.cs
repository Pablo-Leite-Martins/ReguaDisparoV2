using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CLIENTE_TELEFONE
{
    public int ID_CLIENTE_TELEFONE { get; set; }

    public int? idCliente { get; set; }

    public string? number { get; set; }

    public bool? main { get; set; }

    public string? type { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
