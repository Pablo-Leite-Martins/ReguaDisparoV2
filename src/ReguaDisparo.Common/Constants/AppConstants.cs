namespace ReguaDisparo.Common.Constants;

/// <summary>
/// Constantes de tipos de ação
/// </summary>
public static class ActionTypes
{
    public const string EMAIL = "EMAIL";
    public const string SMS = "SMS";
    public const string WHATSAPP = "WHATSAPP";
    public const string PESQUISA = "PESQUISA";
    public const string NPS = "NPS";
    public const string NPS_NOVAS_VENDAS = "NPS NOVAS VENDAS";
}

/// <summary>
/// Constantes de status
/// </summary>
public static class StatusTypes
{
    public const string ATIVO = "ATIVO";
    public const string INATIVO = "INATIVO";
    public const string PENDENTE = "PENDENTE";
    public const string ENVIADO = "ENVIADO";
    public const string ERRO = "ERRO";
    public const string AGENDADO = "AGENDADO";
}

/// <summary>
/// Constantes de configuração
/// </summary>
public static class ConfigKeys
{
    public const string MAX_EMAILS_PER_DAY = "MaxEmailsPerDay";
    public const string MAX_SMS_PER_DAY = "MaxSmsPerDay";
    public const string PROCESS_ON_WEEKENDS = "ProcessOnWeekends";
    public const string LOG_PATH = "LogPath";
    public const string TIMEZONE = "TimeZone";
}

/// <summary>
/// Constantes de mensagens padrão
/// </summary>
public static class Messages
{
    // Sucesso
    public const string EMAIL_SENT_SUCCESS = "E-mail enviado com sucesso";
    public const string SMS_SENT_SUCCESS = "SMS enviado com sucesso";
    public const string WHATSAPP_SENT_SUCCESS = "WhatsApp enviado com sucesso";

    // Erros
    public const string EMAIL_SENT_ERROR = "Erro ao enviar e-mail";
    public const string SMS_SENT_ERROR = "Erro ao enviar SMS";
    public const string WHATSAPP_SENT_ERROR = "Erro ao enviar WhatsApp";
    public const string INVALID_EMAIL = "E-mail inválido";
    public const string INVALID_PHONE = "Telefone inválido";

    // Validações
    public const string REQUIRED_FIELD = "Campo obrigatório";
    public const string ORGANIZATION_NOT_FOUND = "Organização não encontrada";
    public const string DATABASE_NOT_CONFIGURED = "Banco de dados não configurado";
}

/// <summary>
/// Constantes de formato
/// </summary>
public static class FormatPatterns
{
    public const string DATE_BR = "dd/MM/yyyy";
    public const string DATETIME_BR = "dd/MM/yyyy HH:mm:ss";
    public const string DATE_US = "yyyy-MM-dd";
    public const string DATETIME_US = "yyyy-MM-dd HH:mm:ss";
    public const string PHONE_BR = "(00) 00000-0000";
    public const string CNPJ = "00.000.000/0000-00";
    public const string CPF = "000.000.000-00";
}
