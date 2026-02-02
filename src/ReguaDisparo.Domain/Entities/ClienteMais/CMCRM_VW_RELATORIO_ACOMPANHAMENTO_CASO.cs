using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_RELATORIO_ACOMPANHAMENTO_CASO
{
    public int CASO { get; set; }

    public string? PRODUTO { get; set; }

    public string? EMPREENDIMENTO { get; set; }

    public string? BLOCO { get; set; }

    public string? UNIDADE { get; set; }

    public string? CATEGORIA_ATENDIMENTO_COMPLETA { get; set; }

    public string CATEGORIA_ATENDIMENTO { get; set; } = null!;

    public string NOME_USUARIO_RESPONSAVEL { get; set; } = null!;

    public string? CLIENTE { get; set; }

    public string ETAPA { get; set; } = null!;

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public string STATUS { get; set; } = null!;

    public int? TEMPO_ABERTO_EM_DIAS { get; set; }

    public string DESCRICAO_CASO { get; set; } = null!;

    public string? HISTORICO { get; set; }

    public string DS_MOTIVO_INADIMPLENCIA { get; set; } = null!;

    public string DS_RESULTADO_CONTATO { get; set; } = null!;

    public string? CANAL_ATENDIMENTO { get; set; }

    public string? NOME_USUARIO_ABERTURA { get; set; }

    public int? ID_USUARIO_USUARIO_ABERTURA { get; set; }

    public string DS_TIPO_CASO { get; set; } = null!;

    public int ID_TIPO_CASO { get; set; }

    public string? DS_EMPREENDIMENTO_PA { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public bool? FL_STATUS_VENDA { get; set; }

    public int? ID_TIPO_PESO_ATENDIMENTO { get; set; }

    public string? DS_TIPO_PESO_ATENDIMENTO { get; set; }

    public string? DS_GRUPO { get; set; }
}
