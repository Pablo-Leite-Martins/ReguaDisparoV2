using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_REPORT_GESTAO_LEAD
{
    public int ID_CONTA { get; set; }

    public string? NOME { get; set; }

    public string? EMPREENDIMENTO { get; set; }

    public string? BLOCO { get; set; }

    public string? UNIDADE { get; set; }

    public string? EMAIL { get; set; }

    public string? TELEFONE1 { get; set; }

    public string? TELEFONE2 { get; set; }

    public string? ORIGEM_LEAD { get; set; }

    public string TIPO_LEAD { get; set; } = null!;

    public string? LOJA { get; set; }

    public string VISITA_EFETIVADA { get; set; } = null!;

    public string? CORRETOR { get; set; }

    public int? ID_CORRETOR { get; set; }

    public string STATUS_LEAD { get; set; } = null!;

    public DateTime? DT_ULTIMA_ATUALIZACAO { get; set; }

    public string? ETAPA_PROCESSO { get; set; }

    public string? ULTIMA_ATIVIDADE_AGENDADA { get; set; }

    public DateTime? DT_PROXIMA_ATIVIDADE { get; set; }

    public DateTime? DT_PERDA { get; set; }

    public string? MOTIVO_CANCELAMENTO { get; set; }

    public DateTime? DT_GANHO { get; set; }

    public DateTime? DT_CRIACAO { get; set; }

    public int? ID_PRODUTO { get; set; }
}
