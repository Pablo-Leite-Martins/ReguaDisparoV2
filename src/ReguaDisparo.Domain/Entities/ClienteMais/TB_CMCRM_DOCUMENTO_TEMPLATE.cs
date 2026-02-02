using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DOCUMENTO_TEMPLATE
{
    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public string DS_DOCUMENTO { get; set; } = null!;

    public string DS_TEMPLATE { get; set; } = null!;

    public int ID_TIPO_DOCUMENTO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool? FL_CONTRATO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public string? DS_ASSUNTO { get; set; }

    public int? ID_TIPO_PRODUTO { get; set; }

    public int? ID_ESTRUTURA_COMISSAO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_TIPO_INTEGRACAO { get; set; }

    public string? DS_TIPO_TEMPLATE { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO? ID_ESTRUTURA_COMISSAONavigation { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_DOCUMENTO ID_TIPO_DOCUMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PRODUTO? ID_TIPO_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_DOCUMENTO_GERADO> TB_CMCRM_CASO_DOCUMENTO_GERADOs { get; set; } = new List<TB_CMCRM_CASO_DOCUMENTO_GERADO>();

    public virtual ICollection<TB_CMCRM_CONTRATO> TB_CMCRM_CONTRATOs { get; set; } = new List<TB_CMCRM_CONTRATO>();

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE_MODULO> TB_CMCRM_DOCUMENTO_TEMPLATE_MODULOs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE_MODULO>();

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_CONFIG> TB_CMCRM_EMAIL_CONTA_CONFIGs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_CONFIG>();

    public virtual ICollection<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO> TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTOs { get; set; } = new List<TB_CMCRM_ENVELOPE_DOCUSIGN_CONFIG_DOCUMENTO>();

    public virtual ICollection<TB_CMCRM_VARIAVEL_TEMPLATE_MENSAGEM_ATIVA> TB_CMCRM_VARIAVEL_TEMPLATE_MENSAGEM_ATIVAs { get; set; } = new List<TB_CMCRM_VARIAVEL_TEMPLATE_MENSAGEM_ATIVA>();
}
