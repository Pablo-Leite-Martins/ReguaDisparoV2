using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PERGUNTum
{
    public int ID_TIPO_PERGUNTA { get; set; }

    public string DS_TIPO_PERGUNTA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum> TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTa { get; set; } = new List<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum>();

    public virtual ICollection<TB_CMCRM_PERGUNTum> TB_CMCRM_PERGUNTa { get; set; } = new List<TB_CMCRM_PERGUNTum>();
}
