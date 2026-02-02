using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_HELP_DESK
{
    public int ID_EQUIPE_HELP_DESK { get; set; }

    public string DS_EQUIPE_HELP_DESK { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public bool FL_DISTRIBUICAO { get; set; }

    public string NR_TELEFONE { get; set; } = null!;

    public int? ID_FORMULARIO { get; set; }

    public virtual TB_CMCRM_FORMULARIO? ID_FORMULARIONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO> TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>();

    public virtual ICollection<TB_CMCRM_EQUIPE_HELP_DESK_GERENCIum> TB_CMCRM_EQUIPE_HELP_DESK_GERENCIa { get; set; } = new List<TB_CMCRM_EQUIPE_HELP_DESK_GERENCIum>();

    public virtual ICollection<TB_CMCRM_EQUIPE_USUARIO_HELP_DESK> TB_CMCRM_EQUIPE_USUARIO_HELP_DESKs { get; set; } = new List<TB_CMCRM_EQUIPE_USUARIO_HELP_DESK>();
}
