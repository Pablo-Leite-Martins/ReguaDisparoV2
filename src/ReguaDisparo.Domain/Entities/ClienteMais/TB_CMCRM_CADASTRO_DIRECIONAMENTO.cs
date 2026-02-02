using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CADASTRO_DIRECIONAMENTO
{
    public int ID_CADASTRO_DIRECIONAMENTO { get; set; }

    public DateOnly? DATA { get; set; }

    public int? ID_MES { get; set; }

    public int? ID_ANO { get; set; }

    public int? ID_ESTADO { get; set; }

    public int? ID_RESIDENCIAL { get; set; }

    public decimal? VL_VALOR { get; set; }

    public int? ID_SUBASSUNTO { get; set; }

    public int? ID_CLASSIFICACAO { get; set; }

    public int? ID_CLASSE_CONTROLE_DIRECIONAMENTO { get; set; }
}
