using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL
{
    public int ID_EMAIL { get; set; }

    public string? DS_ASSUNTO { get; set; }

    public string DS_REMETENTE { get; set; } = null!;

    public string? DS_MENSAGEM { get; set; }

    public int? ID_CASO { get; set; }

    public bool FL_IGNORADO { get; set; }

    public int ID_EMAIL_CONTA_CONFIG { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public string? DS_COPIA_CARBONO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_EMAIL_CONTA_CONFIG ID_EMAIL_CONTA_CONFIGNavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_EMAIL_ANEXO> TB_CMCRM_EMAIL_ANEXOs { get; set; } = new List<TB_CMCRM_EMAIL_ANEXO>();

    public virtual ICollection<TB_CMCRM_EMAIL_RESPOSTum> TB_CMCRM_EMAIL_RESPOSTa { get; set; } = new List<TB_CMCRM_EMAIL_RESPOSTum>();

    public virtual ICollection<TB_CMCRM_USUARIO_EMAIL_TRIAGEM> TB_CMCRM_USUARIO_EMAIL_TRIAGEMs { get; set; } = new List<TB_CMCRM_USUARIO_EMAIL_TRIAGEM>();
}
