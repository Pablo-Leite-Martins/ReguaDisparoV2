using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_CONEXO
{
    public int ID_ETL_CONEXOES { get; set; }

    public int ID_ETL { get; set; }

    public string DS_NOME_CONEXAO { get; set; } = null!;

    public string DS_NOME_SERVIDOR { get; set; } = null!;

    public string DS_NOME_BANCO_DADOS { get; set; } = null!;

    public string DS_USUARIO { get; set; } = null!;

    public string DS_SENHA { get; set; } = null!;
}
