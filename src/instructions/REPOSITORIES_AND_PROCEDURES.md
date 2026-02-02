# ?? Repositórios e Procedures - Régua Disparo

## ?? Visão Geral

Esta documentação descreve os repositórios criados e procedures mapeadas para o sistema de Régua de Disparo, baseado na análise do projeto original.

---

## ??? Estrutura de Repositórios

### 1?? Repositórios Corporativos

**Localização**: `ReguaDisparo.Infrastructure/Repositories/Corporativo/`

#### OrganizacaoRepository

```csharp
public interface IOrganizacaoRepository
{
    Task<List<TB_CMCORP_ORGANIZACAO>> GetOrganizacoesAtivasComBancoCRMAsync();
    Task<TB_CMCORP_ORGANIZACAO?> GetOrganizacaoPorIdAsync(string organizacaoId);
    Task<TB_CMCORP_ORGANIZACAO?> GetOrganizacaoPorNomeBancoCRMAsync(string nomeBancoCRM);
}
```

**Uso**:
```csharp
public class MeuServico
{
    private readonly IOrganizacaoRepository _organizacaoRepo;

    public async Task ProcessarAsync()
    {
        // Buscar organizações ativas com CRM configurado
        var organizacoes = await _organizacaoRepo.GetOrganizacoesAtivasComBancoCRMAsync();
    }
}
```

---

### 2?? Repositórios ClienteMais (CRM)

**Localização**: `ReguaDisparo.Infrastructure/Repositories/ClienteMais/`

?? **IMPORTANTE**: Este repositório é multi-tenant e requer DbContext criado via Factory!

#### ReguaCobrancaCRMRepository

```csharp
public interface IReguaCobrancaCRMRepository
{
    // Propostas
    Task<List<TB_CMCRM_PROPOSTA>> GetPropostasVencidasAsync(DateTime dataReferencia);
    Task<List<TB_CMCRM_PROPOSTA>> GetPropostasParaCobrancaAsync(int diasAposVencimento);
    Task<TB_CMCRM_PROPOSTA?> GetPropostaPorIdAsync(int idProposta);
    
    // Casos
    Task<List<TB_CMCRM_CASO>> GetCasosCobrancaAtivosAsync();
    
    // Pessoas
    Task<TB_CMCRM_PESSOA?> GetPessoaPorIdAsync(int idPessoa);
    
    // Parcelas
    Task<List<TB_CMCRM_CONTRATO_PARCELA>> GetParcelasVencidasPorContratoAsync(
        int idContrato, 
        DateTime dataReferencia);
}
```

**Uso** (Multi-Tenant):
```csharp
public class ReguaCobrancaService
{
    private readonly ITenantDbContextFactory _tenantFactory;

    public async Task ProcessarAsync(string organizationId)
    {
        // 1. Criar DbContext para a organização
        using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);
        
        // 2. Criar repositório manualmente
        var repo = new ReguaCobrancaCRMRepository(
            crmDb,
            _logger);
        
        // 3. Usar repositório
        var propostas = await repo.GetPropostasVencidasAsync(DateTime.Now);
    }
}
```

---

## ??? Procedures Mapeadas

### 1?? Procedures Corporativas

**Localização**: `ReguaDisparo.Infrastructure/Data/Generated/Corporativo/Procedures/`

#### SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS

Retorna todas as organizações ativas com banco CRM configurado.

```csharp
var resultado = await _corporativoDb.SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS();

// Resultado:
// List<SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS_Result>
// - ID_ORGANIZACAO
// - DS_NOME_FANTASIA
// - DS_RAZAO_SOCIAL
// - NOME_BANCO_CRM
// - FL_ATIVO
// - COD_ERP_INTEGRACAO
```

#### SP_CMCORP_ORGANIZACAO_BUSCAR_POR_ID

Busca organização por ID.

```csharp
var resultado = await _corporativoDb.SP_CMCORP_ORGANIZACAO_BUSCAR_POR_ID("ORG123");

// Resultado:
// SP_CMCORP_ORGANIZACAO_BUSCAR_POR_ID_Result?
// - Todos os campos da organização
// - DS_URL_WEBSERVICE
// - DS_TOKEN
```

#### SP_CMCORP_ETL_LOG_INSERIR

Insere log de ETL.

```csharp
await _corporativoDb.SP_CMCORP_ETL_LOG_INSERIR(
    idEtl: 1,
    idOrganizacao: "ORG123",
    descricao: "Processamento concluído",
    tipo: "INFO",
    dataExecucao: DateTime.Now);
```

---

### 2?? Procedures Controle Acesso

**Localização**: `ReguaDisparo.Infrastructure/Data/Generated/ControleAcesso/Procedures/`

#### SP_CMC_USUARIO_VALIDAR_LOGIN

