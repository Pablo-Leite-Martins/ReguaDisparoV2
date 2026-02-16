using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMAIL_REGUA_PESQUISA
{
    public int ID_EMAIL_REGUA_PESQUISA { get; set; }

    public string ID_GUID { get; set; } = null!;

    public int? ID_FORMULARIO { get; set; }

    public int? ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_PRODUTO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public bool? FL_RESPONDIDO { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO? ID_CASO_COBRANCA_REGUA_ETAPA_ACAONavigation { get; set; }

    public virtual TB_CMCRM_CONTA? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_FORMULARIO? ID_FORMULARIONavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_RESPOSTA_FORMULARIO> TB_CMCRM_RESPOSTA_FORMULARIOs { get; set; } = new List<TB_CMCRM_RESPOSTA_FORMULARIO>();
}
