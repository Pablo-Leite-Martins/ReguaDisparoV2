using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_PRODUTO_LOG
{
    public int ID_CONTA_PRODUTO_LOG { get; set; }

    public int? ID_CONTA_PRODUTO { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_PRODUTO { get; set; }

    public int QTD_PRODUTO { get; set; }

    public decimal VLR_UNITARIO_PRODUTO { get; set; }

    public DateTime DT_VENDA { get; set; }

    public decimal VLR_TOTAL_PRODUTO { get; set; }

    public bool FL_STATUS_VENDA { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_USUARIO_VENDA { get; set; }

    public int? ID_PROPOSTA_ACEITA { get; set; }

    public bool? FL_CONFIRMACAO_SINAL { get; set; }

    public string? ID_TITULO_SIENGE { get; set; }

    public string? ID_STATUS_VENDA_ERP { get; set; }

    public string? DS_STATUS { get; set; }

    public string DS_TIPO_ACAO { get; set; } = null!;

    public DateTime DT_ACAO { get; set; }

    public int ID_USUARIO_ACAO { get; set; }
}
