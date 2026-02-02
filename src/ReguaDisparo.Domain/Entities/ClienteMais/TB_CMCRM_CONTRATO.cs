using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTRATO
{
    public int ID_CONTRATO { get; set; }

    public string DS_HTML_CONTRATO { get; set; } = null!;

    public int ID_USUARIO_RESPONSAVEL { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_CONTRATO_STATUS { get; set; }

    public int? ID_PROPOSTA { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public virtual TB_CMCRM_CONTRATO_STATUS ID_CONTRATO_STATUSNavigation { get; set; } = null!;

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE? ID_DOCUMENTO_TEMPLATENavigation { get; set; }

    public virtual TB_CMCRM_PROPOSTum? ID_PROPOSTANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG> TB_CMCRM_ENVELOPE_DOCUSIGN_LOGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG>();
}
