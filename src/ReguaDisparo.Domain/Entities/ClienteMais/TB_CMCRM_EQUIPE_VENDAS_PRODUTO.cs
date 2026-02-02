using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_VENDAS_PRODUTO
{
    public int ID_EQUIPE_VENDAS_PRODUTO { get; set; }

    public int ID_EQUIPE_VENDAS { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_EQUIPE_VENDA ID_EQUIPE_VENDASNavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
