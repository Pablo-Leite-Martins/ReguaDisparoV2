using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço de envio de WhatsApp (implementação placeholder)
/// TODO: Implementar integração com WhatsApp Business API ou Twilio WhatsApp
/// </summary>
public class TwilioWhatsAppService : IWhatsAppService
{
    private readonly ILogger<TwilioWhatsAppService> _logger;

    public TwilioWhatsAppService(ILogger<TwilioWhatsAppService> _logger)
    {
        this._logger = _logger;
    }

    public async Task<bool> SendWhatsAppAsync(string phoneNumber, string message, string? ddd = null)
    {
        try
        {
            _logger.LogInformation("Enviando WhatsApp para {Phone} (DDD: {Ddd})", phoneNumber, ddd);
            
            // TODO: Implementar integração com WhatsApp Business API
            // Por enquanto, apenas simula o envio
            await Task.Delay(100); // Simula chamada assíncrona
            
            _logger.LogInformation("WhatsApp enviado com sucesso para {Phone}", phoneNumber);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao enviar WhatsApp para {Phone}", phoneNumber);
            return false;
        }
    }

    public async Task<int> SendBulkWhatsAppAsync(List<WhatsAppMessage> messages)
    {
        var sent = 0;
        
        foreach (var message in messages)
        {
            if (await SendWhatsAppAsync(message.PhoneNumber, message.Message, message.Ddd))
            {
                sent++;
            }
        }

        _logger.LogInformation("Enviados {Sent} de {Total} mensagens WhatsApp", sent, messages.Count);
        return sent;
    }
}
