using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMPROMISSO_DISPONIVEL_VISTORIum
{
    public int ID_COMPROMISSO_DISPONIVEL_VISTORIA { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime DT_FIM { get; set; }

    public int ID_TIPO_COMPROMISSO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public virtual TB_CMCRM_TIPO_COMPROMISSO ID_TIPO_COMPROMISSONavigation { get; set; } = null!;
}
