using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMPROMISSO_DISPONIVEL_VISTORIA_HORARIO
{
    public string DS_HORARIO { get; set; } = null!;

    public string? ID_HORARIO { get; set; }

    public int? NR_ORDEM { get; set; }

    public int ID_COMPROMISSO_VISTORIA_DISPONIVEL_HORARIO { get; set; }
}
