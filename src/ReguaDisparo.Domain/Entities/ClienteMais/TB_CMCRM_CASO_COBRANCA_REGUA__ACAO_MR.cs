using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA__ACAO_MR
{
    public int ID_CASO_COBRANCA_REGUA__ACAO_MRS { get; set; }

    public string? ID_CHAVE_ERP_CLIENTE { get; set; }

    public int? ID_PARCELA { get; set; }

    public string? NR_VENDA { get; set; }

    public DateTime DT_ENVIO { get; set; }

    public string DS_STATUS { get; set; } = null!;

    public string? ID_PROTOCOLOCO { get; set; }

    public string? DS_STATUS_ENVIO_TOTVS { get; set; }
}
