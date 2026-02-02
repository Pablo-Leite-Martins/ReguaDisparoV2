using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_PERFIL_USUARIO
{
    public int ID_PERFIL_USUARIO { get; set; }

    public string DS_PERFIL_USUARIO { get; set; } = null!;

    public virtual ICollection<TB_CMC_USUARIO> TB_CMC_USUARIOs { get; set; } = new List<TB_CMC_USUARIO>();
}
