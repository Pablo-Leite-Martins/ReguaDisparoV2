using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA
{
    public int ID_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA { get; set; }

    public int? ID_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; }

    public int? ID_TIPO_PARCELA { get; set; }

    public decimal VL_PERCENTUAL_IMOBILIARIA { get; set; }

    public decimal VL_PERCENTUAL_EMPRESA { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL? ID_ESTRUTURA_COMISSAO_FLEXIVELNavigation { get; set; }

    public virtual TB_CMCRM_TIPO_PARCELA? ID_TIPO_PARCELANavigation { get; set; }
}
