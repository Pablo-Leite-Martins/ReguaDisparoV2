using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class CMCRM_VW_LISTA_SOLICITACO
{
    public int ID_CASO { get; set; }

    public string DS_CASO { get; set; } = null!;

    public int ID_TIPO_CASO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public bool? FL_FIM { get; set; }

    public int? NR_DIAS_ESTAGNADO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int? ID_MOTIVO_CANCELAMENTO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public string? DS_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int? NR_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO { get; set; }

    public int? NR_SLA { get; set; }

    public string? DS_PROPOSTA_STATUS { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public string? DS_ORIGEM_LEAD { get; set; }

    public string? DS_ORIGEM_LEAD_COMP { get; set; }

    public int ID_TIPO_CANAL_ATENDIMENTO { get; set; }

    public string DS_TIPO_CANAL_ATENDIMENTO { get; set; } = null!;

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public string? DS_ETAPA_TIPO_CASO { get; set; }

    public int? NR_ETAPA_TIPO_CASO { get; set; }

    public int? NR_SLO { get; set; }

    public int ID_CONTA { get; set; }

    public string DS_NOME_CONTA { get; set; } = null!;

    public string? NR_CPF_CONTA { get; set; }

    public string? DS_EMAIL_CONTA { get; set; }

    public string? DS_NOME_PROPONENTE { get; set; }

    public string? NR_CPF_PROPONENTE { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? DS_ULTIMO_HISTORICO { get; set; }

    public DateTime? DT_CADASTRO_ULTIMO_HISTORICO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public string? DS_STATUS_ANALISE_CREDITO { get; set; }

    public DateTime? DT_VALIDADE_ANALISE_CREDITO { get; set; }

    public decimal? VL_SICAQ_APROVADO { get; set; }

    public int? ID_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_MOTIVO_CANCELAMENTO { get; set; }

    public string? DS_PRODUTO { get; set; }

    public int? ID_PRODUTO_INTERESSE { get; set; }

    public bool? FL_STATUS_VENDA { get; set; }

    public int? ID_UNIDADE_VENDA { get; set; }

    public int? ID_PRODUTO_VENDA { get; set; }

    public string? DS_PRODUTO_VENDA { get; set; }

    public bool? FL_CONFIRMACAO_SINAL { get; set; }

    public string? DS_PRODUTO_COMP { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public string? DS_EQUIPE_VENDAS { get; set; }

    public int? ID_EQUIPE_VENDAS_PROPRIETARIO { get; set; }

    public string? DS_EQUIPE_VENDAS_PROPRIETARIO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ULTIMO_HISTORICO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_PROPOSTA { get; set; }

    public string? DS_NOME_USUARIO_APROVACAO_PROPOSTA { get; set; }

    public string? DS_NOME_USUARIO_CADASTRO { get; set; }

    public string? DS_STATUS_ETAPA { get; set; }

    public decimal? VL_OPORTUNIDADE { get; set; }

    public string? DS_STATUS { get; set; }

    public DateTime? DT_FECHAMENTO { get; set; }

    public decimal? NR_PROBABILIDADE_FECHAMENTO { get; set; }
}
