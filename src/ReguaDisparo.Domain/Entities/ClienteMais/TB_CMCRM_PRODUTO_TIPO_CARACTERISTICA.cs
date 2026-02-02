using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_TIPO_CARACTERISTICA
{
    public int ID_PRODUTO_TIPO_CARACTERISTICA { get; set; }

    public int ID_PRODUTO { get; set; }

    public int ID_TIPO_CARACTERISTICA { get; set; }

    public string DS_VALOR { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_CARACTERISTICA ID_TIPO_CARACTERISTICANavigation { get; set; } = null!;
}
