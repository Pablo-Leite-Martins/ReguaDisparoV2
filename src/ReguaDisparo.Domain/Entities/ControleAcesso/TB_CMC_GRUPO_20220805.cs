using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_GRUPO_20220805
{
    public int ID_GRUPO { get; set; }

    public string DS_GRUPO { get; set; } = null!;

    public int? ID_SISTEMA { get; set; }

    public bool FL_ATIVO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool? FL_GERENCIAR_PRODUTOS { get; set; }

    public bool? FL_ANALISAR_CREDITO { get; set; }
}
