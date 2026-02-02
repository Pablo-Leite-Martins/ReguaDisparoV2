# ?? Guia Multi-Tenant - ReguaDisparo

## ?? Visão Geral

O ReguaDisparo implementa uma arquitetura **multi-tenant** onde cada organização/cliente possui seu próprio banco de dados CRM. O sistema acessa dinamicamente o banco correto baseado na configuração da organização.

---

## ?? Arquitetura de Acesso aos Bancos

### 1?? **CorporativoDbContext** (Fixo)
- **Base**: `CLIENTEMAIS_CORPORATIVO`  
- **Objetivo**: Gerenciar organizações, configurações globais, ETL, etc.
- **Acesso**: Connection string fixa
- **Uso**: Ler `TB_CMCORP_ORGANIZACAO` para obter `NOME_BANCO_CRM`

### 2?? **ControleAcessoDbContext** (Fixo)
- **Base**: `CLIENTEMAIS_CONTROLE_ACESSO`
- **Objetivo**: Gerenciar usuários, permissões, grupos, etc.
- **Acesso**: Connection string fixa
- **Uso**: Autenticação, autorização, perfis

### 3?? **ClienteMaisDbContext** (Dinâmico - Multi-Tenant)
- **Base**: Dinâmica baseada em `TB_CMCORP_ORGANIZACAO.NOME_BANCO_CRM`
- **Objetivo**: Acessar dados CRM específicos do cliente (casos, propostas, contratos, etc.)
- **Acesso**: Via `ITenantDbContextFactory`
- **Uso**: Operações de régua de cobrança, processos de negócio do cliente

---

## ?? Configuração

### Connection Strings (appsettings.json)

```json
{
  "ConnectionStrings": {
    "ControleAcessoConnection": "...;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;...",
    "CorporativoConnection": "...;Initial Catalog=CLIENTEMAIS_CORPORATIVO;...",
    "ClienteMaisConnection": "...;(SEM Initial Catalog - será interpolado dinamicamente)..."
  }
}
```

**?? Importante**: A `ClienteMaisConnection` **NÃO** deve ter `Initial Catalog` fixo, pois será substituído dinamicamente.

---

## ?? Como Funciona

### Fluxo de Acesso ao Banco do Cliente

```
1. Serviço recebe organizationId
   ?
2. Injeta ITenantDbContextFactory
   ?
3. Factory consulta TB_CMCORP_ORGANIZACAO usando CorporativoDbContext
   ?
4. Obtém campo NOME_BANCO_CRM
   ?
5. Interpola NOME_BANCO_CRM na connection string template
   ?
6. Cria ClienteMaisDbContext com a connection string específica
   ?
7. Retorna DbContext pronto para usar
```

---

## ?? Exemplos de Uso

### Exemplo 1: Usar Factory para Acessar Banco do Cliente

```csharp
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Data.Generated.ClienteMais;

public class ReguaCobrancaService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILogger<ReguaCobrancaService> _logger;

    public ReguaCobrancaService(
        ITenantDbContextFactory tenantFactory,
        ILogger<ReguaCobrancaService> logger)
    {
        _tenantFactory = tenantFactory;
        _logger = logger;
    }

    public async Task ProcessarReguaAsync(string organizationId)
    {
        _logger.LogInformation("Processando régua para organização {OrganizationId}", organizationId);

        // Criar DbContext específico para a organização
        using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

        // Agora você tem acesso ao banco CRM da organização
        var casos = await crmDb.TB_CMCRM_CASOs
            .Where(c => c.FL_ATIVO == true && c.ID_TIPO_CASO == 1)
            .ToListAsync();

        foreach (var caso in casos)
        {
            // Processar caso
            _logger.LogDebug("Processando caso {CasoId}", caso.ID_CASO);
        }
    }
}
```

### Exemplo 2: Usar Banco Específico Diretamente

```csharp
public async Task ProcessarClienteEspecificoAsync()
{
    // Se você já sabe o nome do banco
    using var crmDb = _tenantFactory.CreateDbContextByDatabaseName("CLIENTEMAIS_CRM_EMCCAMP_HMG");

    var propostas = await crmDb.TB_CMCRM_PROPOSTAs
        .Where(p => p.DT_VENCIMENTO < DateTime.Now)
        .ToListAsync();

    // Processar propostas vencidas
}
```

