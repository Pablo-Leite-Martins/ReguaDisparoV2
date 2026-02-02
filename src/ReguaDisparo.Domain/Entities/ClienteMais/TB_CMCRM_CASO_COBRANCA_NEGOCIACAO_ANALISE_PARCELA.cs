using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELA
{
    public int ID_CASO_COBRANCA_NEGOCIACAO_ANALISE_PARCELA { get; set; }

    public decimal VL_PARCELA { get; set; }

    public string DS_TIPO_PARCELA { get; set; } = null!;

    public int? NR_PARCELA { get; set; }

    public int? NR_PARCELA_GERAL { get; set; }

    public DateTime DT_VENCIMENTO { get; set; }

    public int ID_CASO_COBRANCA_NEGOCIACAO_ANALISE { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_NEGOCIACAO_ANALISE ID_CASO_COBRANCA_NEGOCIACAO_ANALISENavigation { get; set; } = null!;
}
