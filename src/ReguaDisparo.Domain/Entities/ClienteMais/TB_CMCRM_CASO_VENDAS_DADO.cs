using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_VENDAS_DADO
{
    public int ID_CASO_VENDAS_DADOS { get; set; }

    public int ID_CASO { get; set; }

    public int? ID_ANALISE_CREDITO { get; set; }

    public string? DS_STATUS_ANALISE_CREDITO { get; set; }

    public DateTime? DT_VALIDADE_ANALISE_CREDITO { get; set; }

    public decimal? VL_SICAQ_APROVADO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public int? ID_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_ULTIMO_HISTORICO { get; set; }

    public DateTime? DT_CADASTRO_ULTIMO_HISTORICO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;
}
