using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RESPOSTA_FORMULARIO
{
    public int ID_RESPOSTA_FORMULARIO { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_RESPOSTA { get; set; }

    public string? DS_COMENTARIO { get; set; }

    public string? DS_NOME { get; set; }

    public string? DS_RG { get; set; }

    public DateTime? DT_ASSINATURA { get; set; }

    public int? ID_FORMULARIO { get; set; }

    public int? ID_PERGUNTA { get; set; }

    public int? ID_CONTA_PRODUTO { get; set; }

    public bool? FL_PREENCHEU_FORMULARIO { get; set; }

    public string? DS_NOME_TECNICO { get; set; }

    public int? ID_EMAIL_REGUA_PESQUISA { get; set; }

    public bool? FL_CONFORMIDADE { get; set; }

    public int? NR_AGRUPAMENTO { get; set; }

    public int? ID_CONTA_CHAT { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_CONTA_CHAT? ID_CONTA_CHATNavigation { get; set; }

    public virtual TB_CMCRM_EMAIL_REGUA_PESQUISA? ID_EMAIL_REGUA_PESQUISANavigation { get; set; }

    public virtual TB_CMCRM_RESPOSTum? ID_RESPOSTANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVA> TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVAs { get; set; } = new List<TB_CMCRM_FORMULARIO_RESPOSTA_JUSTIFICATIVA>();
}
