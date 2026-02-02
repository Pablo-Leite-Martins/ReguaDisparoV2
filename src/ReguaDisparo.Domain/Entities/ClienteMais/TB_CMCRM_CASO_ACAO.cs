using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_ACAO
{
    public int ID_CASO_ACAO { get; set; }

    public string DS_CASO_ACAO { get; set; } = null!;

    public int ID_TIPO_CASO { get; set; }

    public virtual TB_CMCRM_TIPO_CASO ID_TIPO_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_CAMINHO> TB_CMCRM_CASO_CAMINHOs { get; set; } = new List<TB_CMCRM_CASO_CAMINHO>();
}
