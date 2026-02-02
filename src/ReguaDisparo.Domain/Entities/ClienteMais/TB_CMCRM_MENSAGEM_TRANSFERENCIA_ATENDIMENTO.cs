using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MENSAGEM_TRANSFERENCIA_ATENDIMENTO
{
    public int ID_MENSAGEM_TRANSFERENCIA_ATENDIMENTO { get; set; }

    public int? ID_USUARIO_ALTERACAO { get; set; }

    public string? ID_ORGANIZACAO { get; set; }

    public string? DS_MENSAGEM_TRANSFERENCIA { get; set; }
}
