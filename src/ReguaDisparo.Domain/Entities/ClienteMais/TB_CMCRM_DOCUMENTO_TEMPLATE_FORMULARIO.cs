using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE_FORMULARIO
{
    public int ID_DOCUMENTO_TEMPLATE_FORMULARIO { get; set; }

    public int ID_DOCUMENTO_TEMPLATE_MODULO { get; set; }

    public int ID_FORMULARIO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE_MODULO ID_DOCUMENTO_TEMPLATE_MODULONavigation { get; set; } = null!;

    public virtual TB_CMCRM_FORMULARIO ID_FORMULARIONavigation { get; set; } = null!;
}
