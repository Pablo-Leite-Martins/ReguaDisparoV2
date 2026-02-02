using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_RECEBER_COBRANCA_LOG
{
    public int ID_RECEBER_COBRANCA_LOG { get; set; }

    public int ID_USUARIO { get; set; }

    public int ID_CONTA_ALTERADA { get; set; }

    public DateTime DT_ALTERACAO { get; set; }

    public bool FL_VALOR_ANTIGO { get; set; }

    public bool FL_VALOR_NOVO { get; set; }
}
