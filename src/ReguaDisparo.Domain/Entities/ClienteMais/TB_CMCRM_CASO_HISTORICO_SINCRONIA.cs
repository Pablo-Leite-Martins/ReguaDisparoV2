using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_HISTORICO_SINCRONIA
{
    public int ID_CASO_HISTORICO_SINCRONIA { get; set; }

    public int ID_CASO_HISTORICO { get; set; }

    public DateTime DT_ENVIO { get; set; }

    public virtual TB_CMCRM_CASO_HISTORICO ID_CASO_HISTORICONavigation { get; set; } = null!;
}
