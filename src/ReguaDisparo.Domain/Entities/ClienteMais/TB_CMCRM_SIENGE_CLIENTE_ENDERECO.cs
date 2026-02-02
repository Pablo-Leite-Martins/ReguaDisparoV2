using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CLIENTE_ENDERECO
{
    public int ID_CLIENTE_ENDERECO { get; set; }

    public int? idCliente { get; set; }

    public string? city { get; set; }

    public string? complement { get; set; }

    public string? neighborhood { get; set; }

    public string? number { get; set; }

    public string? state { get; set; }

    public string? streetName { get; set; }

    public string? type { get; set; }

    public string? zipCode { get; set; }

    public bool? mail { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
