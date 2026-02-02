using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_OBRA
{
    public int ID_CASO_COBRANCA_OBRAS { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int? ID_USUARIO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }
}
