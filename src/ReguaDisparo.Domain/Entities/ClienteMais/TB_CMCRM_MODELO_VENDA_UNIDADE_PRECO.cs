using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_VENDA_UNIDADE_PRECO
{
    public int ID_MODELO_VENDA_UNIDADE_PRECO { get; set; }

    public int ID_MODELO_VENDA { get; set; }

    public int ID_UNIDADE_PRECO { get; set; }

    public bool FL_PADRAO { get; set; }

    public virtual TB_CMCRM_MODELO_VENDA ID_MODELO_VENDANavigation { get; set; } = null!;

    public virtual TB_CMCRM_UNIDADE_PRECO ID_UNIDADE_PRECONavigation { get; set; } = null!;
}
