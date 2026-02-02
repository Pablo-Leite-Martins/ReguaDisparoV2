using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_DOCUMENTO_PRODUTO
{
    public int ID_PRODUTO_DOCUMENTO_PRODUTO { get; set; }

    public int ID_PRODUTO { get; set; }

    public int ID_DOCUMENTO_PRODUTO { get; set; }

    public virtual TB_CMCRM_DOCUMENTO_PRODUTO ID_DOCUMENTO_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
