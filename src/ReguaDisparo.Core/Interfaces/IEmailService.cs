namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para envio de e-mails
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Envia um e-mail
    /// </summary>
    Task<bool> SendEmailAsync(string to, string subject, string body, string? attachmentPath = null);

    /// <summary>
    /// Envia múltiplos e-mails
    /// </summary>
    Task<int> SendBulkEmailsAsync(List<EmailMessage> messages);
}

public class EmailMessage
{
    public string To { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string? AttachmentPath { get; set; }
    public Dictionary<string, string> Metadata { get; set; } = new();
}
