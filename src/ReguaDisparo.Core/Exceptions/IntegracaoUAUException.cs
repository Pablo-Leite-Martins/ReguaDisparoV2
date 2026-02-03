using ReguaDisparo.Core.Enums;

namespace ReguaDisparo.Core.Exceptions;

/// <summary>
/// Exceção lançada quando há erro na integração com UAU
/// </summary>
public class IntegracaoUAUException : Exception
{
    /// <summary>
    /// URL do webservice
    /// </summary>
    public string WebServiceUrl { get; }
    
    /// <summary>
    /// Ação SOAP executada
    /// </summary>
    public string SoapAction { get; }
    
    /// <summary>
    /// Tipo de API (REST ou SOAP)
    /// </summary>
    public ETipoAPI TipoAPI { get; }
    
    /// <summary>
    /// Detalhes técnicos do erro
    /// </summary>
    public string DetalhesTecnicos { get; }

    public IntegracaoUAUException(
        string webServiceUrl, 
        string message, 
        string detalhesTecnicos, 
        string soapAction, 
        ETipoAPI tipoAPI) 
        : base(message)
    {
        WebServiceUrl = webServiceUrl;
        DetalhesTecnicos = detalhesTecnicos;
        SoapAction = soapAction;
        TipoAPI = tipoAPI;
    }

    public IntegracaoUAUException(
        string webServiceUrl, 
        string message, 
        string detalhesTecnicos, 
        string soapAction, 
        ETipoAPI tipoAPI,
        Exception innerException) 
        : base(message, innerException)
    {
        WebServiceUrl = webServiceUrl;
        DetalhesTecnicos = detalhesTecnicos;
        SoapAction = soapAction;
        TipoAPI = tipoAPI;
    }
}
