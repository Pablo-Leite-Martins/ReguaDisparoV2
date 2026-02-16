using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_PRODUTO_PROPONENTE
{
    public int ID_CONTA_PRODUTO_PROPONENTE { get; set; }

    public int ID_CASO { get; set; }

    public int ID_CONTA { get; set; }

    public decimal VL_PARTICIPACAO { get; set; }

    public int? ID_CONTA_PRODUTO { get; set; }

    public bool FL_CLIENTE_PRINCIPAL { get; set; }

    public bool? FL_PARTICIPANTE_ANALISE_CREDITO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_CONTA_PRODUTO? ID_CONTA_PRODUTONavigation { get; set; }
}