### Exemplo 3: Combinar Múltiplos Contextos

```csharp
using ReguaDisparo.Infrastructure.Data.Generated.Corporativo;
using ReguaDisparo.Infrastructure.Data.Generated.ControleAcesso;
using ReguaDisparo.Infrastructure.Data.Factories;

public class IntegracaoComplexaService
{
    private readonly CorporativoDbContext _corporativoDb;
    private readonly ControleAcessoDbContext _controleAcessoDb;
    private readonly ITenantDbContextFactory _tenantFactory;

    public IntegracaoComplexaService(
        CorporativoDbContext corporativoDb,
        ControleAcessoDbContext controleAcessoDb,
        ITenantDbContextFactory tenantFactory)
    {
        _corporativoDb = corporativoDb;
        _controleAcessoDb = controleAcessoDb;
        _tenantFactory = tenantFactory;
    }

    public async Task ProcessarTodasOrganizacoesAsync()
    {
        // 1. Buscar organizações ativas
        var organizacoes = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
            .Where(o => o.FL_ATIVO == true && !string.IsNullOrEmpty(o.NOME_BANCO_CRM))
            .ToListAsync();

        foreach (var org in organizacoes)
        {
            // 2. Buscar usuários da organização
            var usuarios = await _controleAcessoDb.TB_CMC_USUARIOs
                .Where(u => u.ID_ORGANIZACAO == org.ID_ORGANIZACAO && u.FL_ATIVO == true)
                .ToListAsync();

            // 3. Acessar banco CRM da organização
            using var crmDb = await _tenantFactory.CreateDbContextAsync(org.ID_ORGANIZACAO);

            // 4. Processar dados do CRM
            var casos = await crmDb.TB_CMCRM_CASOs
                .Where(c => c.FL_ATIVO == true)
                .ToListAsync();

            // Processar...
        }
    }
}
```

---

## ??? Implementação da Factory

### Interface

```csharp
public interface ITenantDbContextFactory
{
    /// <summary>
    /// Cria ClienteMaisDbContext baseado na organização
    /// </summary>
    Task<ClienteMaisDbContext> CreateDbContextAsync(string organizationId);

    /// <summary>
    /// Cria ClienteMaisDbContext usando nome do banco diretamente
    /// </summary>
    ClienteMaisDbContext CreateDbContextByDatabaseName(string databaseName);
}
```

### Implementação

```csharp
public class TenantDbContextFactory : ITenantDbContextFactory
{
    private readonly CorporativoDbContext _corporativoDb;
    private readonly IConfiguration _configuration;
    private readonly ILogger<TenantDbContextFactory> _logger;

    public async Task<ClienteMaisDbContext> CreateDbContextAsync(string organizationId)
    {
        // 1. Buscar organização
        var organizacao = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
            .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == organizationId);

        // 2. Validar
        if (organizacao?.NOME_BANCO_CRM == null)
            throw new InvalidOperationException($"Organização '{organizationId}' sem banco CRM");

        // 3. Criar DbContext com banco específico
        return CreateDbContextByDatabaseName(organizacao.NOME_BANCO_CRM);
    }

    public ClienteMaisDbContext CreateDbContextByDatabaseName(string databaseName)
    {
        // Obter template de connection string
        var connectionStringTemplate = _configuration.GetConnectionString("ClienteMaisConnection");
        
        // Interpolar nome do banco
        var connectionString = ReplaceInitialCatalog(connectionStringTemplate, databaseName);

        // Criar DbContext
        var optionsBuilder = new DbContextOptionsBuilder<ClienteMaisDbContext>();
        optionsBuilder.UseSqlServer(connectionString, /* ... */);

        return new ClienteMaisDbContext(optionsBuilder.Options);
    }
}
```

---

## ?? Importante: Gerenciamento de Ciclo de Vida

### ? NÃO FAÇA ISSO

```csharp
// ? ERRADO - Vazamento de memória!
public class MeuServico
{
    private ClienteMaisDbContext _crmDb; // ? NÃO armazenar como campo

    public async Task ProcessarAsync(string orgId)
    {
        _crmDb = await _tenantFactory.CreateDbContextAsync(orgId);
        // ... usar
        // ? FALTOU DISPOSE!
    }
}
```

### ? FAÇA ISSO

