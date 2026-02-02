using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_RELACAO_CLIENTE
{
    public int ID_TIPO_RELACAO_CLIENTE { get; set; }

    public string DS_TIPO_RELACAO_CLIENTE { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CONTA_CONTATO> TB_CMCRM_CONTA_CONTATOs { get; set; } = new List<TB_CMCRM_CONTA_CONTATO>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DESTINATARIO>();

    public virtual ICollection<TB_CMCRM_PRODUTO_CLIENTE> TB_CMCRM_PRODUTO_CLIENTEs { get; set; } = new List<TB_CMCRM_PRODUTO_CLIENTE>();

    public virtual ICollection<TB_CMCRM_PRODUTO_CONTATO> TB_CMCRM_PRODUTO_CONTATOs { get; set; } = new List<TB_CMCRM_PRODUTO_CONTATO>();
}
