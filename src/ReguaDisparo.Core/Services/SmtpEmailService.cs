using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using ReguaDisparo.Core.Interfaces;

namespace ReguaDisparo.Infrastructure.Services;

/// <summary>
/// Implementação de envio de e-mail usando SMTP (MailKit)
/// </summary>
public class SmtpEmailService : IEmailService
{
    private readonly ILogger<SmtpEmailService> _logger;
    private readonly EmailSettings _settings;

    public SmtpEmailService(
        ILogger<SmtpEmailService> logger,
        IOptions<EmailSettings> settings)
    {
        _logger = logger;
        _settings = settings.Value;
    }

    public async Task<bool> SendEmailAsync(string to, string subject, string body, string? attachmentPath = null)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.FromName, _settings.From));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };

            if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
            {
                builder.Attachments.Add(attachmentPath);
            }

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.SmtpUser, _settings.SmtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            _logger.LogInformation("E-mail enviado com sucesso via SMTP para {To}", to);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao enviar e-mail via SMTP para {To}", to);
            return false;
        }
    }

    public async Task<int> SendBulkEmailsAsync(List<EmailMessage> messages)
    {
        int successCount = 0;

        using var client = new SmtpClient();
        await client.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_settings.SmtpUser, _settings.SmtpPassword);

        foreach (var emailMessage in messages)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_settings.FromName, _settings.From));
                message.To.Add(new MailboxAddress(emailMessage.To, emailMessage.To));
                message.Subject = emailMessage.Subject;

                var builder = new BodyBuilder { HtmlBody = emailMessage.Body };

                if (!string.IsNullOrEmpty(emailMessage.AttachmentPath) && File.Exists(emailMessage.AttachmentPath))
                {
                    builder.Attachments.Add(emailMessage.AttachmentPath);
                }

                message.Body = builder.ToMessageBody();

                await client.SendAsync(message);
                successCount++;

                _logger.LogDebug("E-mail enviado para {To}", emailMessage.To);

                // Delay para evitar sobrecarga
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao enviar e-mail para {To}", emailMessage.To);
            }
        }

        await client.DisconnectAsync(true);

        _logger.LogInformation("Enviados {Success} de {Total} e-mails via SMTP", successCount, messages.Count);
        return successCount;
    }
}
