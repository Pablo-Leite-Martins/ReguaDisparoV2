using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_VENDAS_FATO_CASO
{
    public int ID_CASO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public bool? FL_FIM { get; set; }

    public int? ID_MOTIVO_CANCELAMENTO { get; set; }

    public string? DS_MOTIVO_CANCELAMENTO { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO { get; set; }

    public int? NR_SLA { get; set; }

    public int? NR_SLO { get; set; }

    public int? NR_DIAS_ESTAGNADO { get; set; }

    public string DS_TIPO_CANAL_ATENDIMENTO { get; set; } = null!;

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public string? DS_ETAPA { get; set; }

    public int? NR_ETAPA { get; set; }

    public string? DS_ULTIMO_HISTORICO { get; set; }

    public DateTime? DT_CADASTRO_ULTIMO_HISTORICO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ULTIMO_HISTORICO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL { get; set; }

    public string? DS_EQUIPE_VENDAS { get; set; }

    public string? DS_NOME_GERENTE { get; set; }

    public string? DS_STATUS_ETAPA { get; set; }

    public string? DS_NOME_CONTA { get; set; }

    public string? NR_RG { get; set; }

    public string? NR_CPF { get; set; }

    public string? DS_RG_ORGAO_EMISSOR { get; set; }

    public string? DS_RG_UF_EMISSOR { get; set; }

    public DateTime? DT_RG_VALIDADE { get; set; }

    public string? DS_RG_CATEGORIA { get; set; }

    public string? DS_RG_TIPO { get; set; }

    public DateTime? DT_RG_EMISSAO { get; set; }

    public DateTime? DT_NASCIMENTO { get; set; }

    public string? DS_NOME_PAI { get; set; }

    public string? DS_NOME_MAE { get; set; }

    public string? DS_LOGRADOURO_COBRANCA { get; set; }

    public int? NR_ENDERECO_COBRANCA { get; set; }

    public string? DS_COMPLEMENTO_COBRANCA { get; set; }

    public string? NR_CEP_COBRANCA { get; set; }

    public string? DS_LOGRADOURO_ENTREGA { get; set; }

    public int? NR_ENDERECO_ENTREGA { get; set; }

    public string? DS_COMPLEMENTO_ENTREGA { get; set; }

    public string? NR_CEP_ENTREGA { get; set; }

    public string? DS_SAUDACAO { get; set; }

    public string? DS_PROFISSAO { get; set; }

    public string? DS_NACIONALIDADE { get; set; }

    public string? DS_NATURALIDADE { get; set; }

    public string? DS_ESTADO_CIVIL { get; set; }

    public string? DS_REGIME_COMUNHAO { get; set; }

    public DateTime? DT_CASAMENTO { get; set; }

    public string? DS_SEXO { get; set; }

    public int? NR_FILHOS { get; set; }

    public int? NR_SCORE { get; set; }

    public decimal? VL_RENDA { get; set; }

    public int? NR_DEPENDENTES { get; set; }

    public string? DS_IMOVEL_PROPRIO { get; set; }

    public string? DS_VEICULO_PROPRIO { get; set; }

    public string? DS_TITULO { get; set; }

    public string? DS_MELHOR_HORARIO_ATENDIMENTO { get; set; }

    public bool? FL_WEB_TO_LEAD { get; set; }

    public bool? FL_CHAT_TO_LEAD { get; set; }

    public string? NR_CPF_CONTA { get; set; }

    public string? DS_EMAIL_CONTA { get; set; }

    public string? DS_NOME_PROPONENTE { get; set; }

    public string? NR_CPF_PROPONENTE { get; set; }

    public string? NR_TELEFONE { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public string? DS_NOME_USUARIO_CADASTRO { get; set; }

    public int? ID_EQUIPE_VENDAS_PROPRIETARIO { get; set; }

    public string? DS_EQUIPE_VENDAS_PROPRIETARIO { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public string? DS_ORIGEM_LEAD { get; set; }

    public string? DS_STATUS_ANALISE_CREDITO { get; set; }

    public DateTime? DT_VALIDADE_ANALISE_CREDITO { get; set; }

    public decimal? VL_SICAQ_APROVADO { get; set; }

    public string? DS_ANALISE_CREDITO_STATUS { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_PROPOSTA { get; set; }

    public string? DS_NOME_USUARIO_APROVACAO_PROPOSTA { get; set; }

    public string? DS_PROPOSTA_STATUS { get; set; }

    public bool? FL_STATUS_VENDA { get; set; }

    public bool? FL_CONFIRMACAO_SINAL { get; set; }

    public int FL_VIROU_VENDA { get; set; }

    public string? ID_CHAVE_ERP_PRODUTO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public string? DS_PRODUTO { get; set; }

    public string? NR_CONTRATO { get; set; }

    public int? ID_GERENTE { get; set; }

    public int? ID_COORDENADOR_MARKETING { get; set; }

    public int? ID_COORDENADOR_VENDAS { get; set; }

    public int? ID_GERENTE_REGIONAL { get; set; }

    public int? ID_GERENTE_COMERCIAL { get; set; }

    public int? ID_SUPERINTENDENTE { get; set; }

    public int? ID_DIRETOR { get; set; }

    public int? ID_UNIDADE { get; set; }

    public DateTime? DT_VENDA { get; set; }

    public int? ID_PROPOSTA { get; set; }

    public string? DS_EMPREENDIMENTO { get; set; }

    public string? DS_BLOCO { get; set; }

    public decimal? VL_COMISSAO_DIRETA { get; set; }

    public decimal? VL_COMISSAO_FATURADA { get; set; }

    public decimal? VL_TOTAL_COMISSAO { get; set; }

    public decimal? VL_VPL_MODELO { get; set; }

    public decimal? VL_VPL_PROPOSTA { get; set; }

    public decimal? VL_VPL_DIFERENCA { get; set; }

    public decimal? VL_LIQUIDO { get; set; }

    public decimal? VL_NOMINAL { get; set; }

    public bool? FL_ENVELOPE_ENVIADO { get; set; }

    public bool? FL_ASSINATURA_CONCLUIDA { get; set; }
}
