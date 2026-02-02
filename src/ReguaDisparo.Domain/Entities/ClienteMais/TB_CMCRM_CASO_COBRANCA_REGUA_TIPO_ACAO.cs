using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_TIPO_ACAO
{
    public int ID_CASO_COBRANCA_REGUA_TIPO_ACAO { get; set; }

    public string DS_TIPO_ACAO { get; set; } = null!;

    public bool FL_ACAO_AGENDADA { get; set; }
}
