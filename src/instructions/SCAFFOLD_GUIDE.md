# ?? Guia de Scaffold Entity Framework Core

## ?? Visão Geral

Este documento descreve o processo completo de scaffold (reverse engineering) do Entity Framework Core a partir de um banco de dados existente, incluindo scripts prontos para uso.

---

## ? Pré-requisitos

### 1. Pacotes Necessários

**ReguaDisparo.Infrastructure** (já instalado):
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.11" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.11" />
```

**ReguaDisparo.App** (já instalado):
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.11" />
```

### 2. Ferramenta dotnet-ef (CLI)

```bash
# Instalar globalmente
dotnet tool install --global dotnet-ef

# Ou atualizar se já instalado
dotnet tool update --global dotnet-ef

# Verificar instalação
dotnet ef --version
```

---

## ?? Scaffold Completo do Banco de Dados

### Script Principal (Scaffold Completo)

**Executar da raiz do repositório:**

```powershell
# ?? Edite apenas a connection string com suas credenciais
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;Persist Security Info=True;User ID=usr_capys;Password=SUA_SENHA_AQUI;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

# ?? Configurações do scaffold
$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated"
$ContextName = "GeneratedDbContext"

# ?? Executar scaffold
dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project $ProjectInfra `
  --startup-project $ProjectApp `
  --output-dir $OutputDir `
  --context $ContextName `
  --no-onconfiguring `
  --force
```

### Explicação dos Parâmetros

| Parâmetro | Descrição |
|-----------|-----------|
| `--project` | Projeto onde os arquivos serão gerados (Infrastructure) |
| `--startup-project` | Projeto de startup (App) para resolver dependências |
| `--output-dir` | Diretório de saída para as entidades geradas |
| `--context` | Nome do DbContext gerado |
| `--no-onconfiguring` | NÃO gerar o método OnConfiguring (melhor para DI) |
| `--force` | Sobrescrever arquivos existentes |

### Resultado Esperado

```
ReguaDisparo.Infrastructure/
??? Data/
    ??? Generated/
        ??? GeneratedDbContext.cs          # DbContext com Fluent API
        ??? TbCmcUsuario.cs                # Entidade 1
        ??? TbCmcGrupo.cs                  # Entidade 2
        ??? TbCmcModulo.cs                 # Entidade 3
        ??? ... (todas as tabelas do banco)
```

---

## ?? Scaffold de Tabelas Específicas

### Script para Scaffold de Apenas Uma Tabela

**Use este script quando criar uma NOVA tabela no banco de dados:**

```powershell
# ========================================
# ?? SCAFFOLD DE TABELA ESPECÍFICA
# ========================================

# ?? CONFIGURAR: Connection String
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;Persist Security Info=True;User ID=usr_capys;Password=SUA_SENHA_AQUI;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;"

# ?? CONFIGURAR: Nome da(s) tabela(s) - APENAS O QUE VOCÊ QUER SCAFFOLDER
$Tabelas = @(
    "TB_NOVA_TABELA"
    # "TB_OUTRA_TABELA_NOVA"  # Descomente para adicionar mais tabelas
)

# ?? Configurações (geralmente não precisa alterar)
$ProjectInfra = "ReguaDisparo.Infrastructure"
$ProjectApp = "ReguaDisparo.App"
$OutputDir = "Data/Generated"
$ContextName = "GeneratedDbContext"

# ??? Construir comando com --table para cada tabela
$TableParams = $Tabelas | ForEach-Object { "--table $_ " }
$TableParamsStr = $TableParams -join ""

# ?? Executar scaffold
$Command = "dotnet ef dbcontext scaffold `"$ConnectionString`" Microsoft.EntityFrameworkCore.SqlServer --project $ProjectInfra --startup-project $ProjectApp --output-dir $OutputDir --context $ContextName --no-onconfiguring --force $TableParamsStr"

Write-Host "?? Executando scaffold das tabelas: $($Tabelas -join ', ')" -ForegroundColor Cyan
Invoke-Expression $Command

if ($LASTEXITCODE -eq 0) {
    Write-Host "? Scaffold concluído com sucesso!" -ForegroundColor Green
    Write-Host "?? Arquivos gerados em: $ProjectInfra\$OutputDir" -ForegroundColor Yellow
} else {
    Write-Host "? Erro ao executar scaffold!" -ForegroundColor Red
}
```

