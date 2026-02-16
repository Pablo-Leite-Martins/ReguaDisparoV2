using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMPROMISSO
{
    public int ID_COMPROMISSO { get; set; }

    public int ID_USUARIO { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CAMPANHA { get; set; }

    public int? ID_CONTATO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime DT_FIM { get; set; }

    public string DS_ASSUNTO { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public string DS_LOCAL { get; set; } = null!;

    public int ID_TIPO_COMPROMISSO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_CASO_VISITA { get; set; }

    public bool? FL_EMAIL_ENVIADO { get; set; }

    public bool? FL_USUARIO_COMPLEMENTAR { get; set; }

    public int? ID_CASO_ATIVIDADE { get; set; }

    public bool? FL_CONFIRMADO { get; set; }

    public bool? FL_INTEGRADO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_CASO_ATIVIDADE? ID_CASO_ATIVIDADENavigation { get; set; }

    public virtual TB_CMCRM_CASO_VISITA? ID_CASO_VISITANavigation { get; set; }

    public virtual TB_CMCRM_CONTA? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_CONTATO? ID_CONTATONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_COMPROMISSO ID_TIPO_COMPROMISSONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_COMPROMISSO_NECESSIDADE_VIZINHO> TB_CMCRM_COMPROMISSO_NECESSIDADE_VIZINHOs { get; set; } = new List<TB_CMCRM_COMPROMISSO_NECESSIDADE_VIZINHO>();
}
