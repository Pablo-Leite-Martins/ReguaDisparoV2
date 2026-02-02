using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class View_SPL_Relatorio_Manutencao
{
    public int ID_CASO { get; set; }

    public string DS_CASO { get; set; } = null!;

    public int? ID_PRODUTO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public bool FL_CASO_RECORRENTE { get; set; }

    public int? ID_TIPO_RECORRENCIA { get; set; }

    public string? DS_OBSERVACAO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public int ID_ETAPA_TIPO_CASO { get; set; }

    public bool FL_GARANTIA { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_CONTATO { get; set; }

    public string DS_PRODUTO { get; set; } = null!;

    public string? DS_PRODUTO_COMP { get; set; }

    public string? DS_VALOR { get; set; }

    public DateOnly? DATAATUAL { get; set; }

    public string? DS_TIPO_COMPROMISSO { get; set; }

    public DateTime? DTAGENDADA { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO_COMP { get; set; }

    public string? DS_NOME { get; set; }
}
