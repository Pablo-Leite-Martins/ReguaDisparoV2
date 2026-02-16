using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_VISITA
{
    public int ID_TIPO_VISITA { get; set; }

    public string DS_TIPO_VISITA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_VISITA> TB_CMCRM_CASO_VISITa { get; set; } = new List<TB_CMCRM_CASO_VISITA>();
}
