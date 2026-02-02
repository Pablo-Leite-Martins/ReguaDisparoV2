using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReguaDisparo.Core.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ReguaDisparo.Infrastructure.Services;

/// <summary>
/// Implementação de envio de e-mail usando SendGrid
/// </summary>
public class SendGridEmailService : IEmailService
{
    private readonly ILogger<SendGridEmailService> _logger;
    private readonly SendGridClient _client;
    private readonly EmailSettings _settings;

    public SendGridEmailService(
        ILogger<SendGridEmailService> logger,
        IOptions<EmailSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
        _client = new SendGridClient(_settings.SendGridApiKey);
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body, string? attachmentPath = null)
    {
        try
        {
            var from = new EmailAddress(_settings.From, _settings.FromName);
            var toAddress = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, body, body);

            if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
            {
                var bytes = await File.ReadAllBytesAsync(attachmentPath);
                var file = Convert.ToBase64String(bytes);
                msg.AddAttachment(Path.GetFileName(attachmentPath), file);
            }

            var response = await _client.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("E-mail enviado com sucesso para {To}", to);
                return true;
            }

            var errorBody = await response.Body.ReadAsStringAsync();
            _logger.LogError("Falha ao enviar e-mail para {To}. Status: {Status}, Erro: {Error}", 
                to, response.StatusCode, errorBody);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao enviar e-mail para {To}", to);
            return false;
        }
    }

    public async Task<int> SendBulkEmailsAsync(List<EmailMessage> messages)
    {
        int successCount = 0;

        foreach (var message in messages)
        {
            var result = await SendEmailAsync(message.To, message.Subject, message.Body, message.AttachmentPath);
            if (result)
                successCount++;

            // Delay para evitar rate limiting
            await Task.Delay(100);
        }

        _logger.LogInformation("Enviados {Success} de {Total} e-mails", successCount, messages.Count);
        return successCount;
    }
}

public class EmailSettings
{
    public bool UseSendGrid { get; set; }
    public string From { get; set; } = string.Empty;
    public string FromName { get; set; } = "Sistema";
    public string SendGridApiKey { get; set; } = string.Empty;
    public string SmtpHost { get; set; } = string.Empty;
    public int SmtpPort { get; set; } = 587;
    public string SmtpUser { get; set; } = string.Empty;
    public string SmtpPassword { get; set; } = string.Empty;
}
