using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FATO_CARTEIRA
{
    public int ID_CASO_COBRANCA_FATO_CARTEIRA { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public int ID_CARTEIRA { get; set; }

    public DateTime DT_MES_REFERENCIA { get; set; }
}
