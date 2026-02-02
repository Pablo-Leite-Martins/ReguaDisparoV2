using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIG_MODELO_RENEGOCIACAO_HISTORICO
{
    public int ID_HISTORICO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public DateTime DT_ACAO { get; set; }

    public int ID_EMPRESA_NOVO { get; set; }

    public string DS_OBRA_NOVO { get; set; } = null!;

    public string? DS_INDICE_NOVO { get; set; }

    public DateTime DT_UTILIZADA_NOVO { get; set; }

    public int? ID_EMPRESA_ANTIGO { get; set; }

    public string? DS_OBRA_ANTIGO { get; set; }

    public string? DS_INDICE_ANTIGO { get; set; }

    public DateTime? DT_UTILIZADA_ANTIGO { get; set; }
}
