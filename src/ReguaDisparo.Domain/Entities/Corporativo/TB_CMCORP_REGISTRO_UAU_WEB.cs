using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_REGISTRO_UAU_WEB
{
    public int ID_REG_UAU { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string DS_VERSAO_UAU_API { get; set; } = null!;

    public DateTime DT_HORA_EXECUCAO_REG { get; set; }

    public DateTime DT_HORA_EXECUCAO_GERMODULOS { get; set; }

    public bool? FL_ATIVO { get; set; }
}
