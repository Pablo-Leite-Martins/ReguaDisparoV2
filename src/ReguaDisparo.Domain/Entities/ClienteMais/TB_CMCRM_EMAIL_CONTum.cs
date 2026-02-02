using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_CONTum
{
    public int ID_EMAIL_CONTA { get; set; }

    public string? DS_HOSTNAME_SMTP { get; set; }

    public string DS_USERNAME { get; set; } = null!;

    public string DS_SENHA { get; set; } = null!;

    public int? NR_PORTA_IMAP { get; set; }

    public int? NR_PORTA_SMTP { get; set; }

    public bool FL_SSL { get; set; }

    public string? DS_HOSTNAME_IMAP { get; set; }

    public bool? FL_VALIDADO { get; set; }

    public string? DS_REMETENTE { get; set; }

    public string? DS_COPIA { get; set; }

    public string? DS_COPIA_OCULTA { get; set; }

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_CONFIG> TB_CMCRM_EMAIL_CONTA_CONFIGs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_CONFIG>();

    public virtual ICollection<TB_CMCRM_EMAIL_CONTA_GRUPO> TB_CMCRM_EMAIL_CONTA_GRUPOs { get; set; } = new List<TB_CMCRM_EMAIL_CONTA_GRUPO>();
}
