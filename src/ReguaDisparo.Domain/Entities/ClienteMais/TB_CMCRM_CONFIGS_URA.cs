using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIGS_URA
{
    public int ID_CONFIG_URA { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO ID_CATEGORIA_ATENDIMENTONavigation { get; set; } = null!;
}
