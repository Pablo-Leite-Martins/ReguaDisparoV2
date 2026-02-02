using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONFIG_GERAL
{
    public int ID_CONFIG_GERAL { get; set; }

    public string HR_INICIO { get; set; } = null!;

    public string HR_FIM { get; set; } = null!;

    public int FL_PESQUISA_SATISFACAO { get; set; }

    public int FL_TELA_RENEGOCIACAO { get; set; }

    public int FL_FILA_COBRANCA { get; set; }

    public int FL_DIAS_SLA { get; set; }

    public int FL_RENEGOCIACAO_PARCELAS { get; set; }

    public int FL_MOTIVO_PROBLEMA { get; set; }

    public bool? FL_EMAIL_ETAPA_NAO_PROCEDE { get; set; }

    public bool FL_ASSISTENCIA_TECNICA_VINCULADA { get; set; }

    public bool FL_CABECALHO_EMAIL { get; set; }

    public string DS_TIPO_CONTROLE_PRODUTO_ATENDIMENTO_GERAL { get; set; } = null!;

    public string DS_TIPO_CONTROLE_CATEGORIA_ATENDIMENTO_GERAL { get; set; } = null!;

    public bool FL_ACESSO_RAPIDO_ABERTURA_ATENDIMENTO { get; set; }

    public bool FL_FINALIZAR_CASO_COM_DUAS_ETAPAS { get; set; }

    public bool FL_ENVIAR_EMAIL_CLIENTE_AT { get; set; }

    public bool FL_FINALIZAR_CASO_ABRINDO_NOVO { get; set; }

    public string DS_DATA_ABERTURA_ATENDIMENTO_TRIAGEM { get; set; } = null!;

    public bool FL_PARCELAS_BOLETO { get; set; }

    public bool FL_RESPEITAR_LIMITE_MODELO { get; set; }

    public bool FL_VIEW_PRODUTO_VENDA { get; set; }

    public bool FL_VIEW_PESSOA { get; set; }

    public bool FL_ALCADAS_DESCONTO { get; set; }

    public bool FL_USUARIO_UAU_BOLETO { get; set; }

    public bool FL_TRIAGEM_TELA { get; set; }

    public bool FL_PESQUISA_SATISFACAO_OBRIGATORIA_ASSISTENCIA_TECNICA { get; set; }

    public bool FL_ACORDO_ALTERAR_DATA_VENCIMENTO_FUTURA { get; set; }

    public int? NR_DIAS_PROMESSA_PAGAMENTO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_PADRAO_BOLETO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_PADRAO_EXTRATO { get; set; }

    public bool FL_MOSTRAR_VENDA_CANCELADA { get; set; }

    public bool FL_ASSISTENCIA_TECNICA_DURACAO_REAL { get; set; }

    public bool FL_INTEGRACAO_URA_CRM { get; set; }

    public bool FL_ANTECIPACAO_PARCELAS_BOLETO { get; set; }

    public bool FL_PERMITIR_RETRICAO_UAU_GERACAO_BOLETO { get; set; }

    public bool FL_AT_SLO_CONTAR_DATA_AGENDAMENTO { get; set; }

    public bool FL_AGENDAR_EM_FERIADOS_E_FIM_DE_SEMANA { get; set; }

    public bool FL_AT_PERMITIR_AGENDAMENTO_RETROATIVO { get; set; }

    public int NR_DIAS_MINIMO_GERAR_BOLETO_PARCELA_VENCIDA { get; set; }

    public int ID_INTEGRADOR_URA { get; set; }

    public bool? FL_ATENDIMENTO_WHATSAPP { get; set; }

    public bool? FL_UTILIZAR_SEGURANCA_GRUPO_POR_PRODUTO { get; set; }

    public bool FL_AT_PESQUISA_SATISFACAO_POS_CONCLUSAO { get; set; }

    public bool FL_ALTERAR_STATUS_ESCRITURA { get; set; }

    public bool FL_COB_DISPARAR_EMAIL_COBRANCA_FIM_DE_SEMANA { get; set; }

    public bool FL_PERMITIR_TRANSFERIR_ATENDIMENTO { get; set; }

    public bool FL_ALTERAR_STATUS_COBRANCA { get; set; }

    public bool? FL_MOD_ATENDIMENTO_MULT_CASOS { get; set; }

    public bool FL_FILA_ABRIR_CASO_PARA_TODAS_VENDAS { get; set; }

    public bool FL_ACRESCENTAR_RESIDUAL_GERAR_BOLETO { get; set; }

    public bool FL_BLOQUEAR_COBRANCA_QUANDO_PROMESSA { get; set; }

    public bool FL_IMPORTAR_PARA_UAU { get; set; }

    public bool FL_COB_PERMITE_REGISTRAR_ACORDO { get; set; }

    public bool FL_PERMITIR_ENVIO_EMAILS_CONTA_VINCULADA_USUARIO { get; set; }

    public bool FL_COB_PERMITE_INSERIR_LANCAMENTO_CUSTA { get; set; }

    public bool FL_ENVIAR_EMAIL_AGENDAMENTO_ASS { get; set; }

    public bool? FL_EXIBIR_CUSTOS_CONCLUIR_MANUTENCAO { get; set; }

    public bool FL_PERMITE_NEGOCIACAO { get; set; }

    public bool FL_PERMITIR_MANUTENCAO_CONCLUIDA { get; set; }

    public bool FL_SEGURANCA_GRUPO_PRODUTO_VISTORIA { get; set; }

    public bool FL_NOTIFICA_GRUPO { get; set; }

    public bool FL_ENVIAR_EMAIL_MUDANCA_ETAPA { get; set; }

    public bool FL_NPS { get; set; }

    public bool FL_ENVIO_HORARIOS_DISPONIVEIS { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_URA { get; set; }

    public bool FL_LISTAR_TODOS_USUARIOS_TRANSFERENCIA { get; set; }

    public bool FL_MOSTRAR_NOME_ATENDENTE { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_TRIAGEM { get; set; }

    public bool? FL_MENSAGEM_PERSONALIZADA { get; set; }

    public bool? FL_SLA_DIAS_CORRIDOS { get; set; }

    public int? NR_AGENDAMENTOS_HORARIO { get; set; }

    public int ID_RETORNO_ETAPA_CASO { get; set; }

    public bool FL_RENEGOCIACAO_ANALISE { get; set; }

    public bool FL_RESTRICAO_GRUPO_OBRA { get; set; }

    public bool FL_ENVIAR_HISTORICO_EMAIL { get; set; }

    public bool FL_ENVIO_AUDIO_HELPDESK { get; set; }

    public bool FL_RESTRICAO_GRUPO_USUARIO { get; set; }

    public bool FL_PESQUISA_SATISFACAO_SIMPLIFICADA { get; set; }

    public bool FL_FINALIZAR_REPARO_SEM_MODAL { get; set; }

    public bool FL_AVANCAR_ETAPA_REPASSE { get; set; }

    public bool FL_PARALISAR_CASO_AT_SEM_SLA { get; set; }

    public bool FL_ULTIMO_MODULO { get; set; }

    public bool FL_FINALIZAR_CHAT { get; set; }

    public bool FL_AGENDAMENTO_HORARIOS_CADASTRADOS { get; set; }

    public bool FL_ESCOLHER_FORMULARIO_ATENDIMENTO { get; set; }

    public bool FL_ESCOLHER_FORMULARIO_VISTORIA { get; set; }

    public bool FL_ESCOLHER_FORMULARIO_ASSISTENCIA { get; set; }

    public bool FL_ABRIR_CASO_VENDA_CANCELADA { get; set; }

    public bool FL_EDITAR_VALORES_RENEGOCIACAO { get; set; }

    public bool FL_UTILIZAR_ACAO_DINAMICA_PADRAO_VISTORIA { get; set; }

    public string? DS_EMAIL_ENVIO_VISTORIA { get; set; }

    public string? DS_EMAIL_ENVIO_ASSIS_TECNICA { get; set; }

    public bool FL_AGENDAMENTO_HORARIOS_CADASTRADOS_VISTORIA { get; set; }

    public int? ID_COMPROMISSO_AGENDAMENTO_VISTORIA_INICIAL { get; set; }

    public int? ID_COMPROMISSO_AGENDAR_MANUTENCAO { get; set; }

    public bool? FL_EDITAR_EMAILS_COPIA_CARBONO { get; set; }

    public bool FL_ENVIAR_EMAIL_ABERTURA_ATENDIMENTO_VISTORIA { get; set; }

    public bool FL_NOME_ASSINANTE_PRE_DEFINIDO_FORMULARIO_VIST { get; set; }

    public bool FL_PESQUISA_SATISFACAO_WPP_ASSIS_TEC { get; set; }

    public bool FL_PESQUISA_SATISFACAO_WPP_ATENDIMENTO_CLIENTE { get; set; }

    public bool FL_ENVIO_PESQUISA_MANUAL_ATENDIMENTO { get; set; }

    public bool FL_ENVIO_PESQUISA_MANUAL_ASSIS_TECNICA { get; set; }

    public bool FL_NOME_ASSINANTE_PRE_DEFINIDO_FORMULARIO_AT { get; set; }

    public bool FL_LISTA_TEMPLATE_PRODUTO { get; set; }

    public bool FL_ESCOLHER_MODULO_ATENDIMENTO_URA { get; set; }

    public bool FL_PREENCHER_ASSINATURA_FORMULARIO { get; set; }

    public int? ID_TIPO_DOCUMENTO_FORMULARIO_CONFORME { get; set; }

    public int? ID_TIPO_DOCUMENTO_FORMULARIO_NAO_CONFORME { get; set; }

    public bool FL_FORMATO_BOLETO_CARNE { get; set; }

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO? ID_CATEGORIA_ATENDIMENTO_URANavigation { get; set; }
}
