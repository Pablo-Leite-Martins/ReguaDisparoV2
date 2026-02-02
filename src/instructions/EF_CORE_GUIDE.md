# Entity Framework Core - Guia de Uso

## ? Configuração Implementada

O Entity Framework Core foi configurado com sucesso no projeto ReguaDisparo!

### ?? Pacotes Adicionados
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.11" />
```

### ??? DbContext Criado

**Localização**: `ReguaDisparo.Infrastructure/Data/ApplicationDbContext.cs`

**Entidades Mapeadas**:
- ? Organization (ORGANIZACAO)
- ? ReguaCobranca (CASO_COBRANCA_REGUA)
- ? ReguaCobrancaEtapa (CASO_COBRANCA_REGUA_ETAPA)
- ? ReguaCobrancaEtapaAcao (CASO_COBRANCA_REGUA_ETAPA_ACAO)
- ? ReguaCobrancaHistoricoEnvio (CASO_COBRANCA_REGUA_HISTORICO_ENVIO)
- ? ConfigGeral (CONFIG_GERAL)

### ?? Configuração de DI

**InfrastructureModule.cs**:
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
        sqlOptions.CommandTimeout(30);
    });
    
    #if DEBUG
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
    #endif
});
```

### ?? Repositórios Atualizados

? **OrganizationRepository** - Usando EF Core
```csharp
public async Task<List<Organization>> GetActiveOrganizationsAsync()
{
    return await _context.Organizations
        .Where(o => o.Ativa && !string.IsNullOrEmpty(o.NomeBancoCRM))
        .OrderBy(o => o.NomeFantasia)
        .ToListAsync();
}
```

? **ReguaCobrancaRepository** - Usando EF Core
```csharp
public async Task<List<ReguaCobranca>> GetActiveReguasAsync(string databaseName)
{
    return await _context.ReguasCobranca
        .Where(r => r.Ativa)
        .OrderBy(r => r.Id)
        .ToListAsync();
}
```

---

## ?? Como Usar Migrations

### 1?? Criar Migration Inicial

Se o banco de dados já existe (Code First from Database):

```bash
# Navegar para o projeto Infrastructure
cd ReguaDisparo.Infrastructure

# Criar migration inicial (scaffold do banco existente)
dotnet ef migrations add InitialCreate --startup-project ../ReguaDisparo.App

# Ou usar o Package Manager Console no Visual Studio:
Add-Migration InitialCreate -StartupProject ReguaDisparo.App -Project ReguaDisparo.Infrastructure
```

### 2?? Aplicar Migration ao Banco

```bash
# Via CLI
dotnet ef database update --startup-project ../ReguaDisparo.App

# Ou via Package Manager Console
Update-Database -StartupProject ReguaDisparo.App -Project ReguaDisparo.Infrastructure
```

### 3?? Criar Novas Migrations (após alterar entidades)

```bash
# Adicionar nova migration
dotnet ef migrations add NomeDaMigration --startup-project ../ReguaDisparo.App

# Aplicar ao banco
dotnet ef database update --startup-project ../ReguaDisparo.App
```

### 4?? Reverter Migration

```bash
# Reverter última migration
dotnet ef database update PreviousMigrationName --startup-project ../ReguaDisparo.App

# Remover última migration (se ainda não aplicada)
dotnet ef migrations remove --startup-project ../ReguaDisparo.App
```

### 5?? Gerar Script SQL

```bash
# Gerar script SQL da migration
dotnet ef migrations script --startup-project ../ReguaDisparo.App --output migration.sql

# Gerar script de uma migration específica para outra
dotnet ef migrations script FromMigration ToMigration --startup-project ../ReguaDisparo.App
```

---

## ?? Configuração de Connection String

**appsettings.json**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ReguaDisparo;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**User Secrets (Desenvolvimento)**:
```bash
cd ReguaDisparo.App
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=ReguaDisparo;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
```

---

## ?? Funcionalidades do DbContext

### Retry on Failure
Configurado para tentar novamente até 3 vezes em caso de falha temporária:
```csharp
sqlOptions.EnableRetryOnFailure(
    maxRetryCount: 3,
    maxRetryDelay: TimeSpan.FromSeconds(5),
    errorNumbersToAdd: null);
```

### Command Timeout
Timeout de 30 segundos para queries:
```csharp
sqlOptions.CommandTimeout(30);
```

### Debug Mode
Em modo DEBUG, habilita logs detalhados:
```csharp
#if DEBUG
options.EnableSensitiveDataLogging();
options.EnableDetailedErrors();
#endif
```

