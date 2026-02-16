using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_CANAL_ATENDIMENTO
{
    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public string DS_TIPO_CANAL_ATENDIMENTO { get; set; } = null!;

    public string? ID_CHAVE_ERP { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();

    public virtual ICollection<TB_CMCRM_CONTA> TB_CMCRM_CONTa { get; set; } = new List<TB_CMCRM_CONTA>();

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_CONFIG> TB_CMCRM_EMAIL_CONTA_CONFIGs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_CONFIG>();
}
