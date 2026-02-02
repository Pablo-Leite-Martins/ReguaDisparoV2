using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_VALIDACAO
{
    public int ID_CASO_COBRANCA_REGUA_HISTORICO_VALIDACAO { get; set; }

    public int ID_CASO_COBRANCA_REGUA { get; set; }

    public bool FL_VALIDADO { get; set; }

    public int ID_USUARIO_VALIDACAO { get; set; }

    public DateTime DT_VALIDACAO { get; set; }

    public string DS_TERMO_RESPONSABILIDADE { get; set; } = null!;
}
