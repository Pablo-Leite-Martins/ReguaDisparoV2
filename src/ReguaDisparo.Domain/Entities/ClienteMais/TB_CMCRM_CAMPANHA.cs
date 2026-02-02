using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CAMPANHA
{
    public int ID_CAMPANHA { get; set; }

    public string DS_CAMPANHA { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public DateTime DT_INICIO { get; set; }

    public DateTime DT_TERMINO { get; set; }

    public decimal VLR_RECEITA_ESPERADA { get; set; }

    public decimal VLR_CUSTO_ESTIMADO { get; set; }

    public decimal VLR_CUSTO_REAL { get; set; }

    public decimal NR_PERC_RESPOSTA_ESPERADA { get; set; }

    public int? ID_CAMPANHA_PAI { get; set; }

    public bool FL_ATIVO { get; set; }
}
