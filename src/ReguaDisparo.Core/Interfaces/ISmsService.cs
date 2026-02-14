namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para envio de SMS
/// </summary>
public interface ISmsService
{
    /// <summary>
    /// Envia um SMS
    /// </summary>
    Task<bool> SendSmsAsync(string phoneNumber, string message, string? ddd = null);

    /// <summary>
    /// Envia múltiplos SMS
    /// </summary>
    Task<int> SendBulkSmsAsync(List<SmsMessage> messages);
}

public class SmsMessage
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Ddd { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, string> Metadata { get; set; } = new();
}
