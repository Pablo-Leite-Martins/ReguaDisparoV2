# ??? Múltiplos DbContexts - ReguaDisparo

## ?? Visão Geral

O projeto ReguaDisparo utiliza **4 DbContexts** distintos para acessar diferentes bases de dados:

1. **ApplicationDbContext** - DbContext principal (usado pelos repositórios)
2. **ControleAcessoDbContext** - Base CLIENTEMAIS_CONTROLE_ACESSO (28 tabelas)
3. **CorporativoDbContext** - Base CLIENTEMAIS_CORPORATIVO (40 tabelas)
4. **ClienteMaisDbContext** - Base CRM do Cliente (514 tabelas) - Exemplo: CLIENTEMAIS_CRM_EMCCAMP_HMG

---

## ?? Estrutura de Arquivos

```
ReguaDisparo.Infrastructure/
??? Data/
    ??? ApplicationDbContext.cs                    # DbContext principal
    ??? Generated/
        ??? ControleAcesso/                        # Base CONTROLE_ACESSO
        ?   ??? ControleAcessoDbContext.cs         # DbContext
        ?   ??? TB_CMC_USUARIO.cs                  # 28 entidades
        ?   ??? ...
        ??? Corporativo/                           # Base CORPORATIVO
        ?   ??? CorporativoDbContext.cs            # DbContext
        ?   ??? TB_CMCORP_ORGANIZACAO.cs           # 40 entidades
        ?   ??? ...
        ??? ClienteMais/                           # Base CRM Cliente
            ??? ClienteMaisDbContext.cs            # DbContext
            ??? TB_CMCRM_CASO.cs                   # 514 entidades
            ??? ...
```

---

## ?? Configuração

### 1?? Connection Strings (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=...;Initial Catalog=...",
    "ControleAcessoConnection": "Data Source=...;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;...",
    "CorporativoConnection": "Data Source=...;Initial Catalog=CLIENTEMAIS_CORPORATIVO;...",
    "ClienteMaisConnection": "Data Source=...;Initial Catalog=CLIENTEMAIS_CRM_EMCCAMP_HMG;..."
  }
}
```

### 2?? Registro no DI (InfrastructureModule.cs)

```csharp
public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
{
    // ApplicationDbContext (Principal)
    services.AddDbContext<ApplicationDbContext>(options =>
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString, /* ... */);
    });

    // ControleAcessoDbContext (CONTROLE_ACESSO)
    services.AddDbContext<ControleAcessoDbContext>(options =>
    {
        var connectionString = configuration.GetConnectionString("ControleAcessoConnection");
        options.UseSqlServer(connectionString, /* ... */);
    });

    // CorporativoDbContext (CORPORATIVO)
    services.AddDbContext<CorporativoDbContext>(options =>
    {
        var connectionString = configuration.GetConnectionString("CorporativoConnection");
        options.UseSqlServer(connectionString, /* ... */);
    });

    // ClienteMaisDbContext (Base CRM do Cliente)
    services.AddDbContext<ClienteMaisDbContext>(options =>
    {
        var connectionString = configuration.GetConnectionString("ClienteMaisConnection");
        options.UseSqlServer(connectionString, /* ... */);
    });
}
```

---

## ?? Como Usar

### Exemplo 1: Injetar Específico

```csharp
using ReguaDisparo.Infrastructure.Data.Generated.ControleAcesso;
using ReguaDisparo.Infrastructure.Data.Generated.Corporativo;
using ReguaDisparo.Infrastructure.Data.Generated.ClienteMais;

public class MeuServico
{
    private readonly ControleAcessoDbContext _controleAcessoDb;
    private readonly CorporativoDbContext _corporativoDb;
    private readonly ClienteMaisDbContext _clienteMaisDb;

    public MeuServico(
        ControleAcessoDbContext controleAcessoDb,
        CorporativoDbContext corporativoDb,
        ClienteMaisDbContext clienteMaisDb)
    {
        _controleAcessoDb = controleAcessoDb;
        _corporativoDb = corporativoDb;
        _clienteMaisDb = clienteMaisDb;
    }

