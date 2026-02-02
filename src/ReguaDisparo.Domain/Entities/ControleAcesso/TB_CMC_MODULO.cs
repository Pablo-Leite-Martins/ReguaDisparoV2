using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_MODULO
{
    public string DS_MODULO { get; set; } = null!;

    public string DS_DESCRICAO { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public int ID_MODULO { get; set; }

    public virtual ICollection<TB_CMC_GRUPO_MODULO> TB_CMC_GRUPO_MODULOs { get; set; } = new List<TB_CMC_GRUPO_MODULO>();

    public virtual ICollection<TB_CMC_MODULO_PRODUCAO> TB_CMC_MODULO_PRODUCAOs { get; set; } = new List<TB_CMC_MODULO_PRODUCAO>();
}
