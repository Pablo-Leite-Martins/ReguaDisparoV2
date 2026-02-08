using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReguaDisparo.Core.Constants;
using ReguaDisparo.Core.Enums;
using ReguaDisparo.Core.Exceptions;
using ReguaDisparo.Core.Interfaces.UAU;
using System.Data;
using System.Net;
using System.Security;
using System.Text;
using System.Xml;

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
                return false;
            }

            _logger.LogDebug("Verificando execução do PRO_UAU via webservice SOAP: {Url}", urlWebserviceCapys);

            // Consulta SQL para verificar se o PRO_UAU foi executado
            var sql = ConsultaUAUConsts.VERIFICA_EXECUCAO_PROUAU;

            var resultado = await RetornaConsultaUAUAsync<DataTable>(urlWebserviceCapys, sql);

            if (resultado != null && resultado.Rows.Count > 0)
            {
                _logger.LogDebug("PRO_UAU foi executado com sucesso");
                return true;
            }

            _logger.LogWarning("PRO_UAU não retornou dados");
            return false;
        }
        catch (IntegracaoUAUException ex)
        {
            _logger.LogError(ex, "Erro de integração ao verificar PRO_UAU: {Detalhes}", ex.DetalhesTecnicos);
            return false; 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado ao verificar PRO_UAU: {Url}", urlWebserviceCapys);
            return false;
        }
    }

    /// <summary>
    /// Retorna consulta do webservice UAU usando SOAP
    /// </summary>
    private async Task<T> RetornaConsultaUAUAsync<T>(string webServiceAsmxUrl, string sql)
    {
        try
        {
            string soapAction = "http://tempuri.org/RetornaConsulta";
            string encodedSql = SecurityElement.Escape(sql);
            string soapXml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <RetornaConsulta xmlns=""http://tempuri.org/"">
                      <consulta>{encodedSql}</consulta>
                    </RetornaConsulta>
                  </soap:Body>
                </soap:Envelope>";

            return await RetornaConsultaWebServiceAsync<T>(webServiceAsmxUrl, soapAction, soapXml);
        }
        catch (IntegracaoUAUException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new IntegracaoUAUException(
                webServiceAsmxUrl,
                "Erro ao montar requisição SOAP para UAU",
                $"Erro no método RetornaConsultaUAU: {ex.Message}",
                "http://tempuri.org/RetornaConsulta",
                ETipoAPI.SOAP,
                ex);
        }
    }

    /// <summary>
    /// Executa a chamada ao webservice SOAP e processa a resposta
    /// </summary>
    private async Task<T> RetornaConsultaWebServiceAsync<T>(string webServiceAsmxUrl, string soapAction, string soapXml)
    {
        try
        {
            string url = webServiceAsmxUrl.TrimEnd('/') + "/Integracao_CAPYS.asmx?wsdl";
            
            var request = WebRequest.Create(url);
            byte[] buffer = Encoding.UTF8.GetBytes(soapXml);
            
            request.Timeout = 60000;
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.ContentLength = buffer.Length;
            request.Headers.Add("SOAPAction", soapAction);

            // Escreve o conteúdo SOAP na requisição
            using (var requestStream = await request.GetRequestStreamAsync())
            {
                await requestStream.WriteAsync(buffer, 0, buffer.Length);
            }

            // Obtém a resposta
            using var response = (HttpWebResponse)await request.GetResponseAsync();
            using var responseStream = response.GetResponseStream();
            using var reader = new StreamReader(responseStream, Encoding.UTF8);
            
            var data = await reader.ReadToEndAsync();

            // Processa o XML de resposta
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);
            
            var tables = xmlDoc.GetElementsByTagName("Table");
            var dataSet = new DataSet();

            foreach (XmlNode xmlNode in tables)
            {
                var ds = new DataSet();
                var nodeReader = new XmlNodeReader(xmlNode);
                ds.ReadXml(nodeReader);
                dataSet.Merge(ds);
            }

            if (dataSet.Tables.Count > 0)
            {
                // Se T for DataTable, retorna diretamente
                if (typeof(T) == typeof(DataTable))
                {
                    return (T)(object)dataSet.Tables[0];
                }
                
                // Caso contrário, serializa/deserializa para o tipo desejado
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dataSet.Tables[0]));
            }
            else
            {
                return default(T);
            }
        }
        catch (WebException ex)
        {
            var errorMessage = "Erro de comunicação com o webservice UAU";
            if (ex.Response != null)
            {
                using var errorResponse = ex.Response;
                using var errorStream = errorResponse.GetResponseStream();
                using var errorReader = new StreamReader(errorStream);
                var errorContent = await errorReader.ReadToEndAsync();
                errorMessage += $". Resposta: {errorContent}";
            }

            throw new IntegracaoUAUException(
                webServiceAsmxUrl,
                "Ops, aconteceu um problema com a comunicação com UAU",
                $"Ocorreu um erro no método de Retorna Consulta WebService: {errorMessage}",
                soapAction,
                ETipoAPI.SOAP,
                ex);
        }
        catch (Exception ex)
        {
            throw new IntegracaoUAUException(
                webServiceAsmxUrl,
                "Ops, aconteceu um problema com a comunicação com UAU",
                $"Ocorreu um erro no método de Retorna Consulta WebService: {ex.Message}",
                soapAction,
                ETipoAPI.SOAP,
                ex);
        }
    }
}
