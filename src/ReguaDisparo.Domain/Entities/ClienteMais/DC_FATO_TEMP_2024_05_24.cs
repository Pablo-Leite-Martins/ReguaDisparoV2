using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class DC_FATO_TEMP_2024_05_24
{
    public int? ID_CASO { get; set; }

    public DateTime? DT_AGENDADA_VISTORIA { get; set; }

    public DateTime? DT_AGENDADA_EXECUCAO { get; set; }

    public int? ID_ENCARREGADO_CUSTOS { get; set; }

    public int? ID_OFICIAL_CUSTOS { get; set; }

    public int? ID_EMPREENDIMENTO { get; set; }

    public string? PRACA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_UNIDADE_AST { get; set; }

    public string? PRACA_EMP { get; set; }

    public string? DS_EMPREENDIMENTO { get; set; }

    public string? EMPREENDIMENTO_RESIDENCIAL { get; set; }

    public string? CASO_ABERTO { get; set; }

    public string? FL_NAO_PROCEDENTE { get; set; }

    public string? FL_GARANTIA { get; set; }
}
