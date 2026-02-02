using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TAG_CONTum
{
    public int ID_TAG_CONTA { get; set; }

    public int ID_TAG_CONTA_SISTEMA { get; set; }

    public int ID_CONTA { get; set; }

    public DateTime? DT_ASSOCIACAO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int ID_USUARIO_ASSOCIACAO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_TAG_CONTA_SISTEMA ID_TAG_CONTA_SISTEMANavigation { get; set; } = null!;
}