Valida login e senha do usuário.

```csharp
var resultado = await _controleAcessoDb.SP_CMC_USUARIO_VALIDAR_LOGIN(
    login: "usuario@email.com",
    senha: "senha_hash");

// Resultado:
// SP_CMC_USUARIO_VALIDAR_LOGIN_Result?
// - ID_USUARIO
// - DS_LOGIN
// - DS_NOME
// - DS_EMAIL
// - FL_ATIVO
// - FL_ADMINISTRADOR
// - ID_ORGANIZACAO
```

#### SP_CMC_USUARIO_LISTAR_POR_ORGANIZACAO

Lista usuários de uma organização.

```csharp
var usuarios = await _controleAcessoDb.SP_CMC_USUARIO_LISTAR_POR_ORGANIZACAO("ORG123");

// Resultado:
// List<SP_CMC_USUARIO_LISTAR_POR_ORGANIZACAO_Result>
```

#### SP_CMC_GRUPO_LISTAR_POR_SISTEMA

Lista grupos de um sistema.

```csharp
var grupos = await _controleAcessoDb.SP_CMC_GRUPO_LISTAR_POR_SISTEMA(idSistema: 1);
```

---

### 3?? Procedures ClienteMais (CRM)

**Localização**: `ReguaDisparo.Infrastructure/Data/Generated/ClienteMais/Procedures/`

?? **Multi-Tenant**: Usar via Factory!

#### SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS

Busca propostas vencidas para cobrança.

```csharp
using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

var propostas = await crmDb.SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS(
    dataReferencia: DateTime.Now,
    diasAposVencimento: 30);

// Resultado:
// List<SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS_Result>
// - ID_PROPOSTA
// - ID_PESSOA
// - DS_NOME_PESSOA
// - DS_EMAIL
// - NR_TELEFONE
// - DT_VENCIMENTO
// - VL_PROPOSTA
// - VL_SALDO
// - NR_DIAS_VENCIDO
// - FL_PAGO
```

#### SP_CMCRM_CASO_REGUA_COBRANCA_BUSCAR_DADOS

Busca dados completos para processamento da régua de cobrança.

```csharp
var dados = await crmDb.SP_CMCRM_CASO_REGUA_COBRANCA_BUSCAR_DADOS(
    idTipoAcao: 1,
    diasAposVencimento: 30,
    dataReferencia: DateTime.Now);

// Resultado:
// List<SP_CMCRM_CASO_REGUA_COBRANCA_BUSCAR_DADOS_Result>
// - ID_CASO
// - ID_PROPOSTA
// - ID_CONTRATO
// - ID_PESSOA
// - DS_NOME_PESSOA
// - DS_EMAIL
// - NR_TELEFONE
// - COD_DDD
// - DT_VENCIMENTO
// - VL_TOTAL
// - VL_PAGO
// - VL_SALDO
// - NR_DIAS_VENCIDO
// - DS_PRODUTO
// - DS_EMPREENDIMENTO
// - NR_QUADRA
// - NR_LOTE
```

#### SP_CMCRM_CONTRATO_PARCELA_LISTAR_VENCIDAS

Lista parcelas vencidas de um contrato.

```csharp
var parcelas = await crmDb.SP_CMCRM_CONTRATO_PARCELA_LISTAR_VENCIDAS(
    idContrato: 123,
    dataReferencia: DateTime.Now);

// Resultado:
// List<SP_CMCRM_CONTRATO_PARCELA_LISTAR_VENCIDAS_Result>
// - ID_CONTRATO_PARCELA
// - NR_PARCELA
// - DT_VENCIMENTO
// - VL_PARCELA
// - VL_PAGO
// - VL_SALDO
// - FL_PAGO
// - NR_DIAS_VENCIDO
```

#### SP_CMCRM_PESSOA_BUSCAR_CONTATOS

Busca todos os contatos de uma pessoa (emails, telefones).

```csharp
var contatos = await crmDb.SP_CMCRM_PESSOA_BUSCAR_CONTATOS(idPessoa: 456);

// Resultado:
// SP_CMCRM_PESSOA_BUSCAR_CONTATOS_Result?
// - ID_PESSOA
// - DS_NOME
// - DS_EMAIL
// - DS_EMAIL_SECUNDARIO
// - NR_TELEFONE
// - NR_CELULAR
// - COD_DDD
```

#### SP_CMCRM_HISTORICO_ENVIO_INSERIR

Registra envio de cobrança no histórico.

```csharp
await crmDb.SP_CMCRM_HISTORICO_ENVIO_INSERIR(
    idProposta: 123,
    idAcao: 1,
    tipoEnvio: "EMAIL",
    destinatarioEmail: "cliente@email.com",
    destinatarioTelefone: "11999999999",
    mensagem: "Conteúdo do email enviado",
    enviado: true,
    mensagemErro: null);
```

