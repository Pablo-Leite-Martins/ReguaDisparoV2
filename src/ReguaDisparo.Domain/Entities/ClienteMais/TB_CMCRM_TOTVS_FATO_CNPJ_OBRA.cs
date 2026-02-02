using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_CNPJ_OBRA
{
    public int ID_TOTVS_FATO_CNPJ_OBRAS { get; set; }

    public string? ID_CHAVE_ERP_OBRA { get; set; }

    public string? DS_OBRA { get; set; }

    public string? DS_CNPJ { get; set; }

    public string? ID_CHAVE_ERP_EMPRESA { get; set; }

    public string? DS_EMPRESA { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
