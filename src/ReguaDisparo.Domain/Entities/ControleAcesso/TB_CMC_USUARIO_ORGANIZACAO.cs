using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ControleAcesso;

public partial class TB_CMC_USUARIO_ORGANIZACAO
{
    public int ID_USUARIO_ORGANIZACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public string ID_ORGANIZACAO { get; set; } = null!;

    public bool? FL_ATIVO { get; set; }

    public bool? FL_ADMINISTRADOR { get; set; }

    public string? DS_LOGIN_UAU { get; set; }

    public string? DS_SENHA_UAU { get; set; }

    public int? NR_AGENTE_DISCADOR { get; set; }

    public string? DS_LOGIN_AGENTE_DISCADOR { get; set; }

    public string? DS_SENHA_AGENTE_DISCADOR { get; set; }

    public int? ID_RAMAL_DISCADOR { get; set; }

    public virtual TB_CMC_USUARIO ID_USUARIONavigation { get; set; } = null!;
}
