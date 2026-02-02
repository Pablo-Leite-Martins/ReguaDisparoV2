using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN
{
    public int ID_ENVELOPE_DOCUSIGN { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_CRIACAO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public string? DS_GUID_ENVELOPE { get; set; }

    public string DS_STATUS { get; set; } = null!;

    public string? DS_URL_DOCUMENTO { get; set; }

    public int ID_USUARIO_CRIACAO { get; set; }

    public string? DS_LOG { get; set; }

    public int? ID_ENVELOPE_DOCUSIGN_CONFIG { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG? ID_ENVELOPE_DOCUSIGN_CONFIGNavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO> TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DESTINATARIO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG> TB_CMCRM_ENVELOPE_DOCUSIGN_LOGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG>();
}
