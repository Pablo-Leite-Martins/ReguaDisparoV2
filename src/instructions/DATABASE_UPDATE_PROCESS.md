# ?? Processo de Atualização do Banco de Dados

## ?? Visão Geral

Este documento descreve o fluxo completo de atualização do banco de dados e sincronização com o código usando Entity Framework Core.

---

## ?? Cenários de Atualização

### 1?? Primeira Vez (Setup Inicial)

#### Objetivo
Gerar classes C# a partir do banco de dados existente.

#### Passos

**1. Executar Scaffold Completo**
```powershell
.\scripts\scaffold-completo.ps1
```

**2. Verificar Arquivos Gerados**
```
ReguaDisparo.Infrastructure/Data/Generated/
??? GeneratedDbContext.cs
??? TbCmcUsuario.cs
??? TbCmcGrupo.cs
??? ... (todas as tabelas)
```

**3. Revisar e Integrar**
- Revisar mapeamentos no `GeneratedDbContext.cs`
- Decidir se vai usar `GeneratedDbContext` ou integrar com `ApplicationDbContext`
- Adicionar DbSets necessários

**4. Compilar e Testar**
```powershell
dotnet build
dotnet run --project ReguaDisparo.App
```

**5. Commit**
```powershell
git add .
git commit -m "feat: scaffold inicial do banco de dados"
```

---

### 2?? Adicionando Nova Tabela

#### Objetivo
Scaffolder apenas a nova tabela sem re-gerar tudo.

#### Passos

**1. Criar Tabela no SQL Server**
```sql
CREATE TABLE TB_CMC_NOVA_FUNCIONALIDADE (
    ID_FUNCIONALIDADE INT PRIMARY KEY IDENTITY(1,1),
    DS_NOME VARCHAR(200) NOT NULL,
    FL_ATIVO BIT NOT NULL DEFAULT 1,
    DT_CADASTRO DATETIME NOT NULL DEFAULT GETDATE()
)
```

**2. Editar Script de Scaffold**

Abrir `scripts/scaffold-tabela.ps1` e configurar:
```powershell
$Tabelas = @(
    "TB_CMC_NOVA_FUNCIONALIDADE"
)
```

**3. Executar Scaffold da Tabela**
```powershell
.\scripts\scaffold-tabela.ps1
```

**4. Verificar Arquivo Gerado**
```
ReguaDisparo.Infrastructure/Data/Generated/
??? TbCmcNovaFuncionalidade.cs  ? NOVO
```

**5. Atualizar ApplicationDbContext**

```csharp
// ReguaDisparo.Infrastructure/Data/ApplicationDbContext.cs
public DbSet<TbCmcNovaFuncionalidade> Funcionalidades => Set<TbCmcNovaFuncionalidade>();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    
    // Copiar configuração do GeneratedDbContext.cs
    modelBuilder.Entity<TbCmcNovaFuncionalidade>(entity =>
    {
        entity.HasKey(e => e.IdFuncionalidade);
        entity.ToTable("TB_CMC_NOVA_FUNCIONALIDADE");
        // ... resto da configuração
    });
}
```

**6. Compilar e Testar**
```powershell
dotnet build
dotnet run --project ReguaDisparo.App
```

**7. Commit**
```powershell
git add .
git commit -m "feat: adicionar tabela TB_CMC_NOVA_FUNCIONALIDADE"
```

---

### 3?? Alterando Estrutura de Tabela Existente

#### Objetivo
Atualizar classe C# quando a tabela foi modificada.

#### Passos

**1. Alterar Tabela no SQL Server**
```sql
-- Adicionar nova coluna
ALTER TABLE TB_CMC_USUARIO 
ADD DS_DEPARTAMENTO VARCHAR(100) NULL

-- Ou modificar coluna existente
ALTER TABLE TB_CMC_USUARIO 
ALTER COLUMN DS_EMAIL VARCHAR(300) NULL
```

**2. Re-Scaffold da Tabela Específica**

Editar `scripts/scaffold-tabela.ps1`:
```powershell
$Tabelas = @(
    "TB_CMC_USUARIO"
)
```

