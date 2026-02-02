using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FAIXA_QTDE_PARCELA
{
    public int ID_CASO_COBRANCA_FAIXA_QTDE_PARCELAS { get; set; }

    public string? DS_FAIXA { get; set; }

    public int? NR_FAIXA_MIN { get; set; }

    public int? NR_FAIXA_MAX { get; set; }

    public int? NR_ORDEM { get; set; }
}
