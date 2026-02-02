using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC
{
    public int ID_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_ABERTURA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_VISTORIA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_REPARO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_FECHAMENTO { get; set; }

    public int ID_CASO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO ID_CATEGORIA_ATENDIMENTO_ABERTURANavigation { get; set; } = null!;

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTO_FECHAMENTONavigation { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTO_REPARONavigation { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTO_VISTORIANavigation { get; set; }
}
