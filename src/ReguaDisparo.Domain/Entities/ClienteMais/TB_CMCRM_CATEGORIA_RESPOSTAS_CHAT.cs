using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_RESPOSTAS_CHAT
{
    public int ID_CATEGORIA_RESPOSTA_CHAT { get; set; }

    public string DS_CATEGORIA_RESPOSTA_CHAT { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_RESPOSTAS_CHAT> TB_CMCRM_RESPOSTAS_CHATs { get; set; } = new List<TB_CMCRM_RESPOSTAS_CHAT>();
}
