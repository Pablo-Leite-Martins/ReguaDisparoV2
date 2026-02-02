using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_APP
{
    public int ID_APP { get; set; }

    public string? DS_NOME { get; set; }

    public string? DS_DESCRICAO { get; set; }

    public string? DS_IDENTIFICADOR_APP { get; set; }

    public string? DS_ULTIMA_VERSAO_NAME_APPLE { get; set; }

    public string? DS_ULTIMA_VERSAO_NAME_CODE_APPLE { get; set; }

    public DateTime? DT_ULTIMA_VERSAO_APPLE { get; set; }

    public string? DS_ULTIMA_VERSAO_NAME_GOOGLE { get; set; }

    public string? DS_ULTIMA_VERSAO_NAME_CODE_GOOGLE { get; set; }

    public DateTime? DT_ULTIMA_VERSAO_GOOGLE { get; set; }
}
