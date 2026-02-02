using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ORCAMENTO
{
    public int ID_ORCAMENTO { get; set; }

    public DateTime DT_CRIACAO { get; set; }

    public int ID_USUARIO_CRIACAO { get; set; }

    public int ID_CASO { get; set; }

    public DateTime? DT_APROVACAO { get; set; }

    public bool? FL_APROVACAO_CLIENTE { get; set; }

    public bool? FL_APROVACAO_INTERNO { get; set; }

    public int? ID_USUARIO_APROVACAO_INTERNO { get; set; }

    public string? DS_STATUS { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_ORCAMENTO_ITEM> TB_CMCRM_ORCAMENTO_ITEMs { get; set; } = new List<TB_CMCRM_ORCAMENTO_ITEM>();
}