Executar:
```powershell
.\scripts\scaffold-tabela.ps1
```

**3. Revisar Alterações**
```powershell
# Ver o que mudou
git diff ReguaDisparo.Infrastructure/Data/Generated/TbCmcUsuario.cs
```

**4. Atualizar Mapeamento (se necessário)**

Se você copiou configurações para `ApplicationDbContext`, atualize também:
```csharp
// Adicionar nova propriedade no mapeamento
entity.Property(e => e.DsDepartamento)
    .HasMaxLength(100)
    .HasColumnName("DS_DEPARTAMENTO");
```

**5. Compilar e Testar**
```powershell
dotnet build
```

**6. Commit**
```powershell
git add .
git commit -m "refactor: atualizar estrutura TB_CMC_USUARIO (novo campo DS_DEPARTAMENTO)"
```

---

### 4?? Removendo Tabela

#### Objetivo
Remover referências de uma tabela que foi deletada do banco.

#### Passos

**1. Deletar Tabela no SQL Server**
```sql
DROP TABLE TB_CMC_TABELA_ANTIGA
```

**2. Remover Arquivo da Entidade**
```powershell
Remove-Item ReguaDisparo.Infrastructure\Data\Generated\TbCmcTabelaAntiga.cs
```

**3. Remover DbSet do DbContext**
```csharp
// Remover do ApplicationDbContext.cs
// public DbSet<TbCmcTabelaAntiga> TabelasAntigas => Set<TbCmcTabelaAntiga>();
```

**4. Remover Configuração**
```csharp
// Remover do OnModelCreating
// modelBuilder.Entity<TbCmcTabelaAntiga>(...);
```

**5. Compilar**
```powershell
dotnet build
```

**6. Commit**
```powershell
git add .
git commit -m "refactor: remover tabela TB_CMC_TABELA_ANTIGA"
```

---

### 5?? Atualização Completa (Re-Scaffold)

#### Objetivo
Re-gerar todas as classes quando houve muitas mudanças.

#### Passos

**1. Backup do Código Atual**
```powershell
git add .
git commit -m "backup antes do re-scaffold completo"
```

**2. Executar Re-Scaffold**
```powershell
.\scripts\scaffold-completo.ps1
```

**3. Revisar Todas as Alterações**
```powershell
git status
git diff
```

**4. Atualizar ApplicationDbContext**
- Copiar novos DbSets
- Copiar novas configurações do `OnModelCreating`
- Manter customizações existentes

**5. Compilar e Testar**
```powershell
dotnet build
dotnet run --project ReguaDisparo.App
```

**6. Commit**
```powershell
git add .
git commit -m "refactor: re-scaffold completo do banco de dados"
```

---

## ?? Fluxograma de Decisão

```
???????????????????????????????
?  O que você vai fazer?      ?
???????????????????????????????
               ?
        ???????????????
        ?             ?
        ?             ?
?????????????   ????????????????
? Nova      ?   ? Alterar      ?
? Tabela?   ?   ? Tabela?      ?
?????????????   ????????????????
      ?                ?
      ?                ?
 scaffold-       scaffold-
 tabela.ps1      tabela.ps1
      ?                ?
      ?                ?
      ??????????????????
               ?
               ?
      ??????????????????
      ? Atualizar      ?
      ? DbContext      ?
      ??????????????????
               ?
               ?
      ??????????????????
      ? Compilar       ?
      ? dotnet build   ?
      ??????????????????
               ?
               ?
      ??????????????????
      ? Testar         ?
      ??????????????????
               ?
               ?
      ??????????????????
      ? Commit         ?
      ??????????????????
```

---

## ?? Boas Práticas

### ? FAÇA

1. **Sempre faça backup antes de re-scaffold**
   ```powershell
   git add .
   git commit -m "backup antes do scaffold"
   ```

2. **Use scaffold de tabela específica quando possível**
   - Mais rápido
   - Menos conflitos
   - Alterações mais controladas

3. **Revise as alterações antes de commit**
   ```powershell
   git diff
   ```

