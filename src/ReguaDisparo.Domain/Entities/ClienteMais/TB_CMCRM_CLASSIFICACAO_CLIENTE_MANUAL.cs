using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CLASSIFICACAO_CLIENTE_MANUAL
{
    public int ID_CLASSIFICACAO_CLIENTE_MANUAL { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public string? DS_CLIENTE { get; set; }

    public string? DS_CLASSIFICACAO_CONTRATO { get; set; }

    public DateTime DT_MES_REFERENCIA { get; set; }

    public string? DS_CLASSIFICACAO_CONTRATO_ORIGINAL { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public DateTime? DT_MUDANCA_CLASSIFICAO { get; set; }
}
