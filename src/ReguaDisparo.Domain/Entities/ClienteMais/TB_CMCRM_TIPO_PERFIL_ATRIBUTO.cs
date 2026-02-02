using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PERFIL_ATRIBUTO
{
    public int ID_TIPO_PERFIL_ATRIBUTO { get; set; }

    public int ID_TIPO_PERFIL { get; set; }

    public string DS_TIPO_PERFIL_ATRIBUTO { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_TIPO_PERFIL ID_TIPO_PERFILNavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_PERFIL_CONTum> TB_CMCRM_PERFIL_CONTa { get; set; } = new List<TB_CMCRM_PERFIL_CONTum>();
}