4. **Mantenha customizações no ApplicationDbContext**
   - Não edite arquivos em `Data/Generated`
   - Copie configurações necessárias

5. **Documente alterações no commit**
   ```powershell
   git commit -m "feat: adicionar tabela TB_CMC_LOG_AUDITORIA
   
   - Scaffold da nova tabela de auditoria
   - Adicionar DbSet no ApplicationDbContext
   - Configuração Fluent API"
   ```

### ? NÃO FAÇA

1. **Não edite arquivos em `Data/Generated`**
   - Serão sobrescritos no próximo scaffold
   - Use `ApplicationDbContext` para customizações

2. **Não commite credenciais**
   - Use User Secrets para development
   - Use variáveis de ambiente para produção

3. **Não ignore erros de compilação**
   - Sempre execute `dotnet build` após scaffold
   - Corrija erros antes de commit

4. **Não execute scaffold em produção**
   - Scaffold é para desenvolvimento
   - Em produção, use apenas Migrations aplicadas

---

## ??? Scripts Disponíveis

| Script | Quando Usar | Comando |
|--------|-------------|---------|
| `scaffold-completo.ps1` | Primeira vez ou muitas alterações | `.\scripts\scaffold-completo.ps1` |
| `scaffold-tabela.ps1` | Nova tabela ou alterar específica | `.\scripts\scaffold-tabela.ps1` |

---

## ?? Exemplos Práticos

### Exemplo 1: Adicionar Tabela de Log

```sql
-- 1. SQL Server
CREATE TABLE TB_CMC_LOG_SISTEMA (
    ID_LOG INT PRIMARY KEY IDENTITY,
    DT_CRIACAO DATETIME NOT NULL DEFAULT GETDATE(),
    DS_MENSAGEM VARCHAR(MAX),
    DS_NIVEL VARCHAR(50)
)
```

```powershell
# 2. Scaffold
# Editar scripts/scaffold-tabela.ps1
$Tabelas = @("TB_CMC_LOG_SISTEMA")

.\scripts\scaffold-tabela.ps1
```

```csharp
// 3. ApplicationDbContext.cs
public DbSet<TbCmcLogSistema> LogsSistema => Set<TbCmcLogSistema>();

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<TbCmcLogSistema>(entity =>
    {
        entity.HasKey(e => e.IdLog);
        entity.ToTable("TB_CMC_LOG_SISTEMA");
        
        entity.Property(e => e.DtCriacao)
            .HasColumnName("DT_CRIACAO");
        
        entity.Property(e => e.DsMensagem)
            .HasColumnName("DS_MENSAGEM");
            
        entity.Property(e => e.DsNivel)
            .HasMaxLength(50)
            .HasColumnName("DS_NIVEL");
    });
}
```

---

## ?? Troubleshooting

### Problema: Scaffold não gera nada

**Causas:**
- Connection string incorreta
- Database não especificado
- Usuário sem permissões

**Solução:**
```powershell
# Verificar connection string
dotnet ef dbcontext info --startup-project ReguaDisparo.App --project ReguaDisparo.Infrastructure
```

### Problema: Erro ao compilar após scaffold

**Causas:**
- Namespace errado
- Referências quebradas
- Tipos incompatíveis

**Solução:**
```powershell
# Ver erro detalhado
dotnet build --verbosity detailed

# Limpar e reconstruir
dotnet clean
dotnet build
```

### Problema: Alterações perdidas após re-scaffold

**Causa:**
- Editou arquivos em `Data/Generated`

**Solução:**
- Use `ApplicationDbContext` para customizações
- Mantenha configurações separadas
- Não edite arquivos gerados

---

## ?? Referências

- ?? [SCAFFOLD_GUIDE.md](SCAFFOLD_GUIDE.md) - Guia completo de scaffold
- ?? [EF_CORE_GUIDE.md](EF_CORE_GUIDE.md) - Guia do Entity Framework
- ?? [scripts/README.md](../scripts/README.md) - Documentação dos scripts

---

**Versão**: 1.0  
**Data**: 2024  
**Status**: ? Processo Documentado
