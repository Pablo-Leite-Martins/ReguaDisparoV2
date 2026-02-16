using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PERFIL_CONTA
{
    public int ID_PERFIL_CONTA { get; set; }

    public int ID_TIPO_PERFIL_ATRIBUTO { get; set; }

    public int ID_CONTA { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_PERFIL_ATRIBUTO ID_TIPO_PERFIL_ATRIBUTONavigation { get; set; } = null!;
}
