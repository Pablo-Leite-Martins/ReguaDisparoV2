using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TAG_SISTEMA
{
    public int ID_TAG_SISTEMA { get; set; }

    public string DS_NOME_TAG { get; set; } = null!;

    public string DS_COR_TAG { get; set; } = null!;

    public DateTime? DT_CRIACAO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int ID_USUARIO_CRIACAO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public virtual ICollection<TB_CMCRM_TAG_CASO> TB_CMCRM_TAG_CASOs { get; set; } = new List<TB_CMCRM_TAG_CASO>();
}
