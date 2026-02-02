using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_VINCULADO
{
    public int ID_VINCULADO { get; set; }

    public int ID_CASO_PAI { get; set; }

    public int ID_CASO_VINCULADO { get; set; }

    public int ID_USUARIO { get; set; }

    public string? ID_OCORRENCIA { get; set; }

    public virtual TB_CMCRM_CASO ID_CASO_PAINavigation { get; set; } = null!;

    public virtual TB_CMCRM_CASO ID_CASO_VINCULADONavigation { get; set; } = null!;
}
