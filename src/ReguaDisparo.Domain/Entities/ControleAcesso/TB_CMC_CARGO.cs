using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_CARGO
{
    public int ID_CARGO { get; set; }

    public string DS_CARGO { get; set; } = null!;

    public string ID_ORGANIZACAO { get; set; } = null!;

    public string? ID_CHAVE_ERP { get; set; }

    public virtual ICollection<TB_CMC_CARGO_USUARIO> TB_CMC_CARGO_USUARIOs { get; set; } = new List<TB_CMC_CARGO_USUARIO>();
}
