using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA
{
    public int ID_CASO_COBRANCA_REGUA { get; set; }

    public string DS_NOME_REGUA { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public bool? FL_VALIDADO { get; set; }

    public int? ID_USUARIO_VALIDACAO { get; set; }

    public DateTime? DT_VALIDACAO { get; set; }
}
