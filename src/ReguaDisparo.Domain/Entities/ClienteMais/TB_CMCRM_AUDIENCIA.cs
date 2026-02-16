using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AUDIENCIA
{
    public int ID_AUDIENCIA { get; set; }

    public string DS_AUDIENCIA { get; set; } = null!;

    public bool? FL_ATIVO { get; set; }

    public virtual ICollection<TB_CMCRM_AUDIENCIA_CONTATO> TB_CMCRM_AUDIENCIA_CONTATOs { get; set; } = new List<TB_CMCRM_AUDIENCIA_CONTATO>();
}
