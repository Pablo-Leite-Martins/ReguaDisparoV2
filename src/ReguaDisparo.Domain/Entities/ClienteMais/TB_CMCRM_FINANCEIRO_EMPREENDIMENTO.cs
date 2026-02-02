using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FINANCEIRO_EMPREENDIMENTO
{
    public int ID_FINANCEIRO_EMPREENDIMENTO { get; set; }

    public int ID_EMPREENDIMENTO { get; set; }

    public decimal VL_PERCENTUAL_ENTRADA { get; set; }

    public int VL_QUANTIDADE_ENTRADA { get; set; }

    public decimal VL_PERCENTUAL_MENSAL { get; set; }

    public int VL_QUANTIDADE_MENSAL { get; set; }

    public decimal VL_PERCENTUAL_ANUAL { get; set; }

    public int VL_QUANTIDADE_ANUAL { get; set; }

    public decimal? VL_TAXA_JUROS_MENSAL { get; set; }

    public decimal? VL_TAXA_JUROS_ANUAL { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_EMPREENDIMENTONavigation { get; set; } = null!;
}
