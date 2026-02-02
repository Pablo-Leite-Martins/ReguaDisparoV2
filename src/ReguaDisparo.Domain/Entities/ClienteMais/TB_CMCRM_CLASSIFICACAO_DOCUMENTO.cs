using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CLASSIFICACAO_DOCUMENTO
{
    public int ID_CLASSIFICACAO_DOCUMENTO { get; set; }

    public string DS_CLASSIFICACAO_DOCUMENTO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_TIPO_DOCUMENTO> TB_CMCRM_TIPO_DOCUMENTOs { get; set; } = new List<TB_CMCRM_TIPO_DOCUMENTO>();
}
