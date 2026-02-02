using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DISTRIBUICAO_PAGAMENTO
{
    public int ID_DISTRIBUICAO_PAGAMENTO { get; set; }

    public int ID_FORMA_PAGAMENTO { get; set; }

    public int ID_UNIDADE { get; set; }

    public decimal? VL_DISTRIBUICAO { get; set; }

    public virtual TB_CMCRM_FORMA_PAGAMENTO ID_FORMA_PAGAMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_UNIDADE ID_UNIDADENavigation { get; set; } = null!;
}
