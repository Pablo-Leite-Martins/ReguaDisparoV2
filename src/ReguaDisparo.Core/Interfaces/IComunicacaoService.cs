using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de envio de comunicações
/// </summary>
public interface IComunicacaoService
{
    /// <summary>
    /// Envia e-mails para uma lista de destinatários
    /// </summary>
    Task EnviarEmailsAsync(
        List<DestinatarioEmail> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Envia SMS para uma lista de destinatários
    /// </summary>
    Task EnviarSmsAsync(
        List<DestinatarioSms> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Envia mensagens via WhatsApp
    /// </summary>
    Task EnviarWhatsAppAsync(
        List<DestinatarioWhatsApp> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Registra histórico de envio
    /// </summary>
    Task RegistrarHistoricoEnvioAsync(
        int idAcao,
        string tipoEnvio,
        string destinatario,
        bool sucesso,
        string? mensagemErro,
        string nomeBancoCrm);

    /// <summary>
    /// Registra falha de envio
    /// </summary>
    Task RegistrarFalhaEnvioAsync(
        int idAcao,
        string tipoEnvio,
        string destinatario,
        string motivoFalha,
        string nomeBancoCrm);
}

/// <summary>
/// Classe para representar um destinatário de e-mail
/// </summary>
public class DestinatarioEmail
{
    public string Email { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public Dictionary<string, string> Variaveis { get; set; } = new();
}

/// <summary>
/// Classe para representar um destinatário de SMS
/// </summary>
public class DestinatarioSms
{
    public string Telefone { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public Dictionary<string, string> Variaveis { get; set; } = new();
}

/// <summary>
/// Classe para representar um destinatário de WhatsApp
/// </summary>
public class DestinatarioWhatsApp
{
    public string Telefone { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public Dictionary<string, string> Variaveis { get; set; } = new();
}