```csharp
// ? CORRETO - Usar using
public async Task ProcessarAsync(string orgId)
{
    using var crmDb = await _tenantFactory.CreateDbContextAsync(orgId);
    
    // Usar o DbContext
    var casos = await crmDb.TB_CMCRM_CASOs.ToListAsync();
    
    // Dispose automático ao sair do escopo
}
```

---

## ?? Casos de Uso

### Caso 1: Processar Régua de Cobrança para Organização

```csharp
public async Task ProcessarReguaCobrancaAsync(string organizationId)
{
    using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

    // Buscar propostas vencidas
    var propostasVencidas = await crmDb.TB_CMCRM_PROPOSTAs
        .Where(p => p.DT_VENCIMENTO < DateTime.Now && p.FL_PAGO == false)
        .Include(p => p.TB_CMCRM_CASO)
        .ToListAsync();

    // Processar régua
    foreach (var proposta in propostasVencidas)
    {
        await EnviarNotificacaoCobrancaAsync(proposta);
    }
}
```

### Caso 2: Iterar Todas as Organizações

```csharp
public async Task ProcessarTodasOrganizacoesAsync()
{
    // Buscar organizações ativas
    var organizacoes = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
        .Where(o => o.FL_ATIVO == true && !string.IsNullOrEmpty(o.NOME_BANCO_CRM))
        .ToListAsync();

    foreach (var org in organizacoes)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(org.ID_ORGANIZACAO);
            
            // Processar dados da organização
            await ProcessarOrganizacaoAsync(crmDb, org);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar organização {OrgId}", org.ID_ORGANIZACAO);
            // Continuar para próxima organização
        }
    }
}
```

---

## ?? Troubleshooting

### Problema: "Organização não encontrada"

**Erro:**
```
InvalidOperationException: Organização 'ORG123' não encontrada
```

**Solução:**
- Verificar se `ID_ORGANIZACAO` está correto
- Verificar se organização existe em `TB_CMCORP_ORGANIZACAO`

### Problema: "Organização sem banco CRM configurado"

**Erro:**
```
InvalidOperationException: Organização 'ORG123' não possui banco CRM configurado
```

**Solução:**
- Verificar se `NOME_BANCO_CRM` está preenchido em `TB_CMCORP_ORGANIZACAO`
- Atualizar registro da organização com nome do banco correto

### Problema: "Connection string não configurada"

**Erro:**
```
InvalidOperationException: Connection string 'ClienteMaisConnection' não configurada
```

**Solução:**
Adicionar ao appsettings.json:
```json
{
  "ConnectionStrings": {
    "ClienteMaisConnection": "Data Source=...;User ID=...;Password=...;"
  }
}
```

---

## ?? Tabela de Referência

| DbContext | Base | Tipo | Uso |
|-----------|------|------|-----|
| **CorporativoDbContext** | CLIENTEMAIS_CORPORATIVO | Fixo | Organizações, configurações globais |
| **ControleAcessoDbContext** | CLIENTEMAIS_CONTROLE_ACESSO | Fixo | Usuários, permissões, autenticação |
| **ClienteMaisDbContext** | Dinâmico (NOME_BANCO_CRM) | Multi-tenant | Dados CRM do cliente |

---

## ? Checklist de Implementação

### Ao Usar Multi-Tenant

- [ ] Injetar `ITenantDbContextFactory` no serviço
- [ ] Usar `using` para criar DbContext
- [ ] Tratar exceções (organização não encontrada, etc.)
- [ ] Fazer dispose do DbContext após uso
- [ ] Logar qual organização está sendo processada
- [ ] Validar que NOME_BANCO_CRM não é nulo/vazio

### Ao Configurar Nova Organização

- [ ] Inserir registro em `TB_CMCORP_ORGANIZACAO`
- [ ] Preencher campo `NOME_BANCO_CRM` com nome correto do banco
- [ ] Verificar que banco CRM existe no servidor
- [ ] Testar acesso ao banco via Factory

---

## ?? Referências

- ?? [MULTIPLE_DBCONTEXTS.md](MULTIPLE_DBCONTEXTS.md) - Guia de múltiplos contextos
- ?? [EF_CORE_GUIDE.md](EF_CORE_GUIDE.md) - Guia do Entity Framework Core

---

**Versão**: 1.0  
**Data**: 2024  
**Status**: ? Multi-Tenant Implementado
