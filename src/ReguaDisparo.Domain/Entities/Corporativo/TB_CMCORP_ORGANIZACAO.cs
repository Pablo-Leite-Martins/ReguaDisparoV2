using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.Corporativo;

public partial class TB_CMCORP_ORGANIZACAO
{
    public string ID_ORGANIZACAO { get; set; } = null!;

    public string DS_RAZAO_SOCIAL { get; set; } = null!;

    public string DS_NOME_FANTASIA { get; set; } = null!;

    public string NR_CNPJ { get; set; } = null!;

    public int ID_CIDADE { get; set; }

    public string DS_BAIRRO { get; set; } = null!;

    public string DS_LOGRADOURO { get; set; } = null!;

    public int NR_ENDERECO { get; set; }

    public string? DS_COMPLEMENTO_ENDERECO { get; set; }

    public string DS_EMAIL { get; set; } = null!;

    public string NR_TELEFONE { get; set; } = null!;

    public string? DS_SITE { get; set; }

    public string DS_URL_WEBSERVICE { get; set; } = null!;

    public string DS_LOGIN_UAU { get; set; } = null!;

    public string DS_SENHA_UAU { get; set; } = null!;

    public string? DS_URL_LOGO { get; set; }

    public string? DS_URL_GALERIA1 { get; set; }

    public string? DS_URL_GALERIA2 { get; set; }

    public string? DS_URL_GALERIA3 { get; set; }

    public string? DS_COR_LOGO { get; set; }

    public string? NOME_BANCO_CRM { get; set; }

    public bool? FL_CRM_INTEGRADO_ERP { get; set; }

    public string? DS_URL_WEBSERVICE_CAPYS { get; set; }

    public bool? FL_PORTAL_EMBUTIDO_SITE { get; set; }

    public string? DS_URL_LOGO_ACOMPANHAMENTOOBRA { get; set; }

    public string? DS_URL_LOGO_ANTECIPACAOPARCELAS { get; set; }

    public string? DS_URL_LOGO_ASSISTENCIATECNICA { get; set; }

    public string? DS_URL_LOGO_ATENDIMENTO { get; set; }

    public string? DS_URL_LOGO_ATUALIZACAOCADASTRAL { get; set; }

    public string? DS_URL_LOGO_BOLETOVENCIDO { get; set; }

    public string? DS_URL_LOGO_DOCUMENTOSCLIENTE { get; set; }

    public string? DS_URL_LOGO_DUVIDASFREQUENTES { get; set; }

    public string? DS_URL_LOGO_EXTRATO { get; set; }

    public string? DS_URL_LOGO_EXTRATOIRRF { get; set; }

    public string? DS_URL_LOGO_IMAGENS { get; set; }

    public string? DS_URL_LOGO_MEUIMOVEL { get; set; }

    public string? DS_URL_LOGO_SEGUNDAVIA { get; set; }

    public string? DS_URL_LOGO_ULTIMASNOTICIAS { get; set; }

    public string? DS_REMETENTE_EMAIL { get; set; }

    public string? DS_SMTP_EMAIL { get; set; }

    public int? NR_PORTA_SMTP_EMAIL { get; set; }

    public string? DS_USUARIO_EMAIL { get; set; }

    public string? DS_SENHA_EMAIL { get; set; }

    public string? ID_ONESIGNAL { get; set; }

    public bool? FLG_ENABLESSL_EMAIL { get; set; }

    public string? DS_TOKEN { get; set; }

    public string? COD_ERP_INTEGRACAO { get; set; }

    public DateTime? DT_EXPIRACAO_CONTRATO { get; set; }

    public string? DS_URL_APP_GOOGLE_PLAY { get; set; }

    public string? DS_URL_APP_APPLE_STORE { get; set; }

    public bool? FL_FILA_ATENDIMENTO_DINAMICA { get; set; }

    public bool? FL_PROMESSA_PAGAMENTO { get; set; }

    public bool? FL_EXIBIR_ULTIMO_NIVEL_AT { get; set; }

    public bool? FL_BAIXA_PAGAMENTO_UAU { get; set; }

    public bool? FL_STATUS_UNIDADE_UAU { get; set; }

    public bool? FL_ENVIAR_EMAIL { get; set; }

    public string? DS_LOGIN_AD { get; set; }

    public string? DS_SENHA_AD { get; set; }

    public string? DS_TOKEN_CAPYS { get; set; }

    public string? DS_URL_CRM_CAPYS { get; set; }

    public bool? FL_SINC_DOC_UAU { get; set; }

    public bool? FL_SINC_PRECO_UAU { get; set; }

    public bool FL_SERVICO_EMAIL_RECEPTIVO { get; set; }

    public bool FL_SERVICO_SINC_COMENTARIO_UAU { get; set; }

    public string? ID_SERVICO_SINC_ATENDIMENTO_UAU { get; set; }

    public string? DS_EMAIL_SERVICO_SINC_ATENDIMENTO_UAU { get; set; }

    public bool? FL_SERVICO_SINC_COMENTARIO_VENDA_UAU { get; set; }

    public bool? FL_SERVICO_TRIAGEM_AUTOMATICA { get; set; }

    public bool FL_ATIVO { get; set; }

    public bool? FL_V1 { get; set; }

    public string? DS_URL_IMAGEM_PLANO_FUNDO_TELA_LOGIN_PORTALV2 { get; set; }

    public string? DS_URL_IMAGEM_PLANO_FUNDO_TELA_HOME_PORTALV2 { get; set; }

    public string? DS_URL_IMAGEM_ASSISTENTE_VIRTUAL_PORTALV2 { get; set; }

    public string? DS_COR_SECUNDARIA_PORTALV2 { get; set; }

    public string? DS_COR_TEXTO_PRIMARIA_PORTALV2 { get; set; }

    public string? DS_COR_TEXTO_SECUNDARIA_PORTALV2 { get; set; }

    public string? DS_DNS_PORTALV2 { get; set; }

    public bool? FL_UAU_CLOUD { get; set; }

    public string? DS_URL_GATEWAY { get; set; }

    public string? DS_LOGIN_GATEWAY { get; set; }

    public string? DS_SENHA_GATEWAY { get; set; }

    public virtual TB_CMCORP_CIDADE ID_CIDADENavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCORP_REQUEST_API> TB_CMCORP_REQUEST_APIs { get; set; } = new List<TB_CMCORP_REQUEST_API>();
}
