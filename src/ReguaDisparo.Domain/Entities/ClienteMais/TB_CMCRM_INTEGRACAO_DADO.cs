using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO_DADO
{
    public int ID_INTEGRACAO_DADOS { get; set; }

    public int ID_INTEGRACAO { get; set; }

    public int ID_TIPO_INTEGRACAO_ATRIBUTO { get; set; }

    public string? DS_VALOR { get; set; }

    public virtual TB_CMCRM_INTEGRACAO ID_INTEGRACAONavigation { get; set; } = null!;
}
