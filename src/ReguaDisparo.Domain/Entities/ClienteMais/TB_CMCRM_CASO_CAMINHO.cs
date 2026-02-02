using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_CAMINHO
{
    public int ID_CASO_CAMINHO { get; set; }

    public int ID_CASO { get; set; }

    public int ID_USUARIO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_CASO_ACAO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_CASO_ACAO ID_CASO_ACAONavigation { get; set; } = null!;
}
