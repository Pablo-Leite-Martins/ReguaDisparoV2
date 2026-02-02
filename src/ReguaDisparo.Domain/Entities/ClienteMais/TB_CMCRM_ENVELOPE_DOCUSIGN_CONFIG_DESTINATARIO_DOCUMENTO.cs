using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO
{
    public int ID_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO { get; set; }

    public int ID_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO { get; set; }

    public int ID_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO { get; set; }

    public bool FL_RUBRICA { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO ID_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO ID_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTONavigation { get; set; } = null!;
}
