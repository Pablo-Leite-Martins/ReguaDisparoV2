using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_FILA_DATA_RETORNO
{
    public int ID_CASO_COBRANCA_FILA_DATA_RETORNO { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public DateTime DT_RETORNO { get; set; }

    public DateTime DT_ATUALIZACAO { get; set; }
}
