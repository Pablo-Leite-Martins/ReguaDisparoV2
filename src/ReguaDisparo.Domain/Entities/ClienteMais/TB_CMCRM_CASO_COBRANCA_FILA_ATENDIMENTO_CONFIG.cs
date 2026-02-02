using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FILA_ATENDIMENTO_CONFIG
{
    public int ID_CASO_COBRANCA_FILA_ATENDIMENTO_CONFIG { get; set; }

    public int NR_PRAZO_CONTATO_EFETIVO { get; set; }

    public int NR_PRAZO_TENTATIVA_CONTATO { get; set; }

    public int NR_PRAZO_CONTATO_NAO_EFETIVO { get; set; }
}
