using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_CONTA_CONFIG
{
    public int ID_EMAIL_CONTA_CONFIG { get; set; }

    public int ID_EMAIL_CONTA { get; set; }

    public string DS_TAG_PROTOCOLO { get; set; } = null!;

    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public int? ID_TIPO_CASO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public bool? FL_ATIVO { get; set; }

    public string? DS_TIPO_NOTIFICACAO_ABERTURA_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE ID_DOCUMENTO_TEMPLATENavigation { get; set; } = null!;

    public virtual TB_CMCRM_EMAIL_CONTA ID_EMAIL_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CANAL_ATENDIMENTO ID_TIPO_CANAL_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CASO? ID_TIPO_CASONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_EMAIL> TB_CMCRM_EMAILs { get; set; } = new List<TB_CMCRM_EMAIL>();

    public virtual ICollection<TB_CMCRM_TRIAGEM_FILA> TB_CMCRM_TRIAGEM_FILAs { get; set; } = new List<TB_CMCRM_TRIAGEM_FILA>();
}
