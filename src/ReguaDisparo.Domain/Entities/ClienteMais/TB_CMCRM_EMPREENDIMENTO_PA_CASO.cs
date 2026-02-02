using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMPREENDIMENTO_PA_CASO
{
    public int ID_EMPREENDIMENTO_PA_CASO { get; set; }

    public int ID_EMPREEDIMENTO_PA { get; set; }

    public int ID_CASO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
