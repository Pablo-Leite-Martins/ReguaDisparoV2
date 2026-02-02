using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO_LOG
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO_LOG { get; set; }

    public DateTime DT_ACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public int? ID_CASO_COBRANCA_REGUA_ETAPA { get; set; }

    public string? DS_CAMPO { get; set; }

    public int NR_ORDEM { get; set; }

    public bool? FL_ORDEM_CRESCENTE { get; set; }
}
