using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RESPOSTum
{
    public int ID_RESPOSTA { get; set; }

    public string DS_RESPOSTA { get; set; } = null!;

    public int NR_PESO { get; set; }

    public int ID_PERGUNTA { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_PERGUNTum ID_PERGUNTANavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_RESPOSTA_FORMULARIO> TB_CMCRM_RESPOSTA_FORMULARIOs { get; set; } = new List<TB_CMCRM_RESPOSTA_FORMULARIO>();

    public virtual ICollection<TB_CMCRM_RESPOSTA_JUSTIFICATIVA> TB_CMCRM_RESPOSTA_JUSTIFICATIVAs { get; set; } = new List<TB_CMCRM_RESPOSTA_JUSTIFICATIVA>();
}
