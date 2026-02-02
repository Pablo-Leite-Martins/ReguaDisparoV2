using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO { get; set; }

    public int ID_CASO_COBRANCA_REGUA_ETAPA { get; set; }

    public string? DS_CAMPO { get; set; }

    public int NR_ORDEM { get; set; }

    public bool? FL_ORDEM_CRESCENTE { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA ID_CASO_COBRANCA_REGUA_ETAPANavigation { get; set; } = null!;
}
