using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG
{
    public int ID_ENVELOPE_DOCUSIGN_CONFIG { get; set; }

    public string? DS_ENVELOPE { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN> TB_CMCRM_ENVELOPE_DOCUSIGNs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN>();
}
