using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_HELP_DESK_CHAT_LOG
{
    public int ID_HELP_DESK_CHAT_LOG { get; set; }

    public string NR_TELEFONE { get; set; } = null!;

    public string NR_TELEFONE_ATENDIMENTO { get; set; } = null!;

    public string ID_MENSAGEM { get; set; } = null!;

    public string DS_MENSAGEM { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public DateTime DT_REGISTRO { get; set; }
}
