# Serviço de Integração UAU

## Visão Geral

O serviço `UauIntegracaoService` é responsável por verificar se o processo **PRO_UAU** foi executado para organizações que utilizam o ERP UAU.

## Propósito

Baseado no projeto original (CAPYS_ReguaDisparo_Model), antes de processar as réguas de cobrança para organizações com ERP UAU, é necessário verificar se o processo PRO_UAU foi executado. Esta verificação garante que os dados estão sincronizados e prontos para o processamento.

## Funcionamento

### Fluxo de Verificação

1. **Verificação no ReguaCobrancaService**: 
   - Apenas organizações com `COD_ERP_INTEGRACAO = "UAU"` passam pela verificação
   - Se a organização não for UAU, a verificação é ignorada

2. **Chamada ao Webservice**:
   - Utiliza a URL configurada em `TB_CMCORP_ORGANIZACAO.DS_URL_WEBSERVICE_CAPYS`
   - Endpoint: `/api/ProUau/VerificaExecucao`
   - Método: GET
   - Timeout: 30 segundos

3. **Tratamento de Resposta**:
   - Sucesso (200): Parseia JSON procurando por `executado` ou `success`
   - Não encontrado (404): Considera como executado (não bloqueia)
   - Erro/Timeout: Considera como executado (não bloqueia) e loga erro

### Estrutura de Resposta Esperada

O webservice pode retornar:

```json
{
  "executado": true
}
```

ou

```json
{
  "success": true
}
```

## Implementação no Código Original

No projeto antigo (`temp_parte1.txt`), a lógica era:

```csharp
bool flProUauExecutado = true;
if (organizacao.COD_ERP_INTEGRACAO == Enumeration.TipoERP.UAU.ToDescriptionString())
{
    flProUauExecutado = false;
    flProUauExecutado = ServicosCapys.VerificaProUauExecutou(
        organizacao.DS_URL_WEBSERVICE_CAPYS, 
        new CookieContainer()
    );
}

if (flProUauExecutado)
{
    // Processa réguas de cobrança
}
else
{
    _logErro.Add($"PROUAU NA ORGANIZAÇÃO: {organizacao.DS_NOME_FANTASIA} NÃO EXECUTOU");
}
```

## Uso

### Injeção de Dependência

O serviço é registrado no IoC:

```csharp
services.AddScoped<IUauIntegracaoService, UauIntegracaoService>();
```

### Exemplo de Uso

```csharp
public class ReguaCobrancaService
{
    private readonly IUauIntegracaoService _uauIntegracaoService;
    
    public async Task ExecutarReguaCobrancaOrganizacaoAsync(TB_CMCORP_ORGANIZACAO organizacao)
    {
        // Verifica apenas se for ERP UAU
        if (organizacao.COD_ERP_INTEGRACAO?.Equals("UAU", StringComparison.OrdinalIgnoreCase) == true)
        {
            bool executado = await _uauIntegracaoService.VerificaProUauExecutouAsync(
                organizacao.DS_URL_WEBSERVICE_CAPYS
            );
            
            if (!executado)
            {
                _logger.LogWarning("PRO_UAU não executado para {Organizacao}", organizacao.DS_NOME_FANTASIA);
                return; // Não processa réguas
            }
        }
        
        // Continua processamento...
    }
}
```

## Tratamento de Erros

### Estratégia: Fail-Safe

O serviço adota uma abordagem **fail-safe**:
- Em caso de erro de comunicação: **não bloqueia** a execução
- Em caso de timeout: **não bloqueia** a execução
- Em caso de endpoint não encontrado: **não bloqueia** a execução

**Motivo**: Evitar que problemas temporários de rede ou configuração impeçam o processamento das réguas.

### Logs

- **Debug**: Início da verificação com URL
- **Warning**: URL não configurada, endpoint não encontrado
- **Error**: Falhas de comunicação, timeout, erros inesperados
- **Information**: Verificação bem-sucedida

## Configuração

### Pré-requisitos

1. Organização deve ter `COD_ERP_INTEGRACAO = "UAU"`
2. Campo `DS_URL_WEBSERVICE_CAPYS` deve estar preenchido
3. Webservice CAPYS deve estar acessível e responder no endpoint esperado

### Ajustes Necessários

Se o endpoint do webservice for diferente, ajuste a URL em `UauIntegracaoService.cs`:

```csharp
var urlVerificacao = $"{urlWebserviceCapys.TrimEnd('/')}/api/ProUau/VerificaExecucao";
```

## Considerações de Performance

- **Timeout**: 30 segundos (configurável)
- **Overhead**: Adiciona ~1-2 segundos por organização UAU (em condições normais)
- **Concorrência**: Pode processar múltiplas organizações em paralelo
- **Cache**: Não implementado (cada execução faz nova verificação)

## Próximas Melhorias

1. **Cache**: Implementar cache de 5-10 minutos para evitar chamadas repetidas
2. **Retry**: Adicionar política de retry com backoff exponencial
3. **Circuit Breaker**: Implementar para lidar com falhas persistentes
4. **Métricas**: Adicionar telemetria para monitoramento
5. **Configuração**: Externalizar timeout e endpoint via configuração
