using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_LOG
{
    public int ID_ENVELOPE_DOCUSIGN_LOG { get; set; }

    public string DS_ENVELOPE_DOCUSIGN_LOG { get; set; } = null!;

    public DateTime DT_ENVELOPE_DOCUSIGN_LOG { get; set; }

    public int ID_ENVELOPE_DOCUSIGN { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CONTATO { get; set; }

    public int? ID_USUARIO { get; set; }

    public int? ID_CONTRATO { get; set; }

    public int? ID_DOCUMENTO_PRODUTO { get; set; }

    public int ID_USUARIO_RESPONSAVEL { get; set; }

    public virtual TB_CMCRM_CONTum? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_CONTATO? ID_CONTATONavigation { get; set; }

    public virtual TB_CMCRM_CONTRATO? ID_CONTRATONavigation { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_PRODUTO? ID_DOCUMENTO_PRODUTONavigation { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN ID_ENVELOPE_DOCUSIGNNavigation { get; set; } = null!;
}
