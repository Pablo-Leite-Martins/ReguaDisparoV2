using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_MUDANCA_SENHA
{
    public string ID_GUID { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public DateTime DT_VALIDADE { get; set; }
}
