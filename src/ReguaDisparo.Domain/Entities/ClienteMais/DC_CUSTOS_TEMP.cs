using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class DC_CUSTOS_TEMP
{
    public int? ID_ANO { get; set; }

    public int? ID_MES { get; set; }

    public decimal? VL_FINAL { get; set; }

    public int? ID_OFICIAL_FUNCIONARIO { get; set; }

    public int? AST_ATENDIDAS_ENCARREGADO { get; set; }

    public decimal? MEDIA_OFICAL_MES_POR_AST { get; set; }

    public string? DS_PRACA { get; set; }
}
