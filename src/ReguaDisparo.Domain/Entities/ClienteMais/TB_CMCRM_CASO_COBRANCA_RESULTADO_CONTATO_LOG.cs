using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_RESULTADO_CONTATO_LOG
{
    public int ID_CASO_COBRANCA_RESULTADO_CONTATO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public DateTime DT_ACAO { get; set; }

    public string DS_RESULTADO_CONTATO_LOG { get; set; } = null!;

    public string DS_CLASSIFICACAO_LOG { get; set; } = null!;

    public bool? FL_ATIVO_LOG { get; set; }

    public int? NR_TEMPO_RETORNO_FILA_LOG { get; set; }

    public string? DS_RESULTADO_CONTATO { get; set; }

    public string? DS_CLASSIFICACAO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? NR_TEMPO_RETORNO_FILA { get; set; }
}
