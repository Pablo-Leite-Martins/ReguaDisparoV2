using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_CLASSIFICACAO_COBRANCA_LOG
{
    public int ID_CASO_COBRANCA_CLASSIFICACAO_COBRANCA_LOG { get; set; }

    public int ID_CASO_COBRANCA_CLASSIFICACAO_COBRANCA { get; set; }

    public string DS_CASO_COBRANCA_CLASSIFICACAO_COBRANCA { get; set; } = null!;

    public bool FL_PERMITE_NEGOCIACAO { get; set; }

    public string DS_LEGENDA { get; set; } = null!;

    public int? ID_CASO_COBRANCA_CLASSIFICACAO_GRUPO_EXCECAO { get; set; }

    public string? DS_CASO_COBRANCA_CLASSIFICACAO_COBRANCA_NOVO { get; set; }

    public bool? FL_PERMITE_NEGOCIACAO_NOVO { get; set; }

    public string? DS_LEGENDA_NOVO { get; set; }

    public int? ID_CASO_COBRANCA_CLASSIFICACAO_GRUPO_EXCECAO_NOVO { get; set; }

    public DateTime DT_ACAO { get; set; }

    public string DS_ACAO { get; set; } = null!;

    public int ID_USUARIO_ACAO { get; set; }
}
