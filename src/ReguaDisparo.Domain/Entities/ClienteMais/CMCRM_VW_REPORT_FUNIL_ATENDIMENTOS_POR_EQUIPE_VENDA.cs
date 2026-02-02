using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_FUNIL_ATENDIMENTOS_POR_EQUIPE_VENDA
{
    public string EQUIPE_VENDAS { get; set; } = null!;

    public int ID_CASO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public int CONTADOR { get; set; }

    public int? ID_CORRETOR { get; set; }

    public int ID_PRODUTO { get; set; }

    public int PRE_ATENDIMENTO { get; set; }

    public int VISITA { get; set; }

    public int ANALISE_CREDITO { get; set; }

    public int PROPOSTA { get; set; }

    public int CONTRATO { get; set; }

    public int VALIDACAO_CADASTRAL { get; set; }

    public int DESLIGAMENTO_CLIENTE { get; set; }

    public int VENDAS_REALIZADAS { get; set; }
}
