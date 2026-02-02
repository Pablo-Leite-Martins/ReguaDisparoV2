using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO
{
    public int ID_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO { get; set; }

    public int NR_ORDEM { get; set; }

    public int? ID_TIPO_RELACAO_CLIENTE { get; set; }

    public bool? FL_PROPONENTE { get; set; }

    public bool? FL_USUARIO_RESPONSAVEL_CASO { get; set; }

    public bool? FL_USUARIO_RESPONSAVEL_CONTA { get; set; }

    public bool? FL_GERENTE { get; set; }

    public bool? FL_GERENTE_REGIONAL { get; set; }

    public bool? FL_DIRETOR { get; set; }

    public int? ID_USUARIO { get; set; }

    public bool? FL_COORDENADOR_VENDAS { get; set; }

    public int? ID_ENVELOPE_DOCUSIGN_CONFIG { get; set; }

    public bool? FL_COORDENADOR_MARKETING { get; set; }

    public bool? FL_SUPERINTENDENTE { get; set; }

    public bool? FL_GERENTE_COMERCIAL { get; set; }

    public virtual TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG? ID_ENVELOPE_DOCUSIGN_CONFIGNavigation { get; set; }

    public virtual TB_CMCRM_TIPO_RELACAO_CLIENTE? ID_TIPO_RELACAO_CLIENTENavigation { get; set; }

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO_DOCUMENTO>();
}