### Exemplo de Uso - Scaffolding de Uma Tabela Nova

```powershell
# Criar apenas a tabela TB_CMC_NOVA_FUNCIONALIDADE
$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;..."
$Tabelas = @("TB_CMC_NOVA_FUNCIONALIDADE")

dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --no-onconfiguring `
  --force `
  --table TB_CMC_NOVA_FUNCIONALIDADE
```

---

## ?? Atualizar Scaffold Existente (Re-Scaffold)

### Quando Usar

- Alterou estrutura de tabelas existentes (adicionou/removeu colunas)
- Adicionou novas tabelas
- Mudou chaves estrangeiras/índices

### Script de Re-Scaffold

```powershell
# ?? ATENÇÃO: Isso SOBRESCREVERÁ todos os arquivos gerados!
# Certifique-se de ter feito backup das alterações manuais

$ConnectionString = "Data Source=177.85.162.238,8002;Initial Catalog=CLIENTEMAIS_CONTROLE_ACESSO;..."

dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --no-onconfiguring `
  --force
```

---

## ?? Opções Avançadas de Scaffold

### 1. Scaffold com Schemas Específicos

```powershell
dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --startup-project ReguaDisparo.App `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --schema dbo `
  --schema sec `
  --no-onconfiguring `
  --force
```

### 2. Scaffold com Data Annotations (NÃO RECOMENDADO)

```powershell
# ?? NÃO USE - Polui as classes com atributos
dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --data-annotations `  # ? Evite isso!
  --force
```

### 3. Preservar Nomes do Banco de Dados

```powershell
# Mantém nomes exatos de tabelas e colunas (útil para bancos legados)
dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --use-database-names `
  --no-onconfiguring `
  --force
```

### 4. Scaffold sem Pluralizar Nomes

```powershell
# Evita pluralização automática de nomes (DbSet<User> Users)
dotnet ef dbcontext scaffold "$ConnectionString" Microsoft.EntityFrameworkCore.SqlServer `
  --project ReguaDisparo.Infrastructure `
  --output-dir Data/Generated `
  --context GeneratedDbContext `
  --no-pluralize `
  --no-onconfiguring `
  --force
```

---

## ??? Organização dos Arquivos Gerados

### Estrutura Recomendada

```
ReguaDisparo.Infrastructure/
??? Data/
?   ??? ApplicationDbContext.cs        # DbContext principal (manual)
?   ??? Generated/                     # Arquivos do scaffold
?       ??? GeneratedDbContext.cs      # DbContext gerado (reference)
?       ??? TbCmcUsuario.cs
?       ??? TbCmcGrupo.cs
?       ??? ...
```

### Integração com ApplicationDbContext

**Opção 1: Copiar Configurações Manualmente**
```csharp
// Copie o OnModelCreating do GeneratedDbContext para ApplicationDbContext
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    
    // Copiar configurações do GeneratedDbContext aqui
    modelBuilder.Entity<TbCmcUsuario>(entity =>
    {
        entity.HasKey(e => e.IdUsuario);
        entity.ToTable("TB_CMC_USUARIO");
        // ...
    });
}
```

**Opção 2: Herança Parcial** (Recomendado)
```csharp
// ApplicationDbContext.cs
public partial class ApplicationDbContext : DbContext
{
    // Configuração manual aqui
}

// ApplicationDbContext.Generated.cs (arquivo separado)
public partial class ApplicationDbContext
{
    // Copiar DbSets e OnModelCreating do GeneratedDbContext
}
```

---

## ?? Segurança - Connection Strings

### ? NUNCA Faça Isso (Hardcode)

```powershell
# ? Credenciais expostas no script!
$ConnectionString = "...;Password=senha123;..."
```

### ? Use User Secrets (Desenvolvimento)

```powershell
# 1. Configurar User Secret
cd ReguaDisparo.App
dotnet user-secrets set "ConnectionStrings:Scaffold" "Data Source=...;Password=SUA_SENHA;"

# 2. Ler do User Secrets no script
$ConnectionString = dotnet user-secrets get "ConnectionStrings:Scaffold"

# 3. Executar scaffold
dotnet ef dbcontext scaffold "$ConnectionString" ...
```

