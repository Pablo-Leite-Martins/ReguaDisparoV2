using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_MODULO
{
    public int ID_DOCUMENTO_TEMPLATE_MODULO { get; set; }

    public int ID_MODULO { get; set; }

    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE ID_DOCUMENTO_TEMPLATENavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO> TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO>();
}
