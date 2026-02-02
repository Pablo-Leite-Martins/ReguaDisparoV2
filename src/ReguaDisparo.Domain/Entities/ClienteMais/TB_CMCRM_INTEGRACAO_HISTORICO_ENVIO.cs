using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO_HISTORICO_ENVIO
{
    public int ID_INTEGRACAO_HISTORICO_ENVIO { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_CONTA_PRODUTO { get; set; }

    public int ID_INTEGRACAO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public string? DS_ERRO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public DateTime? DT_ENVIO_FUTURO { get; set; }

    public virtual TB_CMCRM_INTEGRACAO ID_INTEGRACAONavigation { get; set; } = null!;
}
