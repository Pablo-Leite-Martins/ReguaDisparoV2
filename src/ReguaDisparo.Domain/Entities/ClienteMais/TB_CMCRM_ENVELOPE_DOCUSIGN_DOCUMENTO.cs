using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO
{
    public int ID_ENVELOPE_DOCUSIGN_DOCUMENTO { get; set; }

    public int ID_ENVELOPE_DOCUSIGN { get; set; }

    public int? ID_CONTRATO { get; set; }

    public int? ID_DOCUMENTO_PRODUTO { get; set; }

    public int NR_ORDEM { get; set; }

    public int? ID_DOCUMENTO_CASO { get; set; }

    public virtual TB_CMCRM_CONTRATO? ID_CONTRATONavigation { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_PRODUTO? ID_DOCUMENTO_PRODUTONavigation { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN ID_ENVELOPE_DOCUSIGNNavigation { get; set; } = null!;
}
