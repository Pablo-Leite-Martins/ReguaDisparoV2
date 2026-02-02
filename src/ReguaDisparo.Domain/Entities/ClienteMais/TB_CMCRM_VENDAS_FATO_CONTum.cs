using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_VENDAS_FATO_CONTum
{
    public int ID_CONTA { get; set; }

    public string DS_NOME_CONTA { get; set; } = null!;

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

    public int? ID_USUARIO_CADASTRO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public DateTime? DT_ATUALIZACAO { get; set; }

    public int? ID_USUARIO_PROPRIETARIO { get; set; }

    public string? NR_CPF_CONTA { get; set; }

    public string? DS_EMAIL_CONTA { get; set; }

    public string? NR_TELEFONE { get; set; }

    public string? DS_NOME_PROPONENTE { get; set; }

    public string? NR_CPF_PROPONENTE { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public string? DS_ORIGEM_LEAD { get; set; }

    public string? DS_ORIGEM_LEAD_COMP { get; set; }

    public string? DS_USUARIO_PROPRIETARIO { get; set; }

    public string? DS_USUARIO_CADASTRO { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public string? DS_EQUIPE_VENDAS { get; set; }

    public string? DS_NOME_GERENTE { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_CASO_REPASSE { get; set; }

    public string? DS_CASO { get; set; }

    public int? ID_TIPO_CASO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public bool? FL_INICIO_CASO { get; set; }

    public bool? FL_FIM { get; set; }

    public string? DS_CATEGORIA_ATENDIMENTO { get; set; }

    public int? NR_SLA { get; set; }

    public string? DS_TIPO_CANAL_ATENDIMENTO { get; set; }

    public int? NR_DIAS_ESTAGNADO { get; set; }

    public string? DS_ULTIMO_HISTORICO { get; set; }

    public string? DS_NOME_USUARIO_RESPONSAVEL_ULTIMO_HISTORICO { get; set; }

    public DateTime? DT_CADASTRO_ULTIMO_HISTORICO { get; set; }

    public int? ID_ETAPA { get; set; }

    public string? DS_ETAPA { get; set; }

    public int? NR_ETAPA { get; set; }

    public int? NR_SLO { get; set; }

    public int FL_VIROU_VENDA { get; set; }

    public bool? FL_STATUS_VENDA { get; set; }

    public int? ID_UNIDADE_VENDA { get; set; }

    public bool? FL_CONFIRMACAO_SINAL { get; set; }

    public string? DS_PRODUTO { get; set; }

    public string? DS_PRODUTO_COMP { get; set; }

    public int? ID_PRODUTO_INTERESSE { get; set; }

    public string? ID_CHAVE_ERP_PRODUTO { get; set; }

    public int? ID_PRODUTO_VENDA { get; set; }

    public string? DS_PRODUTO_VENDA { get; set; }

    public string? DS_PROPOSTA_STATUS { get; set; }

    public int? ID_USUARIO_RESPONSAVEL_ANALISE_CREDITO { get; set; }

    public string? DS_STATUS_ANALISE_CREDITO { get; set; }

    public DateTime? DT_VALIDADE_ANALISE_CREDITO { get; set; }

    public decimal? VL_SICAQ_APROVADO { get; set; }

    public int? ID_ANALISE_CREDITO_STATUS { get; set; }

    public int? ID_GERENTE_PROPRIETARIO { get; set; }

    public int? ID_COORDENADOR_VENDAS_PROPRIETARIO { get; set; }

    public int? ID_GERENTE_REGIONAL_PROPRIETARIO { get; set; }

    public int? ID_GERENTE_COMERCIAL_PROPRIETARIO { get; set; }

    public int? ID_SUPERINTENDENTE_PROPRIETARIO { get; set; }

    public int? ID_COORDENADOR_MARKETING_PROPRIETARIO { get; set; }

    public int? ID_DIRETOR_PROPRIETARIO { get; set; }

    public DateTime? DT_PROXIMO_CASO_ATIVIDADE { get; set; }

    public string? DS_PROXIMO_TIPO_ATIVIDADE { get; set; }

    public string? DS_PROXIMO_ICONE_ATIVIDADE { get; set; }

    public DateTime? DT_ULTIMO_CASO_ATIVIDADE_CONCLUSAO { get; set; }

    public string? DS_ULTIMO_TIPO_ATIVIDADE { get; set; }

    public string? DS_ULTIMO_ICONE_ATIVIDADE { get; set; }
}
