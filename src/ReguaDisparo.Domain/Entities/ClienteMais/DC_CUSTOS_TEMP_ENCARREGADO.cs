using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class DC_CUSTOS_TEMP_ENCARREGADO
{
    public int? ID_ANO { get; set; }

    public int? ID_MES { get; set; }

    public decimal? VL_TOTAL_FINAL { get; set; }

    public int? ID_ENCARREGADO { get; set; }

    public int? AST_ATENDIDAS_ENCARREGADO { get; set; }

    public decimal? MEDIA_ENCARREGADO_MES_POR_AST { get; set; }

    public string? DS_PRACA { get; set; }
}
