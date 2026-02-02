using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_PRODUTO
{
    public int ID_DOCUMENTO_PRODUTO { get; set; }

    public int ID_PRODUTO { get; set; }

    public string DS_DOCUMENTO_PRODUTO { get; set; } = null!;

    public string DS_NOME_ARQUIVO { get; set; } = null!;

    public int? ID_TIPO_DOCUMENTO { get; set; }

    public string? DS_LINK_DRIVE { get; set; }

    public bool? FL_DESTAQUE { get; set; }

    public bool? FL_IMG_IMPLANTACAO { get; set; }

    public bool? FL_DOCUMENTO_FILHO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_DOCUMENTO? ID_TIPO_DOCUMENTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG> TB_CMCRM_ENVELOPE_DOCUSIGN_LOGs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_LOG>();

    public virtual ICollection<TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTO> TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTOs { get; set; } = new List<TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTO>();
}
