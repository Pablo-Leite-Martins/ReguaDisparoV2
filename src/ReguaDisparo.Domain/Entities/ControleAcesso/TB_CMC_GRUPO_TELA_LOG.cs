using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_TELA_LOG
{
    public DateTime? DT_ATIVIDADE { get; set; }

    public string? DS_ATIVIDADE { get; set; }

    public int? ID_GRUPO_TELA { get; set; }

    public int? ID_GRUPO { get; set; }

    public int? ID_TELA { get; set; }

    public string? ID_ORGANIZACAO { get; set; }
}
