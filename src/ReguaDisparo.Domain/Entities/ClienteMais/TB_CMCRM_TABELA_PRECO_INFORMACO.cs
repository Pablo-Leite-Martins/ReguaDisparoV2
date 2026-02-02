using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TABELA_PRECO_INFORMACO
{
    public int ID_TABELA_PRECO_INFORMACOES { get; set; }

    public string DS_INFORMACAO { get; set; } = null!;

    public int NR_ORDEM { get; set; }

    public int ID_PRODUTO { get; set; }
}
