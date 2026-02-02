using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PERFIL_ETAPA_TIPO_CASO
{
    public int ID_TIPO_PERFIL_ETAPA_TIPO_CASO { get; set; }

    public int ID_TIPO_PERFIL { get; set; }

    public int ID_ETAPA_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO ID_ETAPA_TIPO_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PERFIL ID_TIPO_PERFILNavigation { get; set; } = null!;
}