---

## ?? Mapeamento de Entidades

### Organization ? ORGANIZACAO
```csharp
Id                ? ID_ORGANIZACAO
NomeFantasia      ? DS_NOME_FANTASIA
RazaoSocial       ? DS_RAZAO_SOCIAL
NomeBancoCRM      ? NOME_BANCO_CRM
Ativa             ? FL_ATIVO
DataCadastro      ? DT_CADASTRO
DataAtualizacao   ? DT_ATUALIZACAO
```

### ReguaCobranca ? CASO_COBRANCA_REGUA
```csharp
Id           ? ID_CASO_COBRANCA_REGUA
Descricao    ? DS_DESCRICAO
Ativa        ? FL_ATIVO
DataCadastro ? DT_CADASTRO
```

### ReguaCobrancaEtapa ? CASO_COBRANCA_REGUA_ETAPA
```csharp
Id                  ? ID_CASO_COBRANCA_REGUA_ETAPA
ReguaCobrancaId     ? ID_CASO_COBRANCA_REGUA
Descricao           ? DS_DESCRICAO
Ordem               ? NR_ORDEM
DiasAposVencimento  ? NR_DIAS_APOS_VENCIMENTO
Ativa               ? FL_ATIVO
```

---

## ?? Observações Importantes

### 1. Banco de Dados por Organização

O sistema legado usa um banco de dados diferente para cada organização. O DbContext atual usa a connection string padrão. Para suportar múltiplos bancos, há duas abordagens:

#### Opção A: Criar DbContext por Organização (Recomendado)
```csharp
public interface IDbContextFactory
{
    ApplicationDbContext CreateDbContext(string databaseName);
}
```

#### Opção B: Trocar Connection String Dinamicamente
```csharp
var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionsBuilder.UseSqlServer(GetConnectionString(databaseName));
var context = new ApplicationDbContext(optionsBuilder.Options);
```

### 2. Migrations com Banco Existente

Se o banco de dados **JÁ EXISTE**:
1. **NÃO rode** `Update-Database` inicialmente
2. Crie a migration inicial: `Add-Migration InitialCreate`
3. Comente o método `Up()` da migration gerada (para não recriar tabelas)
4. Execute `Update-Database` apenas para criar a tabela `__EFMigrationsHistory`

### 3. Tabelas Não Gerenciadas pelo EF

Se algumas tabelas não devem ser gerenciadas pelo EF Core, use:
```csharp
modelBuilder.Entity<MyEntity>().ToTable("MyTable", t => t.ExcludeFromMigrations());
```

---

## ?? Verificar Configuração

### Listar Migrations
```bash
dotnet ef migrations list --startup-project ../ReguaDisparo.App
```

### Ver SQL que será Executado
```bash
dotnet ef migrations script --startup-project ../ReguaDisparo.App
```

### Verificar Modelo
```bash
dotnet ef dbcontext info --startup-project ../ReguaDisparo.App
```

### Ver Entidades Mapeadas
```bash
dotnet ef dbcontext list --startup-project ../ReguaDisparo.App
```

---

## ?? Próximos Passos

1. [ ] Decidir estratégia para múltiplos bancos de dados
2. [ ] Criar migrations iniciais (se necessário)
3. [ ] Implementar DbContextFactory para multi-tenancy
4. [ ] Adicionar índices para otimização
5. [ ] Configurar lazy loading (se necessário)
6. [ ] Implementar Unit of Work pattern (opcional)
7. [ ] Adicionar testes de integração com banco em memória

---

## ??? Troubleshooting

### Erro: "No database provider has been configured"
**Solução**: Certifique-se de que o `AddDbContext` está registrado no DI.

### Erro: "Cannot access a disposed context"
**Solução**: Use `AddScoped` para DbContext (já configurado).

### Erro: "Login failed for user"
**Solução**: Verifique connection string e permissões do usuário SQL.

### Migrations não aparecem
**Solução**: Execute comandos do diretório correto (`ReguaDisparo.Infrastructure`).

---

## ? Checklist de Implementação

- [x] Pacotes NuGet instalados
- [x] ApplicationDbContext criado
- [x] Mapeamento de entidades configurado
- [x] DbContext registrado no DI
- [x] Repositórios atualizados para usar EF Core
- [x] Retry e timeout configurados
- [ ] Migrations criadas
- [ ] Migrations aplicadas ao banco
- [ ] Estratégia multi-tenant definida
- [ ] Testes de integração criados

---

**Versão**: 1.0  
**Data**: 2024  
**Status**: ? Configuração Base Completa
