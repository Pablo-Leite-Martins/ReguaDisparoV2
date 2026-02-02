using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RESPOSTA_FORMULARIO_PRODUTO
{
    public int ID_RESPOSTA_FORMULARIO_PRODUTO { get; set; }

    public int ID_FORMULARIO_PRODUTO_RESPOSTA { get; set; }

    public int ID_USUARIO_RESPOSTA { get; set; }

    public string? DS_COMENTARIO { get; set; }

    public DateTime? DT_RESPOSTA { get; set; }

    public virtual TB_CMCRM_FORMULARIO_PRODUTO_RESPOSTum ID_FORMULARIO_PRODUTO_RESPOSTANavigation { get; set; } = null!;
}
