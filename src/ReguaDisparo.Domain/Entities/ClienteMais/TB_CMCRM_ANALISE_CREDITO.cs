using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ANALISE_CREDITO
{
    public int ID_ANALISE_CREDITO { get; set; }

    public decimal? VL_SICAQ_AVALIACAO { get; set; }

    public decimal? VL_SICAQ_APROVADO { get; set; }

    public decimal? VL_FGTS { get; set; }

    public decimal? VL_PRO_SOLUTO { get; set; }

    public int ID_CASO { get; set; }

    public decimal? VL_RECURSOS_PROPRIOS { get; set; }

    public decimal? VL_SUBSIDIO { get; set; }

    public bool? FL_CONCLUIDO { get; set; }

    public DateTime? DT_CRIACAO { get; set; }

    public DateTime? DT_VALIDADE { get; set; }

    public string? DS_STATUS { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public DateTime? DT_ULTIMA_ALTERACAO { get; set; }

    public DateTime? DT_CONCLUSAO { get; set; }

    public string? DS_MODALIDADE { get; set; }

    public string? DS_TABELA { get; set; }

    public int? NR_PRAZO { get; set; }

    public decimal? VL_TAXA_JUROS { get; set; }

    public decimal? VL_COTA_MAXIMA { get; set; }

    public decimal? VL_COTA_APROVADA { get; set; }

    public decimal? VL_UNIDADE { get; set; }

    public bool? FL_FGTS { get; set; }

    public decimal? VL_RENDA_APURADA { get; set; }

    public decimal? VL_SERASA { get; set; }

    public int? ID_ANALISE_CREDITO_STATUS { get; set; }

    public decimal? VL_PRESTACAO { get; set; }

    public decimal? VL_CALCAO { get; set; }

    public decimal? VL_PROPOSTA { get; set; }

    public virtual TB_CMCRM_ANALISE_CREDITO_STATUS? ID_ANALISE_CREDITO_STATUSNavigation { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
