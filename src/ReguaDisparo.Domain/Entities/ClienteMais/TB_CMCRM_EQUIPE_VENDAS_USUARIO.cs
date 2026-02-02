using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EQUIPE_VENDAS_USUARIO
{
    public int ID_EQUIPE_VENDAS_USUARIO { get; set; }

    public int ID_EQUIPE_VENDAS { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_EQUIPE_VENDA ID_EQUIPE_VENDASNavigation { get; set; } = null!;
}
