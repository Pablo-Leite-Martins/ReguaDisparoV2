using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_CLIENTE
{
    public int ID_PRODUTO_CLIENTE { get; set; }

    public int ID_PRODUTO { get; set; }

    public int ID_CLIENTE { get; set; }

    public int? ID_TIPO_RELACAO_CLIENTE { get; set; }

    public int NR_CONTRATO { get; set; }

    public DateTime DT_CONTRATO { get; set; }

    public bool? FL_TITULAR { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_RELACAO_CLIENTE? ID_TIPO_RELACAO_CLIENTENavigation { get; set; }
}
