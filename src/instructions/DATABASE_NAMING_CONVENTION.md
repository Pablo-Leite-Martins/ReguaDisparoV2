# ?? IMPORTANTE: Nomenclatura do Banco de Dados

## ?? Flag `--use-database-names` Adicionada

### ? Mudança Importante

Todos os scripts de scaffold foram atualizados para incluir a flag `--use-database-names`, que **preserva a nomenclatura EXATA do banco de dados**.

---

## ?? Antes vs Depois

### ? ANTES (SEM --use-database-names)

**Problema**: Nomes convertidos para PascalCase

**Classe Gerada**:
```csharp
public partial class TbCmcAlcadum  // ? PascalCase
{
    public int IdAlcada { get; set; }              // ? PascalCase
    public string? DsAlcada { get; set; }          // ? PascalCase
    public string? DsCategoriaAlcada { get; set; } // ? PascalCase
}
```

**Mapeamento**:
```csharp
entity.ToTable("TB_CMC_ALCADA");  // ? Nome da tabela preservado

entity.Property(e => e.IdAlcada)
    .HasColumnName("ID_ALCADA");  // Precisa mapear explicitamente
```

---

### ? DEPOIS (COM --use-database-names)

**Solução**: Nomes EXATOS do banco de dados

**Classe Gerada**:
```csharp
public partial class TB_CMC_ALCADum  // ? Nome EXATO da tabela
{
    public int ID_ALCADA { get; set; }              // ? Nome EXATO da coluna
    public string? DS_ALCADA { get; set; }          // ? Nome EXATO da coluna
    public string? DS_CATEGORIA_ALCADA { get; set; } // ? Nome EXATO da coluna
}
```

**Mapeamento**:
```csharp
entity.ToTable("TB_CMC_ALCADA");  // ? Nome preservado

entity.Property(e => e.ID_ALCADA);  // ? Nome já está correto
entity.Property(e => e.DS_ALCADA);  // ? Nome já está correto
```

---

## ?? Scripts Atualizados

### ? scaffold-completo.ps1

```powershell
dotnet ef dbcontext scaffold "$ConnectionString" ... \
  --use-database-names `  # ? FLAG ADICIONADA
  --force
```

### ? scaffold-tabela.ps1

```powershell
dotnet ef dbcontext scaffold "$ConnectionString" ... \
  --use-database-names `  # ? FLAG ADICIONADA
  --force
```

---

## ?? Nomenclatura Preservada

### Tabelas
```
TB_CMC_ALCADA
TB_CMC_USUARIO
TB_CMC_GRUPO
TB_CMC_MODULO
TB_CMC_SISTEMA
...
```

### Colunas
```
ID_ALCADA
DS_ALCADA
DS_CATEGORIA_ALCADA
ID_SISTEMA
FL_ATIVO
DT_CADASTRO
...
```

### Classes Geradas
```csharp
TB_CMC_ALCADum.cs
TB_CMC_USUARIO.cs
TB_CMC_GRUPO.cs
TB_CMC_MODULO.cs
TB_CMC_SISTEMA.cs
...
```

---

## ?? Benefícios

### ? Vantagens

1. **Consistência Total** - Nomes em C# = Nomes no Banco
2. **Sem Ambiguidade** - Fácil correlacionar código com SQL
3. **Menos Configuração** - Não precisa mapear explicitamente cada coluna
4. **Queries Claras** - Sabe exatamente qual coluna está sendo usada
5. **Manutenção Fácil** - Qualquer DBA/Dev identifica as colunas

### ?? Desvantagens (Aceitáveis)

1. **Nomenclatura C# Não Convencional** - Propriedades em MAIÚSCULO
2. **Plural de Classes Estranho** - `TB_CMC_ALCADum` (plural de ALCADA)

---

## ?? Recomendações

### ? FAÇA

```csharp
// Use as classes geradas diretamente
var alcada = new TB_CMC_ALCADum
{
    ID_ALCADA = 1,
    DS_ALCADA = "Aprovação Financeira",
    ID_SISTEMA = 10
};

// Query LINQ
var alcadas = context.TB_CMC_ALCADA
    .Where(a => a.FL_ATIVO == true)
    .Select(a => new {
        a.ID_ALCADA,
        a.DS_ALCADA,
        a.ID_SISTEMA
    })
    .ToList();
```

### ? NÃO FAÇA

```csharp
// ? Não crie wrappers/DTOs só para mudar nomenclatura
public class AlcadaDto  // ? Desnecessário
{
    public int IdAlcada { get; set; }  // ? Conversão desnecessária
    // ...
}

// ? Não renomeie as propriedades geradas
public partial class TB_CMC_ALCADum
{
    // ? NÃO faça isso - será sobrescrito no próximo scaffold
    public int IdAlcada => ID_ALCADA;
}
```

