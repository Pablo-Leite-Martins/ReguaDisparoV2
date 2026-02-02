using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_PARCELA
{
    public int ID_CASO_COBRANCA_NEGOCIACAO_PARCELAS { get; set; }

    public decimal VL_PARCELA { get; set; }

    public DateTime DT_VENCIMENTO { get; set; }

    public bool FL_RECEBIDO { get; set; }

    public int ID_CASO_COBRANCA_NEGOCIACAO { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public string DS_STATUS_PARCELA { get; set; } = null!;

    public DateTime DT_SOLICITACAO { get; set; }

    public DateTime? DT_ENVIO { get; set; }

    public int ID_USUARIO_SOLICITANTE { get; set; }

    public int? ID_USUARIO_GERACAO { get; set; }

    public int? ID_EMPRESA { get; set; }

    public string? ID_OBRA { get; set; }

    public int? ID_VENDA { get; set; }

    public int? NR_PARCELA { get; set; }

    public int? NR_PARCELA_GERAL { get; set; }

    public string? DS_TIPO { get; set; }

    public bool? FL_PAGO_ASSESSORIA { get; set; }

    public int? ID_USUARIO_PAGAMENTO_ASSESSORIA { get; set; }

    public DateTime? DT_PAGAMENTO_ASSESSORIA { get; set; }

    public decimal? VL_PARCELA_ASSESSORIA { get; set; }

    public DateTime? DT_RECEBIMENTO_UAU { get; set; }

    public int? ID_USUARIO_NAOQUITADO { get; set; }

    public int? ID_USUARIO_QUITADO { get; set; }

    public int? ID_USUARIO_ENVIO { get; set; }

    public DateTime? DT_VENCIMENTO_ERP { get; set; }

    public decimal? VL_RECEBIMENTO_UAU { get; set; }

    public string? DS_TIPO_RECEBIMENTO { get; set; }

    public bool? FL_NEGOCIACAO_FINALIZADA_UAU { get; set; }

    public decimal? VL_HONORARIO_RECEBIDO { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_NEGOCIACAO ID_CASO_COBRANCA_NEGOCIACAONavigation { get; set; } = null!;
}
