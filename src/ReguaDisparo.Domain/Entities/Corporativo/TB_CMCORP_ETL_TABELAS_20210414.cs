using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ETL_TABELAS_20210414
{
    public int ID_ETL_TABELAS { get; set; }

    public string DS_TABELA { get; set; } = null!;

    public int ID_ETL { get; set; }

    public string? DS_SQL_CONSULTA { get; set; }

    public string DS_NOME_CONEXAO_ORIGEM { get; set; } = null!;

    public string DS_NOME_CONEXAO_DESTINO { get; set; } = null!;

    public string? DS_TIPO_CHAMADA { get; set; }

    public int? NR_ORDEM_EXECUCAO { get; set; }
}
