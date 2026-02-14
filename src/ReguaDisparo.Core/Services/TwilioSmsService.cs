using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço de envio de SMS (implementação placeholder)
/// TODO: Implementar integração com provedor de SMS (Twilio, etc)
/// </summary>
public class TwilioSmsService : ISmsService
{
    private readonly ILogger<TwilioSmsService> _logger;

    public TwilioSmsService(ILogger<TwilioSmsService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> SendSmsAsync(string phoneNumber, string message, string? ddd = null)
    {
        try
        {
            _logger.LogInformation("Enviando SMS para {Phone} (DDD: {Ddd})", phoneNumber, ddd);
            
            // TODO: Implementar integração com Twilio ou outro provedor
            // Por enquanto, apenas simula o envio
            await Task.Delay(100); // Simula chamada assíncrona
            
            _logger.LogInformation("SMS enviado com sucesso para {Phone}", phoneNumber);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao enviar SMS para {Phone}", phoneNumber);
            return false;
        }
    }

    public async Task<int> SendBulkSmsAsync(List<SmsMessage> messages)
    {
        var sent = 0;
        
        foreach (var message in messages)
        {
            if (await SendSmsAsync(message.PhoneNumber, message.Message, message.Ddd))
            {
                sent++;
            }
        }

        _logger.LogInformation("Enviados {Sent} de {Total} SMS", sent, messages.Count);
        return sent;
    }
}
