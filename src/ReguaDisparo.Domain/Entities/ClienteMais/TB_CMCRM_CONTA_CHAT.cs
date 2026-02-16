using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_CHAT
{
    public int ID_CONTA_CHAT { get; set; }

    public int? ID_CONTA { get; set; }

    public string? NR_TELEFONE { get; set; }

    public DateTime DT_INICIO_CHAT { get; set; }

    public DateTime DT_FIM_CHAT { get; set; }

    public int ID_USUARIO { get; set; }

    public string? NR_TELEFONE_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CONTA? ID_CONTANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CONTA_CHAT_HISTORICO> TB_CMCRM_CONTA_CHAT_HISTORICOs { get; set; } = new List<TB_CMCRM_CONTA_CHAT_HISTORICO>();

    public virtual ICollection<TB_CMCRM_EMAIL_PESQUISA_SATISFACAO> TB_CMCRM_EMAIL_PESQUISA_SATISFACAOs { get; set; } = new List<TB_CMCRM_EMAIL_PESQUISA_SATISFACAO>();

    public virtual ICollection<TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO> TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIOs { get; set; } = new List<TB_CMCRM_PESQUISA_SATISFACAO_SIMPLIFICADA_ENVIO>();

    public virtual ICollection<TB_CMCRM_RESPOSTA_FORMULARIO> TB_CMCRM_RESPOSTA_FORMULARIOs { get; set; } = new List<TB_CMCRM_RESPOSTA_FORMULARIO>();
}
