using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_EMPRESA
{
    public int ID_EMPRESA { get; set; }

    public int id { get; set; }

    public string? name { get; set; }

    public string? tradeName { get; set; }

    public string? cnpj { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
