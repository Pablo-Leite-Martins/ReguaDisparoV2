using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TEMPO_CONSLUSAO_REAL
{
    public int ID_USUARIO_TEMPO_CONSLUSAO_REAL { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_REAL_CONCLUSAO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