---

## ?? Exemplos de Uso Completos

### Exemplo 1: Processar Régua de Cobrança

```csharp
public class ReguaCobrancaService
{
    private readonly CorporativoDbContext _corporativoDb;
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILogger<ReguaCobrancaService> _logger;

    public async Task ProcessarReguaParaTodasOrganizacoesAsync()
    {
        // 1. Buscar organizações ativas
        var organizacoes = await _corporativoDb.SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS();

        foreach (var org in organizacoes)
        {
            _logger.LogInformation("Processando organização {Org}", org.DS_NOME_FANTASIA);

            try
            {
                // 2. Criar DbContext do CRM da organização
                using var crmDb = await _tenantFactory.CreateDbContextAsync(org.ID_ORGANIZACAO);

                // 3. Buscar propostas vencidas (30 dias)
                var propostas = await crmDb.SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS(
                    dataReferencia: DateTime.Now,
                    diasAposVencimento: 30);

                _logger.LogInformation("Encontradas {Count} propostas vencidas", propostas.Count);

                // 4. Processar cada proposta
                foreach (var proposta in propostas)
                {
                    // Buscar contatos da pessoa
                    var contatos = await crmDb.SP_CMCRM_PESSOA_BUSCAR_CONTATOS(
                        proposta.ID_PESSOA ?? 0);

                    if (contatos != null)
                    {
                        // Enviar email/SMS
                        await EnviarCobrancaAsync(proposta, contatos);

                        // Registrar histórico
                        await crmDb.SP_CMCRM_HISTORICO_ENVIO_INSERIR(
                            idProposta: proposta.ID_PROPOSTA,
                            idAcao: 1,
                            tipoEnvio: "EMAIL",
                            destinatarioEmail: contatos.DS_EMAIL ?? "",
                            destinatarioTelefone: contatos.NR_CELULAR,
                            mensagem: "Email de cobrança enviado",
                            enviado: true,
                            mensagemErro: null);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar organização {OrgId}", 
                    org.ID_ORGANIZACAO);
            }
        }
    }
}
```

### Exemplo 2: Buscar Dados Completos para Régua

```csharp
public async Task<List<DadosReguaDTO>> BuscarDadosParaReguaAsync(
    string organizationId,
    int diasAposVencimento)
{
    using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

    // Buscar dados completos com JOIN de todas as tabelas necessárias
    var dados = await crmDb.SP_CMCRM_CASO_REGUA_COBRANCA_BUSCAR_DADOS(
        idTipoAcao: 1,
        diasAposVencimento: diasAposVencimento,
        dataReferencia: DateTime.Now);

    return dados.Select(d => new DadosReguaDTO
    {
        Caso = d.ID_CASO,
        Proposta = d.ID_PROPOSTA,
        Cliente = d.DS_NOME_PESSOA,
        Email = d.DS_EMAIL,
        Telefone = d.NR_TELEFONE,
        ValorTotal = d.VL_TOTAL ?? 0,
        ValorPago = d.VL_PAGO ?? 0,
        Saldo = d.VL_SALDO ?? 0,
        DiasVencido = d.NR_DIAS_VENCIDO ?? 0,
        Produto = d.DS_PRODUTO,
        Empreendimento = d.DS_EMPREENDIMENTO
    }).ToList();
}
```

---

## ?? Próximos Passos

### Para Implementar:

1. **Corrigir compilação dos repositórios ClienteMais**
   - Verificar nomes exatos das propriedades nas entidades TB_CMCRM_*
   - Ajustar navegações (TB_CMCRM_PROPOSTum vs TB_CMCRM_PROPOSTA)

2. **Criar procedures SQL no banco**
   - As procedures mapeadas precisam existir no banco de dados
   - Ver scripts SQL em: `scripts/sql/`

3. **Adicionar mais repositories conforme necessário**
   - ContratoRepository
   - PessoaRepository
   - CasoRepository

4. **Registrar no DI corretamente**
   - Ajustar InfrastructureModule.cs
   - Corrigir namespaces

---

## ?? Documentação Relacionada

- ?? [MULTITENANT_GUIDE.md](MULTITENANT_GUIDE.md) - Como usar multi-tenant
- ?? [MULTIPLE_DBCONTEXTS.md](MULTIPLE_DBCONTEXTS.md) - Múltiplos contextos
- ?? [DATABASE_NAMING_CONVENTION.md](DATABASE_NAMING_CONVENTION.md) - Nomenclatura

---

**Status**: ?? Em Desenvolvimento  
**Versão**: 0.9  
**Próximo Passo**: Corrigir compilação e criar procedures SQL
