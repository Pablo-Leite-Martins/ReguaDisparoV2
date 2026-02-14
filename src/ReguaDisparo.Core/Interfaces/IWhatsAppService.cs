namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para envio de mensagens WhatsApp
/// </summary>
public interface IWhatsAppService
{
    /// <summary>
    /// Envia uma mensagem WhatsApp
    /// </summary>
    Task<bool> SendWhatsAppAsync(string phoneNumber, string message, string? ddd = null);

    /// <summary>
    /// Envia múltiplas mensagens WhatsApp
    /// </summary>
    Task<int> SendBulkWhatsAppAsync(List<WhatsAppMessage> messages);
}

public class WhatsAppMessage
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Ddd { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}