### ? SE NECESSÁRIO (DTOs para APIs)

```csharp
// ? Use AutoMapper ou DTOs apenas para APIs externas
public class AlcadaResponseDto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int SistemaId { get; set; }
}

// ? Mapeamento explícito
var response = new AlcadaResponseDto
{
    Id = alcada.ID_ALCADA,
    Descricao = alcada.DS_ALCADA,
    SistemaId = alcada.ID_SISTEMA
};
```

---

## ?? Como Re-Scaffolder com Nomenclatura Correta

### Se Já Tinha Scaffolded Antes

```powershell
# 1. Backup do código atual
git add .
git commit -m "backup antes de re-scaffold com nomenclatura correta"

# 2. Executar scaffold com --use-database-names
.\scripts\scaffold-completo.ps1

# 3. Revisar alterações
git diff

# 4. Atualizar referências no código (se necessário)
# Buscar e substituir:
#   IdAlcada ? ID_ALCADA
#   DsAlcada ? DS_ALCADA
#   etc.

# 5. Compilar
dotnet build

# 6. Commit
git commit -m "refactor: re-scaffold com nomenclatura exata do banco (--use-database-names)"
```

---

## ?? Exemplos Práticos

### Exemplo 1: Query LINQ

```csharp
// Buscar alçadas ativas
var alcadas = await context.TB_CMC_ALCADA
    .Where(a => a.ID_SISTEMA == sistemaId)
    .Select(a => new {
        a.ID_ALCADA,        // ? Nome EXATO da coluna
        a.DS_ALCADA,        // ? Nome EXATO da coluna
        a.DS_CATEGORIA_ALCADA
    })
    .ToListAsync();
```

### Exemplo 2: Insert

```csharp
var novaAlcada = new TB_CMC_ALCADum
{
    DS_ALCADA = "Nova Alçada",                    // ? MAIÚSCULO
    DS_CATEGORIA_ALCADA = "Financeira",           // ? MAIÚSCULO
    DS_OBSERVACAO = "Teste",                      // ? MAIÚSCULO
    ID_SISTEMA = 1                                // ? MAIÚSCULO
};

context.TB_CMC_ALCADA.Add(novaAlcada);
await context.SaveChangesAsync();
```

### Exemplo 3: Update

```csharp
var alcada = await context.TB_CMC_ALCADA
    .FirstOrDefaultAsync(a => a.ID_ALCADA == id);

if (alcada != null)
{
    alcada.DS_ALCADA = "Alçada Atualizada";       // ? MAIÚSCULO
    alcada.DS_OBSERVACAO = "Nova observação";     // ? MAIÚSCULO
    await context.SaveChangesAsync();
}
```

---

## ?? Verificação

### Como Saber se Está Correto

```csharp
// ? Propriedades em MAIÚSCULO com UNDERLINE
public int ID_ALCADA { get; set; }
public string? DS_ALCADA { get; set; }

// ? Se estiver assim, está ERRADO (falta --use-database-names)
public int IdAlcada { get; set; }
public string? DsAlcada { get; set; }
```

### Verificar no DbContext

```csharp
// ? CORRETO - Nomes preservados
modelBuilder.Entity<TB_CMC_ALCADum>(entity =>
{
    entity.ToTable("TB_CMC_ALCADA");
    entity.Property(e => e.ID_ALCADA);     // ? Mesmo nome
    entity.Property(e => e.DS_ALCADA);     // ? Mesmo nome
});
```

---

## ?? Checklist de Validação

Após scaffold, verifique:

- [ ] Nomes de classes em MAIÚSCULO: `TB_CMC_ALCADA`, `TB_CMC_USUARIO`
- [ ] Propriedades em MAIÚSCULO: `ID_ALCADA`, `DS_ALCADA`
- [ ] DbSets preservados: `DbSet<TB_CMC_ALCADA>`
- [ ] Mapeamento sem `.HasColumnName()` explícito
- [ ] Compilação bem-sucedida
- [ ] Queries LINQ funcionando

---

## ?? Conclusão

A flag `--use-database-names` garante que:

? **Nomes de tabelas** permanecem EXATOS  
? **Nomes de colunas** permanecem EXATOS  
? **Mapeamento** é automático e simples  
? **Manutenção** é mais fácil  
? **Correlação código ? banco** é direta  

**Status**: ? Implementado em todos os scripts  
**Data**: 2024  
**Versão**: 1.1