### ? Use Variáveis de Ambiente (CI/CD)

```powershell
# 1. Definir variável de ambiente
$env:DB_SCAFFOLD_CONN = "Data Source=...;Password=SUA_SENHA;"

# 2. Usar no script
$ConnectionString = $env:DB_SCAFFOLD_CONN

dotnet ef dbcontext scaffold "$ConnectionString" ...
```

---

## ?? Checklist de Scaffold

### Antes de Executar

- [ ] Backup do código atual (commit Git)
- [ ] Connection string configurada (User Secrets ou variável)
- [ ] Permissões de leitura no banco de dados
- [ ] Ferramentas instaladas (`dotnet ef --version`)
- [ ] Decidir se é scaffold completo ou tabelas específicas

### Após Executar

- [ ] Revisar arquivos gerados em `Data/Generated`
- [ ] Verificar mapeamentos no `GeneratedDbContext.cs`
- [ ] Integrar com `ApplicationDbContext` (se necessário)
- [ ] Ajustar namespaces (se moveu entidades)
- [ ] Compilar e testar (`dotnet build`)
- [ ] Commit das alterações

---

## ??? Troubleshooting

### Erro: "Build failed"
**Solução**: Execute `dotnet build` antes do scaffold para ver erros específicos.

### Erro: "No database provider configured"
**Solução**: Certifique-se que `Microsoft.EntityFrameworkCore.Design` está no App.

### Erro: "Login failed for user"
**Solução**: Verifique credenciais e permissões SQL Server.

### Tabelas não aparecem
**Solução**: 
- Verifique `Initial Catalog` na connection string
- Verifique permissões do usuário SQL
- Use `--schema dbo` se necessário

### DbContext vazio (sem DbSets)
**Solução**: Connection string incorreta ou banco vazio.

---

## ?? Comandos Úteis

### Listar Informações do DbContext

```powershell
# Ver informações do contexto
dotnet ef dbcontext info --startup-project ReguaDisparo.App --project ReguaDisparo.Infrastructure

# Listar todos os DbContexts
dotnet ef dbcontext list --startup-project ReguaDisparo.App --project ReguaDisparo.Infrastructure

# Gerar script SQL do modelo
dotnet ef dbcontext script --startup-project ReguaDisparo.App --project ReguaDisparo.Infrastructure
```

### Ver SQL Gerado

```powershell
# SQL que seria executado para criar o banco
dotnet ef dbcontext script --startup-project ReguaDisparo.App --project ReguaDisparo.Infrastructure --output schema.sql
```

---

## ?? Fluxo de Trabalho Recomendado

### 1. Primeira Vez (Scaffold Inicial)

```powershell
# 1. Scaffold completo
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer ...

# 2. Revisar e integrar
# 3. Commit
git add .
git commit -m "feat: scaffold inicial do banco de dados"
```

### 2. Adicionando Nova Tabela

```powershell
# 1. Criar tabela no banco (SQL Server)
CREATE TABLE TB_NOVA_TABELA (...)

# 2. Scaffold apenas da nova tabela
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer --table TB_NOVA_TABELA ...

# 3. Integrar ao ApplicationDbContext
# 4. Commit
git commit -m "feat: scaffold tabela TB_NOVA_TABELA"
```

### 3. Atualizando Tabela Existente

```powershell
# 1. Alterar tabela no banco (SQL Server)
ALTER TABLE TB_USUARIO ADD COLUMN_NOVA VARCHAR(100)

# 2. Re-scaffold da tabela
dotnet ef dbcontext scaffold "..." Microsoft.EntityFrameworkCore.SqlServer --table TB_USUARIO --force ...

# 3. Revisar alterações
# 4. Commit
git commit -m "refactor: atualização estrutura TB_USUARIO"
```

---

## ?? Referências

- [EF Core Reverse Engineering](https://learn.microsoft.com/ef/core/managing-schemas/scaffolding/)
- [EF Core CLI Reference](https://learn.microsoft.com/ef/core/cli/dotnet)
- [Connection Strings](https://www.connectionstrings.com/sql-server/)

---

**Versão**: 1.0  
**Data**: 2024  
**Autor**: Time ReguaDisparo  
**Status**: ? Documentação Completa
