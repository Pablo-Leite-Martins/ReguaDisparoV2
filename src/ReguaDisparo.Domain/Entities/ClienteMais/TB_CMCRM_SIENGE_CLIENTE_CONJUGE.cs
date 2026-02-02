using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_CLIENTE_CONJUGE
{
    public int ID_CLIENTE_CONJUGE { get; set; }

    public int idCliente { get; set; }

    public string? cpf { get; set; }

    public string? name { get; set; }

    public string? email { get; set; }

    public string? sex { get; set; }

    public string? civilStatus { get; set; }

    public DateTime? birthDate { get; set; }

    public string? numberIdentityCard { get; set; }

    public DateTime? dt_mes_referencia { get; set; }
}
