using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_VISTORIA_CODIGO_ASSINATURA
{
    public int ID_CASO_VISTORIA_CODIGO_ASSINATURA { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public string NR_CODIGO { get; set; } = null!;

    public bool FL_VALIDADO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
