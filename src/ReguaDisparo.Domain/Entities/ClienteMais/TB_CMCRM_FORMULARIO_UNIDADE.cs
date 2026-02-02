using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_UNIDADE
{
    public int ID_FORMULARIO_UNIDADE { get; set; }

    public int ID_FORMULARIO { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_FORMULARIO ID_FORMULARIONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
