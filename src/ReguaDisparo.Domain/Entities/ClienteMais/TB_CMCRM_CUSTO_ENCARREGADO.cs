using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CUSTO_ENCARREGADO
{
    public int ID_CUSTO_ENCARREGADO { get; set; }

    public int? ID_MES { get; set; }

    public int? ID_ANO { get; set; }

    public int? ID_ENCARREGADO { get; set; }

    public decimal? VL_MAO_DE_OBRA { get; set; }

    public decimal? VL_COMBUSTIVEL { get; set; }

    public decimal? VL_MANUTENCAO_DO_VEICULO { get; set; }

    public decimal? VL_TOTAL_FINAL { get; set; }

    public string? DS_PRACA { get; set; }
}