    public async Task ProcessarAsync()
    {
        // Buscar usuários do Controle Acesso
        var usuarios = await _controleAcessoDb.TB_CMC_USUARIOs
            .Where(u => u.FL_ATIVO == true)
            .ToListAsync();

        // Buscar organizações do Corporativo
        var organizacoes = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
            .Where(o => o.FL_ATIVO == true)
            .ToListAsync();

        // Buscar casos do CRM do cliente
        var casos = await _clienteMaisDb.TB_CMCRM_CASOs
            .Where(c => c.FL_ATIVO == true)
            .ToListAsync();
    }
}
```

### Exemplo 2: Repositório com Múltiplos Contextos

```csharp
using ReguaDisparo.Infrastructure.Data.Generated.ControleAcesso;
using ReguaDisparo.Infrastructure.Data.Generated.Corporativo;

public class UsuarioRepository
{
    private readonly ControleAcessoDbContext _db;
    private readonly ILogger<UsuarioRepository> _logger;

    public UsuarioRepository(
        ControleAcessoDbContext db,
        ILogger<UsuarioRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<List<TB_CMC_USUARIO>> GetUsuariosAtivosAsync()
    {
        return await _db.TB_CMC_USUARIOs
            .Where(u => u.FL_ATIVO == true)
            .ToListAsync();
    }
}
```

### Exemplo 3: Usar Ambos os Contextos

```csharp
public class IntegracaoService
{
    private readonly ControleAcessoDbContext _controleAcessoDb;
    private readonly CorporativoDbContext _corporativoDb;

    public IntegracaoService(
        ControleAcessoDbContext controleAcessoDb,
        CorporativoDbContext corporativoDb)
    {
        _controleAcessoDb = controleAcessoDb;
        _corporativoDb = corporativoDb;
    }

