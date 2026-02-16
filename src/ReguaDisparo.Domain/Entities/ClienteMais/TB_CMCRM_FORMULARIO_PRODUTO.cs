using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_PRODUTO
{
    public int ID_FORMULARIO_PRODUTO { get; set; }

    public string DS_FORMULARIO { get; set; } = null!;

    public string? DS_DESCRICAO { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTA> TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTa { get; set; } = new List<TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTA>();
}
