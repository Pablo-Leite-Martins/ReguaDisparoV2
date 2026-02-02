using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVA
{
    public int ID_FORMULARIO_RESPOSTA_JUSTIFICATIVA { get; set; }

    public int ID_RESPOSTA_JUSTIFICATIVA { get; set; }

    public int ID_RESPOSTA_FORMULARIO { get; set; }

    public virtual TB_CMCRM_RESPOSTA_FORMULARIO ID_RESPOSTA_FORMULARIONavigation { get; set; } = null!;

    public virtual TB_CMCRM_RESPOSTA_JUSTIFICATIVA ID_RESPOSTA_JUSTIFICATIVANavigation { get; set; } = null!;
}
