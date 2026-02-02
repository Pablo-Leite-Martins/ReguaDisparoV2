using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_CARGO
{
    public int ID_ESTRUTURA_COMISSAO_FLEXIVEL_CARGO { get; set; }

    public int ID_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; }

    public decimal? VL_PERCENTUAL { get; set; }

    public int ID_CARGO { get; set; }

    public int NR_ORDEM_PAGAMENTO { get; set; }

    public decimal? VL_COMISSAO { get; set; }

    public bool FL_COMISSIONADO_ERP { get; set; }

    public bool FL_EXIBIR_CONTRATO { get; set; }

    public decimal? VL_PERCENTUAL_RATEIO { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL ID_ESTRUTURA_COMISSAO_FLEXIVELNavigation { get; set; } = null!;
}
