using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ALCADA_DESCONTO_LOG_20200113_MUDANCA_PARA_GRUPO
{
    public int ID_ALCADA_DESCONTO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public DateTime DT_ACAO { get; set; }

    public int ID_EMPRESA { get; set; }

    public int? ID_EMPRESA_NOVO { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public string? ID_OBRA_NOVO { get; set; }

    public int NUM_PERCENTUAL_MULTA { get; set; }

    public int? NUM_PERCENTUAL_MULTA_NOVO { get; set; }

    public int NUM_PERCENTUAL_JUROS { get; set; }

    public int? NUM_PERCENTUAL_JUROS_NOVO { get; set; }

    public int? NUM_MINIMO_PARCELAS { get; set; }

    public int? NUM_MINIMO_PARCELAS_NOVO { get; set; }

    public int? ID_USUARIO_ANTIGO { get; set; }

    public int? ID_USUARIO_NOVO { get; set; }

    public int? NR_INICIO_AGING { get; set; }

    public int? NR_INICIO_AGING_NOVO { get; set; }

    public int? NR_FIM_AGING { get; set; }

    public int? NR_FIM_AGING_NOVO { get; set; }
}
