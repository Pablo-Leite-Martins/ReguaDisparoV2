using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces.UAU;
using System.Net;
using System.Text.Json;

namespace ReguaDisparo.Core.Services.UAU;

/// <summary>
/// Serviço para integração com UAU
/// Baseado em ServicosCapys.VerificaProUauExecutou do projeto original
/// </summary>
public class UauIntegracaoService : IUauIntegracaoService
{
    private readonly ILogger<UauIntegracaoService> _logger;

    public UauIntegracaoService(ILogger<UauIntegracaoService> logger)
    {
        _logger = logger;
    }

    public async Task<bool> VerificaProUauExecutouAsync(string urlWebserviceCapys)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(urlWebserviceCapys))
            {
                _logger.LogWarning("URL do webservice CAPYS não informada");
                return true; // Retorna true para não bloquear a execução
            }

            _logger.LogDebug("Verificando execução do PRO_UAU via webservice: {Url}", urlWebserviceCapys);

            // Monta a URL para verificar o PRO_UAU
            // O endpoint específico pode variar, ajuste conforme necessário
            var urlVerificacao = $"{urlWebserviceCapys.TrimEnd('/')}/api/ProUau/VerificaExecucao";

            var cookieContainer = new CookieContainer();
            using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
            using var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(130) };

            var response = await client.GetAsync(urlVerificacao);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                // Tenta parsear a resposta como JSON
                try
                {
                    var jsonDoc = JsonDocument.Parse(content);
                    
                    // Verifica se há uma propriedade indicando execução
                    if (jsonDoc.RootElement.TryGetProperty("executado", out var executadoElement))
                    {
                        var executado = executadoElement.GetBoolean();
                        _logger.LogDebug("PRO_UAU {Status}", executado ? "foi executado" : "não foi executado");
                        return executado;
                    }
                    
                    // Se não tiver a propriedade específica, tenta verificar por outras formas
                    if (jsonDoc.RootElement.TryGetProperty("success", out var successElement))
                    {
                        var success = successElement.GetBoolean();
                        _logger.LogDebug("Resposta de sucesso: {Success}", success);
                        return success;
                    }
                }
                catch (JsonException)
                {
                    // Se não for JSON, trata como texto simples
                    if (content.Contains("true", StringComparison.OrdinalIgnoreCase) ||
                        content.Contains("executado", StringComparison.OrdinalIgnoreCase) ||
                        content.Contains("success", StringComparison.OrdinalIgnoreCase))
                    {
                        _logger.LogDebug("PRO_UAU foi executado (resposta texto)");
                        return true;
                    }
                }

                // Se chegou aqui e teve sucesso, considera como executado
                _logger.LogInformation("PRO_UAU verificado com sucesso via webservice");
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // Endpoint não existe - pode ser que a organização não use UAU
                _logger.LogWarning("Endpoint de verificação PRO_UAU não encontrado. URL: {Url}", urlVerificacao);
                return true; // Não bloqueia execução
            }
            else
            {
                _logger.LogWarning("Erro ao verificar PRO_UAU. Status: {StatusCode}", response.StatusCode);
                return true; // Em caso de erro, não bloqueia a execução
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro de comunicação ao verificar PRO_UAU via webservice: {Url}", urlWebserviceCapys);
            return true; // Em caso de erro de comunicação, não bloqueia
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "Timeout ao verificar PRO_UAU via webservice: {Url}", urlWebserviceCapys);
            return true; // Em caso de timeout, não bloqueia
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado ao verificar PRO_UAU: {Url}", urlWebserviceCapys);
            return true; // Em caso de erro, não bloqueia a execução
        }
    }
}
