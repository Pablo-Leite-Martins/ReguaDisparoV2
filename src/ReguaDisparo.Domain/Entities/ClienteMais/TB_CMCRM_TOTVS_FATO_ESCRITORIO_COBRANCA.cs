using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_ESCRITORIO_COBRANCA
{
    public int ID_TOTVS_FATO_ESCRITORIO_COBRANCA { get; set; }

    public string? ID_CHAVE_ERP_EMPRESA { get; set; }

    public string? DS_EMPRESA { get; set; }

    public string? ESCRITORIO_COLIGADA { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }

    public string? ID_CHAVE_ERP_OBRA { get; set; }

    public string? DS_OBRA { get; set; }
}
