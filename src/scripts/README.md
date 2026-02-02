# ?? Scripts de Scaffold - ReguaDisparo

Scripts PowerShell prontos para executar scaffold do Entity Framework Core.

## ?? Arquivos Disponíveis

| Script | Descrição | Uso |
|--------|-----------|-----|
| `scaffold-completo.ps1` | Scaffold completo do banco de dados | Primeira vez ou atualização completa |
| `scaffold-tabela.ps1` | Scaffold de tabelas específicas | Quando criar nova(s) tabela(s) |

---

## ?? Como Usar

### 1?? Scaffold Completo (Primeira Vez)

```powershell
# 1. Editar scaffold-completo.ps1
# 2. Configurar a connection string

# 3. Executar
.\scripts\scaffold-completo.ps1
```

**Quando usar:**
- ? Primeira vez configurando o projeto
- ? Atualizar todas as tabelas de uma vez
- ? Re-fazer scaffold completo após mudanças grandes no banco

**Resultado:**
- Gera `GeneratedDbContext.cs` com todas as tabelas
- Gera arquivo `.cs` para cada tabela do banco
- Sobrescreve arquivos existentes (use `--force`)

---

### 2?? Scaffold de Tabela Específica (Nova Tabela)

```powershell
# 1. Editar scaffold-tabela.ps1
# 2. Configurar connection string e nome(s) da(s) tabela(s)

$Tabelas = @(
    "TB_NOVA_TABELA"
)

# 3. Executar
.\scripts\scaffold-tabela.ps1
```

**Quando usar:**
- ? Criou uma nova tabela no banco
- ? Quer atualizar apenas tabelas específicas
- ? Não quer re-scaffolder tudo

**Resultado:**
- Atualiza `GeneratedDbContext.cs` adicionando nova tabela
- Gera apenas os arquivos das tabelas especificadas

---

## ?? Configuração

### Connection String

**Edite em cada script:**

```powershell
$ConnectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO;User ID=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
```

### Segurança - User Secrets (Recomendado)

Em vez de hardcode da senha:

```powershell
# 1. Configurar User Secret (uma vez)
cd ReguaDisparo.App
dotnet user-secrets set "ConnectionStrings:Scaffold" "Data Source=...;Password=SUA_SENHA;"

# 2. Ler no script
$ConnectionString = dotnet user-secrets get "ConnectionStrings:Scaffold" --project ReguaDisparo.App
```

---

## ?? Pré-requisitos

### 1. dotnet-ef (CLI)

```powershell
# Instalar
dotnet tool install --global dotnet-ef

# Verificar
dotnet ef --version
```

### 2. Pacotes NuGet

Já instalados no projeto:
- ? `Microsoft.EntityFrameworkCore.Design` (ReguaDisparo.App)
- ? `Microsoft.EntityFrameworkCore.SqlServer` (ReguaDisparo.Infrastructure)
- ? `Microsoft.EntityFrameworkCore.Tools` (ReguaDisparo.Infrastructure)

---

## ?? Exemplos de Uso

### Exemplo 1: Scaffold Inicial

```powershell
# Primeira vez - scaffolder todo o banco
.\scripts\scaffold-completo.ps1
```

### Exemplo 2: Nova Tabela Criada

```powershell
# 1. Criar tabela no SQL Server
CREATE TABLE TB_CMC_LOG_AUDITORIA (
    ID_LOG INT PRIMARY KEY IDENTITY,
    DT_CRIACAO DATETIME NOT NULL,
    DS_ACAO VARCHAR(500)
)

# 2. Editar scaffold-tabela.ps1
$Tabelas = @("TB_CMC_LOG_AUDITORIA")

# 3. Executar
.\scripts\scaffold-tabela.ps1
```

### Exemplo 3: Múltiplas Tabelas Novas

```powershell
# Editar scaffold-tabela.ps1
$Tabelas = @(
    "TB_CMC_LOG_AUDITORIA",
    "TB_CMC_LOG_SISTEMA",
    "TB_CMC_CONFIGURACAO"
)

# Executar
.\scripts\scaffold-tabela.ps1
```

---

## ??? Arquivos Gerados

Após executar os scripts:

```
ReguaDisparo.Infrastructure/
??? Data/
    ??? Generated/
        ??? GeneratedDbContext.cs          # DbContext com Fluent API
        ??? TbCmcUsuario.cs                # Entidade 1
        ??? TbCmcGrupo.cs                  # Entidade 2
        ??? ... (uma classe por tabela)
```

---

## ?? Personalização

### Alterar Diretório de Saída

```powershell
# Editar no script:
$OutputDir = "Models/Entities"  # Em vez de "Data/Generated"
```

### Alterar Nome do DbContext

```powershell
# Editar no script:
$ContextName = "MyCustomDbContext"  # Em vez de "GeneratedDbContext"
```

### Usar Data Annotations (NÃO RECOMENDADO)

```powershell
# Adicionar flag no comando (dentro do script):
$Command = @(
    # ... outras flags ...
    "--data-annotations"  # ? Evite - polui as classes
)
```

---

## ?? Avisos Importantes

### ?? Sobrescreve Arquivos

Os scripts usam `--force`:
- ? Sobrescreve arquivos gerados anteriormente
- ?? Perderá alterações manuais nos arquivos
- ?? Solução: Não edite arquivos em `Data/Generated` - use `ApplicationDbContext`

### ?? Backup Antes de Re-Scaffold

```powershell
# Antes de re-executar:
git status
git add .
git commit -m "backup antes do re-scaffold"
```

### ?? Credenciais no Script

- ? Não commite scripts com senhas
- ? Use User Secrets ou variáveis de ambiente
- ? Adicione `scripts/` ao `.gitignore` (se tiver credenciais)

---

## ?? Troubleshooting

### Erro: "dotnet-ef não encontrado"

```powershell
# Instalar
dotnet tool install --global dotnet-ef

# Ou atualizar
dotnet tool update --global dotnet-ef
```

### Erro: "Login failed for user"

- ? Verifique usuário e senha
- ? Verifique permissões SQL Server
- ? Teste connection string manualmente

### Erro: "Build failed"

```powershell
# Compilar antes do scaffold
dotnet build

# Ver erros específicos
dotnet build --verbosity detailed
```

### Tabelas não aparecem

- ? Verifique `Initial Catalog` na connection string
- ? Verifique se tabelas existem no schema `dbo`
- ? Verifique permissões do usuário SQL

---

## ?? Documentação Completa

Para informações detalhadas, consulte:
- ?? `instructions/SCAFFOLD_GUIDE.md` - Guia completo de scaffold
- ?? `instructions/EF_CORE_GUIDE.md` - Guia do Entity Framework Core

---

## ? Checklist de Uso

### Antes de Executar
- [ ] Backup do código (commit Git)
- [ ] Connection string configurada
- [ ] dotnet-ef instalado
- [ ] Decidir: scaffold completo ou tabela específica?

### Após Executar
- [ ] Revisar arquivos em `Data/Generated`
- [ ] Integrar com `ApplicationDbContext` (se necessário)
- [ ] Compilar: `dotnet build`
- [ ] Testar aplicação
- [ ] Commit das alterações

---

**Versão**: 1.0  
**Data**: 2024  
**Status**: ? Scripts Prontos para Uso
