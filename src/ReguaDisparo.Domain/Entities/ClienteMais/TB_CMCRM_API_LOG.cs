using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_API_LOG
{
    public int ID_API_LOG { get; set; }

    public DateTime DT_HORARIO { get; set; }

    public string DS_API { get; set; } = null!;

    public string DS_METODO_API { get; set; } = null!;

    public int NR_REGISTROS { get; set; }
}
