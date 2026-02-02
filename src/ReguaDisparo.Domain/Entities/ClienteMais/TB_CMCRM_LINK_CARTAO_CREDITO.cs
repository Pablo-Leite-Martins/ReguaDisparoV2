using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_LINK_CARTAO_CREDITO
{
    public int ID_LINK_CARTAO_CREDITO { get; set; }

    public string ID_GUID { get; set; } = null!;

    public string ID_ORGANIZACAO { get; set; } = null!;

    public int ID_CONTA { get; set; }

    public int ID_USUARIO { get; set; }

    public string DS_PARCELAS_JSON { get; set; } = null!;

    public DateTime DT_CRIACAO { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool FL_UTILIZADO { get; set; }
}
