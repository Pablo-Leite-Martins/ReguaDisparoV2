using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_GARANTIA_PRODUTO
{
    public int ID_GARANTIA_PRODUTO { get; set; }

    public int ID_PRODUTO { get; set; }

    public DateTime DT_GARANTIA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTONavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
