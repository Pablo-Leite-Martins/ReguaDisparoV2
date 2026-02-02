using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_MODULO_PRODUCAO
{
    public int ID_SISTEMA { get; set; }

    public int ID_MODULO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public virtual TB_CMC_MODULO ID_MODULONavigation { get; set; } = null!;

    public virtual TB_CMC_SISTEMA ID_SISTEMANavigation { get; set; } = null!;
}
