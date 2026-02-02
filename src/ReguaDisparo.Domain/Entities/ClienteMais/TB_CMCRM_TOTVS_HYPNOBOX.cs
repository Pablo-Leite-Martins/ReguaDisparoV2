using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_HYPNOBOX
{
    public int ID_TOTVS_HYPNOBOX { get; set; }

    public int NR_VENDA { get; set; }

    public DateTime DT_CRIACAO { get; set; }

    public DateTime? DT_RP { get; set; }

    public DateTime? DT_CEF { get; set; }

    public DateTime? DT_CARTORIO { get; set; }
}
