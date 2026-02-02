using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTEGRACAO
{
    public int ID_INTEGRACAO { get; set; }

    public int ID_TIPO_INTEGRACAO { get; set; }

    public string DS_INTEGRACAO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_INTEGRACAO_DADO> TB_CMCRM_INTEGRACAO_DADOs { get; set; } = new List<TB_CMCRM_INTEGRACAO_DADO>();

    public virtual ICollection<TB_CMCRM_INTEGRACAO_HISTORICO_ENVIO> TB_CMCRM_INTEGRACAO_HISTORICO_ENVIOs { get; set; } = new List<TB_CMCRM_INTEGRACAO_HISTORICO_ENVIO>();
}
