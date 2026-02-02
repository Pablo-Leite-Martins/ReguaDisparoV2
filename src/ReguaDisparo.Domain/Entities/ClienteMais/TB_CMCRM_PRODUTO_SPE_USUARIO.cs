using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_SPE_USUARIO
{
    public int ID_PRODUTO_SPE_USUARIO { get; set; }

    public int ID_PRODUTO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
