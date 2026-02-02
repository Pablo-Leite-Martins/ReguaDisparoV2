using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_FERIADO
{
    public int ID_FERIADO { get; set; }

    public string DS_FERIADO { get; set; } = null!;

    public int ID_TIPO_FERIADO { get; set; }

    public int ID_PAIS { get; set; }

    public int? ID_ESTADO { get; set; }

    public int? ID_CIDADE { get; set; }

    public DateOnly DT_FERIADO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;
}
