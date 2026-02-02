using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FATO_AT
{
    public int? ID_CASO { get; set; }

    public string? DS_PRACA { get; set; }

    public string? DS_EMPREENDIMENTO { get; set; }

    public string? DS_RESIDENCIAL { get; set; }

    public string? DS_PRODUTO_COMP { get; set; }

    public string? SUBASSUNTO_PRELIMINAR { get; set; }

    public string? DS_CASO { get; set; }

    public string? QUEM_ABRIU { get; set; }

    public string? DS_TIPO_CANAL_ATENDIMENTO { get; set; }

    public DateTime? DATA_ENTREGA_RESIDENCIAL { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public DateTime? DT_VISTORIA { get; set; }

    public DateTime? DT_REPARO { get; set; }

    public DateTime? DT_RESOLUCAO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public string? CLASSIFICACAO { get; set; }

    public string? DS_STATUS_SOLICITACAO { get; set; }

    public string? SUBASSUNTO_CLASSIFICACAO_FINAL { get; set; }

    public string? VISTORIADOR { get; set; }

    public string? DESCRICAO_SOLUCAO_VISTORIA { get; set; }

    public string? FUNCIONARIO { get; set; }

    public string? DESCRICAO_SOLUCAO_REPARO { get; set; }

    public string? CADASTRO_COMPLEMENTAR { get; set; }

    public string? CSAT { get; set; }

    public string? DS_CONTATO { get; set; }

    public string? DS_ETAPA { get; set; }

    public string? DS_MOTIVO_CANCELAMENTO { get; set; }

    public string? DS_COMODO { get; set; }

    public string? CLIENTE_AUSENTE_VISTORIA { get; set; }

    public string? CLIENTE_AUSENTE_REPARO { get; set; }

    public string? VIZINHO_AUSENTE_VISTORIA { get; set; }

    public string? VIZINHO_AUSENTE_REPARO { get; set; }

    public string? NAO_PERMITIDO { get; set; }

    public string? ANEXOS { get; set; }

    public string? AST_DYNAMICS { get; set; }

    public bool? FL_GARANTIA { get; set; }

    public string? ID_OCORRENCIA { get; set; }

    public int? ID_EMPREENDIMENTO { get; set; }

    public DateTime? DT_SOLUCAO { get; set; }

    public bool FL_CASO_RECORRENTE { get; set; }

    public bool? FL_INTEGRADO { get; set; }

    public string? DS_TIPO_PESO_ATENDIMENTO { get; set; }
}
