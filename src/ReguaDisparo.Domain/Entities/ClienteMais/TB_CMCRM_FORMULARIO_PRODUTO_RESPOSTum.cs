using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FORMULARIO_PRODUTO_RESPOSTum
{
    public int ID_FORMULARIO_PRODUTO_RESPOSTA { get; set; }

    public string DS_RESPOSTA { get; set; } = null!;

    public int ID_FORMULARIO_PRODUTO_PERGUNTA { get; set; }

    public bool FL_ATIVO { get; set; }

    public virtual TB_CMCRM_FORMULARIO_PRODUTO_PERGUNTum ID_FORMULARIO_PRODUTO_PERGUNTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_RESPOSTA_FORMULARIO_PRODUTO? TB_CMCRM_RESPOSTA_FORMULARIO_PRODUTO { get; set; }
}
