using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_ASSISTENCIA_TECNICA_DURACAO_REAL
{
    public int ID_DURACAO_REAL { get; set; }

    public int ID_CASO { get; set; }

    public string? DS_ASSUNTO { get; set; }

    public DateTime? DT_ACAO { get; set; }

    public int? ID_USUARIO { get; set; }

    public string? DS_TIPO_AGENDAMENTO { get; set; }

    public string? DS_STATUS { get; set; }

    public string? DS_DURACAO { get; set; }

    public string? DS_OBSERVACAO { get; set; }
}
