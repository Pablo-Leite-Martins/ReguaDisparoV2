using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_COMPROMISSO
{
    public int ID_TIPO_COMPROMISSO { get; set; }

    public string DS_TIPO_COMPROMISSO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_COMPROMISSO_DISPONIVEL_VISTORIum> TB_CMCRM_COMPROMISSO_DISPONIVEL_VISTORIa { get; set; } = new List<TB_CMCRM_COMPROMISSO_DISPONIVEL_VISTORIum>();

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();
}
