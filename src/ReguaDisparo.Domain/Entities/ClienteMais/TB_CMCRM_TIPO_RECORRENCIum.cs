using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_RECORRENCIum
{
    public int ID_TIPO_RECORRENCIA { get; set; }

    public string DS_TIPO_RECORRENCIA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();
}
