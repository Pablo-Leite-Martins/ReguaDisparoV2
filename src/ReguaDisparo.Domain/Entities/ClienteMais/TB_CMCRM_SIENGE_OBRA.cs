using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SIENGE_OBRA
{
    public int ID_OBRA { get; set; }

    public int? id { get; set; }

    public string? name { get; set; }

    public string? cnpj { get; set; }

    public string? type { get; set; }

    public string? adress { get; set; }

    public DateTime? creationDate { get; set; }

    public DateTime? modificationDate { get; set; }

    public string? createdBy { get; set; }

    public string? modifiedBy { get; set; }

    public DateTime? dt_mes_referencia { get; set; }

    public int? ID_EMPRESA { get; set; }
}
