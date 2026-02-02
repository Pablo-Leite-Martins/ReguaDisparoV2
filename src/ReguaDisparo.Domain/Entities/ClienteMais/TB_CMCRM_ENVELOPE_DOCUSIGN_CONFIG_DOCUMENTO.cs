using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO
{
    public int ID_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO { get; set; }

    public int NR_ORDEM { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public int? ID_DOCUMENTO_PRODUTO { get; set; }

    public int? ID_ENVELOPE_DOCUSIGN_CONFIG { get; set; }

    public int? ID_DOCUMENTO_CASO { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_PRODUTO? ID_DOCUMENTO_PRODUTONavigation { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE? ID_DOCUMENTO_TEMPLATENavigation { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG? ID_ENVELOPE_DOCUSIGN_CONFIGNavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO>();
}
