using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_MODULO
{
    public int ID_FORMULARIO_MODULO { get; set; }

    public int ID_FORMULARIO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_FORMULARIO ID_FORMULARIONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CASO ID_TIPO_CASONavigation { get; set; } = null!;
}
