using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RESPOSTA_JUSTIFICATIVA
{
    public int ID_RESPOSTA_JUSTIFICATIVA { get; set; }

    public string DS_JUSTIFICATIVA { get; set; } = null!;

    public int? ID_RESPOSTA { get; set; }

    public virtual TB_CMCRM_RESPOSTA? ID_RESPOSTANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVA> TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVAs { get; set; } = new List<TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVA>();
}
