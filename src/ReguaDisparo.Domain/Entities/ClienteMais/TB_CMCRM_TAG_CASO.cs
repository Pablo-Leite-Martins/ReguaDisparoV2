using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TAG_CASO
{
    public int ID_TAG_CASO { get; set; }

    public int ID_TAG_SISTEMA { get; set; }

    public int ID_CASO { get; set; }

    public DateTime? DT_ASSOCIACAO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int ID_USUARIO_ASSOCIACAO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TAG_SISTEMA ID_TAG_SISTEMANavigation { get; set; } = null!;
}
