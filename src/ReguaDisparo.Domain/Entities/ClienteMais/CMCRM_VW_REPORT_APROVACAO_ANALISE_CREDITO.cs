using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_APROVACAO_ANALISE_CREDITO
{
    public int? ID_CASO { get; set; }

    public int? ID_EQUIPE { get; set; }

    public string? EQUIPE { get; set; }

    public string CLIENTE { get; set; } = null!;

    public string? STATUS { get; set; }

    public decimal? AVALIACAO { get; set; }

    public decimal? APROVACAO { get; set; }

    public decimal? UNIDADE { get; set; }

    public decimal? PROPOSTA { get; set; }

    public decimal? FGTS { get; set; }

    public decimal? PRO_SOLUTO { get; set; }

    public decimal? SUBSIDIO { get; set; }

    public decimal? CALCAO { get; set; }

    public decimal? TAXA_JUROS { get; set; }

    public decimal? PRESTACAO { get; set; }

    public int? PRAZO { get; set; }

    public string? AMORTIZACAO { get; set; }

    public DateTime? CRIACAO { get; set; }

    public DateTime? CONCLUSAO { get; set; }

    public DateTime? VALIDADE { get; set; }
}
