using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERGUNTA
{
    public int ID_PERGUNTA { get; set; }

    public string DS_PERGUNTA { get; set; } = null!;

    public int ID_TIPO_PERGUNTA { get; set; }

    public int ID_FORMULARIO { get; set; }

    public int? ID_PERGUNTA_PAI { get; set; }

    public int? ID_ORDEM { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool? FL_MARCACAO_NPS { get; set; }

    public virtual TB_CMCRM_FORMULARIO ID_FORMULARIONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PERGUNTA ID_TIPO_PERGUNTANavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_RESPOSTA> TB_CMCRM_RESPOSTa { get; set; } = new List<TB_CMCRM_RESPOSTA>();
}
