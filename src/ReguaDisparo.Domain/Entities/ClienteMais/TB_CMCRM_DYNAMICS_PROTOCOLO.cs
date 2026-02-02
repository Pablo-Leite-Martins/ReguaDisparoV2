using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DYNAMICS_PROTOCOLO
{
    public int ID_DYNAMICS_PROTOCOLOS { get; set; }

    public string numeroOcorrencia { get; set; } = null!;

    public string? assunto { get; set; }

    public DateTime startDate { get; set; }

    public DateTime endDate { get; set; }
}