    public async Task SincronizarDadosAsync()
    {
        // Buscar usuário do Controle Acesso
        var usuario = await _controleAcessoDb.TB_CMC_USUARIOs
            .FirstOrDefaultAsync(u => u.ID_USUARIO == 1);

        // Buscar organização do Corporativo
        var organizacao = await _corporativoDb.TB_CMCORP_ORGANIZACAOs
            .FirstOrDefaultAsync(o => o.ID_ORGANIZACAO == usuario.ID_ORGANIZACAO);

        // Processar sincronização
        // ...
    }
}
```

---

## ?? Tabelas Disponíveis

### ControleAcessoDbContext (28 tabelas)

```
? TB_CMC_USUARIO
? TB_CMC_GRUPO
? TB_CMC_MODULO
? TB_CMC_SISTEMA
? TB_CMC_TELA
? TB_CMC_PERFIL_USUARIO
? TB_CMC_ALCADA
? TB_CMC_CARGO
... (28 tabelas total)
```

### CorporativoDbContext (40 tabelas)

```
? TB_CMCORP_ORGANIZACAO
? TB_CMCORP_BANCO
? TB_CMCORP_CIDADE
? TB_CMCORP_ESTADO
? TB_CMCORP_FERIADO
? TB_CMCORP_ETL
? TB_CMCORP_APP
... (40 tabelas total)
```

### ClienteMaisDbContext (514 tabelas - Base CRM)

```
? TB_CMCRM_CASO
? TB_CMCRM_PRODUTO
? TB_CMCRM_CLIENTE
? TB_CMCRM_PROPOSTA
? TB_CMCRM_CONTRATO
? TB_CMCRM_PESSOA
? TB_CMCRM_ATENDIMENTO
? TB_CMCRM_NEGOCIACAO
... (514 tabelas total)
```

**?? Importante**: O ClienteMaisDbContext representa o schema padrão de uma base CRM de cliente. O mesmo DbContext pode ser usado para diferentes bases de clientes (CLIENTEMAIS_CRM_CLIENTE1, CLIENTEMAIS_CRM_CLIENTE2, etc.) apenas alterando a connection string.

---

## ?? Re-Scaffold

### Atualizar ControleAcessoDbContext

```powershell
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated/ControleAcesso `
  --context ControleAcessoDbContext `
  --no-onconfiguring `
  --use-database-names `
  --force
```

### Atualizar CorporativoDbContext

```powershell
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated/Corporativo `
  --context CorporativoDbContext `
  --no-onconfiguring `
  --use-database-names `
  --force
```

### Atualizar ClienteMaisDbContext (Base CRM do Cliente)

```powershell
# Altere apenas o "Initial Catalog" para a base do cliente desejado
dotnet ef dbcontext scaffold "Data Source=...;Initial Catalog=CLIENTEMAIS_CRM_NOMECLIENTE_HMG;..." Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated/ClienteMais `
  --context ClienteMaisDbContext `
  --no-onconfiguring `
  --use-database-names `
  --force
```

---

## ?? Boas Práticas

### ? FAÇA

1. **Injete apenas o contexto que precisa**
   ```csharp
   public MeuServico(ControleAcessoDbContext db) // ? Específico
   ```

2. **Use namespaces explícitos**
   ```csharp
   using ReguaDisparo.Infrastructure.Data.Generated.ControleAcesso;
   using ReguaDisparo.Infrastructure.Data.Generated.Corporativo;
   ```

3. **Documente qual base está usando**
   ```csharp
   // Buscar usuários da base CONTROLE_ACESSO
   var usuarios = await _controleAcessoDb.TB_CMC_USUARIOs.ToListAsync();
   ```

### ? NÃO FAÇA

1. **Não misture entidades de bases diferentes sem necessidade**
   ```csharp
   // ? Evite joins entre bases diferentes
   var query = from u in _controleAcessoDb.TB_CMC_USUARIOs
               join o in _corporativoDb.TB_CMCORP_ORGANIZACAOs
               on u.ID_ORGANIZACAO equals o.ID_ORGANIZACAO
               select u; // ? Isso não funcionará!
   ```

2. **Não injete todos os contextos sem necessidade**
   ```csharp
   // ? Evite
   public MeuServico(
       ApplicationDbContext appDb,
       ControleAcessoDbContext controleDb,
       CorporativoDbContext corpDb) // ? Muitos contextos!
   ```

---

## ?? Troubleshooting

### Problema: Namespace não encontrado

**Erro:**
```
The type or namespace name 'ControleAcessoDbContext' could not be found
```

**Solução:**
```csharp
using ReguaDisparo.Infrastructure.Data.Generated.ControleAcesso;
```

### Problema: Connection string não configurada

**Erro:**
```
System.ArgumentNullException: Value cannot be null. (Parameter 'connectionString')
```

**Solução:**
Adicionar ao appsettings.json:
```json
{
  "ConnectionStrings": {
    "ControleAcessoConnection": "...",
    "CorporativoConnection": "..."
  }
}
```

### Problema: Tabela não encontrada

**Erro:**
```
Invalid object name 'TB_CMC_USUARIO'
```

**Solução:**
Verificar se:
1. Connection string aponta para o banco correto
2. Tabela existe no banco
3. Está usando o DbContext correto

---

## ?? Referências

- ?? [SCAFFOLD_GUIDE.md](SCAFFOLD_GUIDE.md) - Como fazer scaffold
- ?? [DATABASE_UPDATE_PROCESS.md](DATABASE_UPDATE_PROCESS.md) - Processo de atualização
- ?? [DATABASE_NAMING_CONVENTION.md](DATABASE_NAMING_CONVENTION.md) - Nomenclatura

---

## ? Checklist de Uso

### Ao Criar Novo Serviço

- [ ] Identifiquei qual(is) base(s) de dados preciso
- [ ] Injetei apenas o(s) DbContext(s) necessário(s)
- [ ] Adicionei using dos namespaces corretos
- [ ] Documentei qual base estou usando
- [ ] Testei a query

### Ao Fazer Re-Scaffold

- [ ] Fiz backup (git commit)
- [ ] Executei script correto (ControleAcesso ou Corporativo)
- [ ] Verifiquei namespaces
- [ ] Compilei sem erros
- [ ] Testei queries existentes

---

**Versão**: 1.0  
**Data**: 2024  
**Status**: ? Múltiplos DbContexts Configurados
