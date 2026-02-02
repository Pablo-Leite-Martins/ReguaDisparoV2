using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO
{
    public int ID_ENVELOPE_DOCUSIGN_DESTINATARIO { get; set; }

    public int ID_ENVELOPE_DOCUSIGN { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CONTATO { get; set; }

    public int? ID_USUARIO { get; set; }

    public bool FL_ASSINATURA { get; set; }

    public int NR_ORDEM { get; set; }

    public string? DS_STATUS { get; set; }

    public DateTime? DT_STATUS { get; set; }

    public int? ID_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public DateTime? DT_ENTREGA { get; set; }

    public DateTime? DT_ASSINATURA { get; set; }

    public virtual TB_CMCRM_CONTum? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_CONTATO? ID_CONTATONavigation { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN ID_ENVELOPE_DOCUSIGNNavigation { get; set; } = null!;
}
