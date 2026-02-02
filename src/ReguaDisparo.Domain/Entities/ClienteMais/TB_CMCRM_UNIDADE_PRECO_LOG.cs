using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UNIDADE_PRECO_LOG
{
    public int ID_UNIDADE_PRECO_LOG { get; set; }

    public string DS_UNIDADE_PRECO_LOG { get; set; } = null!;

    public DateTime DT_UNIDADE_PRECO_LOG { get; set; }

    public int ID_UNIDADE_PRECO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_UNIDADE_PRECO ID_UNIDADE_PRECONavigation { get; set; } = null!;
}
