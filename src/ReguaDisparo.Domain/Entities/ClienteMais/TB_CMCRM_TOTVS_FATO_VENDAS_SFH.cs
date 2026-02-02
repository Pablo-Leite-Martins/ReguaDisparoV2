using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_VENDAS_SFH
{
    public int ID_TOTVS_FATO_VENDAS_SFH { get; set; }

    public string? ID_CHAVE_ERP_VENDA { get; set; }

    public string? MODALIDADE { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
