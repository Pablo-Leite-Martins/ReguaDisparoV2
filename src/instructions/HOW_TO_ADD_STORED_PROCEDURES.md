# ?? GUIA - Como Adicionar Stored Procedures aos Repositórios

## ?? IMPORTANTE

**NÃO INVENTE PROCEDURES!** Adicione apenas procedures que **realmente existem** no banco de dados.

---

## ?? Como Verificar Procedures Existentes

### No SQL Server Management Studio (SSMS):

```sql
-- Listar todas as procedures de um banco
SELECT 
    SCHEMA_NAME(schema_id) AS [Schema],
    name AS [Procedure Name],
    create_date AS [Created],
    modify_date AS [Modified]
FROM sys.procedures
WHERE name LIKE 'SP_%'
ORDER BY name;

-- Ver detalhes de uma procedure específica
sp_helptext 'SP_NOME_DA_PROCEDURE';

-- Ver parâmetros de uma procedure
SELECT 
    p.name AS [Parameter],
    TYPE_NAME(p.user_type_id) AS [Type],
    p.max_length AS [Length],
    p.is_output AS [IsOutput]
FROM sys.parameters p
WHERE p.object_id = OBJECT_ID('SP_NOME_DA_PROCEDURE')
ORDER BY p.parameter_id;
```

---

## ?? Como Adicionar uma Procedure

### Passo 1: Verificar a Procedure no Banco

1. Conecte ao banco de dados correspondente:
   - `CLIENTEMAIS_CORPORATIVO` ? CorporativoStoredProceduresRepository
   - `CLIENTEMAIS_CONTROLE_ACESSO` ? ControleAcessoStoredProceduresRepository
   - `CLIENTEMAIS_CRM_*` ? ClienteMaisStoredProceduresRepository

2. Execute:
```sql
sp_helptext 'SP_NOME_DA_PROCEDURE'
```

3. Anote:
   - Nome exato da procedure
   - Parâmetros de entrada
   - O que ela retorna (tabela, scalar, nada)

### Passo 2: Adicionar na Interface

**Arquivo**: `I{Nome}StoredProceduresRepository.cs`

```csharp
/// <summary>
/// SP_NOME_DA_PROCEDURE
/// Descrição do que a procedure faz
/// </summary>
Task<TipoRetorno> NomeMetodoAsync(parametros);
```

**Exemplo Real**:
```csharp
/// <summary>
/// SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS
/// Lista organizações ativas com banco CRM configurado
/// </summary>
Task<List<TB_CMCORP_ORGANIZACAO>> ListarOrganizacoesAtivasAsync();
```

### Passo 3: Implementar no Repositório

**Arquivo**: `{Nome}StoredProceduresRepository.cs`

```csharp
public async Task<TipoRetorno> NomeMetodoAsync(parametros)
{
    try
    {
        _logger.LogDebug("Executando SP_NOME_DA_PROCEDURE para {Param}", param);

        // Se tiver parâmetros
        var parameters = new[]
        {
            new SqlParameter("@PARAMETRO", valor)
        };

        // Se retornar tabela (SELECT)
        var result = await _context.TB_TABELA
            .FromSqlRaw("EXEC SP_NOME_DA_PROCEDURE @PARAMETRO", parameters)
            .AsNoTracking()
            .ToListAsync(); // ou .FirstOrDefaultAsync() se for único

        _logger.LogInformation("SP_NOME_DA_PROCEDURE retornou {Count} registros", result.Count);
        
        return result;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro ao executar SP_NOME_DA_PROCEDURE");
        throw;
    }
}
```

**Para INSERT/UPDATE/DELETE** (não retorna tabela):
```csharp
var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
    "EXEC SP_NOME_DA_PROCEDURE @PARAMETRO",
    parameters);
```

---

## ?? Exemplos Práticos

### Exemplo 1: SELECT que retorna lista

**Procedure no banco**:
```sql
CREATE PROCEDURE SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS
AS
BEGIN
    SELECT * FROM TB_CMCORP_ORGANIZACAO 
    WHERE FL_ATIVO = 1 AND NOME_BANCO_CRM IS NOT NULL
END
```

**Interface**:
```csharp
Task<List<TB_CMCORP_ORGANIZACAO>> ListarOrganizacoesAtivasAsync();
```

**Implementação**:
```csharp
public async Task<List<TB_CMCORP_ORGANIZACAO>> ListarOrganizacoesAtivasAsync()
{
    try
    {
        _logger.LogDebug("Executando SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS");

        var result = await _context.TB_CMCORP_ORGANIZACAOs
            .FromSqlRaw("EXEC SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS")
            .AsNoTracking()
            .ToListAsync();

        _logger.LogInformation("SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS retornou {Count} registros", result.Count);
        
        return result;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro ao executar SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS");
        throw;
    }
}
```

### Exemplo 2: SELECT com parâmetro

**Procedure no banco**:
```sql
CREATE PROCEDURE SP_CMC_USUARIO_VALIDAR_LOGIN
    @DS_LOGIN VARCHAR(100),
    @DS_SENHA VARCHAR(100)
AS
BEGIN
    SELECT * FROM TB_CMC_USUARIO 
    WHERE DS_LOGIN = @DS_LOGIN 
      AND DS_SENHA = @DS_SENHA 
      AND FL_ATIVO = 1
END
```

**Interface**:
```csharp
Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha);
```

**Implementação**:
```csharp
public async Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha)
{
    try
    {
        _logger.LogDebug("Executando SP_CMC_USUARIO_VALIDAR_LOGIN para login {Login}", login);

        var parameters = new[]
        {
            new SqlParameter("@DS_LOGIN", login),
            new SqlParameter("@DS_SENHA", senha)
        };

        var result = await _context.TB_CMC_USUARIOs
            .FromSqlRaw("EXEC SP_CMC_USUARIO_VALIDAR_LOGIN @DS_LOGIN, @DS_SENHA", parameters)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (result != null)
        {
            _logger.LogInformation("Login validado com sucesso para {Login}", login);
        }
        else
        {
            _logger.LogWarning("Falha na validação de login para {Login}", login);
        }

        return result;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro ao executar SP_CMC_USUARIO_VALIDAR_LOGIN para {Login}", login);
        throw;
    }
}
```

### Exemplo 3: INSERT/UPDATE (não retorna tabela)

**Procedure no banco**:
```sql
CREATE PROCEDURE SP_CMCORP_ETL_LOG_INSERIR
    @ID_ETL INT,
    @ID_ORGANIZACAO VARCHAR(50),
    @DS_DESCRICAO VARCHAR(500),
    @DS_TIPO VARCHAR(50),
    @DT_EXECUCAO DATETIME
AS
BEGIN
    INSERT INTO TB_CMCORP_ETL_LOG 
        (ID_ETL, ID_ORGANIZACAO, DS_DESCRICAO, DS_TIPO, DT_EXECUCAO)
    VALUES 
        (@ID_ETL, @ID_ORGANIZACAO, @DS_DESCRICAO, @DS_TIPO, @DT_EXECUCAO)
END
```

**Interface**:
```csharp
Task<int> InserirEtlLogAsync(
    int idEtl,
    string idOrganizacao,
    string descricao,
    string tipo,
    DateTime dataExecucao);
```

**Implementação**:
```csharp
public async Task<int> InserirEtlLogAsync(
    int idEtl,
    string idOrganizacao,
    string descricao,
    string tipo,
    DateTime dataExecucao)
{
    try
    {
        _logger.LogDebug("Executando SP_CMCORP_ETL_LOG_INSERIR para ETL {IdEtl}, Org {IdOrganizacao}", 
            idEtl, idOrganizacao);

        var parameters = new[]
        {
            new SqlParameter("@ID_ETL", idEtl),
            new SqlParameter("@ID_ORGANIZACAO", idOrganizacao),
            new SqlParameter("@DS_DESCRICAO", descricao),
            new SqlParameter("@DS_TIPO", tipo),
            new SqlParameter("@DT_EXECUCAO", dataExecucao)
        };

        var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
            "EXEC SP_CMCORP_ETL_LOG_INSERIR @ID_ETL, @ID_ORGANIZACAO, @DS_DESCRICAO, @DS_TIPO, @DT_EXECUCAO",
            parameters);

        _logger.LogInformation("SP_CMCORP_ETL_LOG_INSERIR executada com sucesso. Linhas afetadas: {Rows}", rowsAffected);

        return rowsAffected;
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erro ao executar SP_CMCORP_ETL_LOG_INSERIR");
        throw;
    }
}
```

---

## ? Checklist Antes de Adicionar

- [ ] Verifiquei que a procedure **existe** no banco de dados
- [ ] Verifiquei o nome **exato** da procedure
- [ ] Identifiquei todos os **parâmetros** e seus tipos
- [ ] Identifiquei o **tipo de retorno** (tabela, scalar, nada)
- [ ] Adicionei na **interface** primeiro
- [ ] Implementei no **repositório** com try/catch
- [ ] Adicionei **logging** (Debug no início, Info/Warning no final)
- [ ] Usei `.AsNoTracking()` para SELECT (performance)
- [ ] Compilei e testei

---

## ?? O Que NÃO Fazer

? **NÃO** crie procedures que não existem  
? **NÃO** adivinhe nomes de procedures  
? **NÃO** adivinhe parâmetros  
? **NÃO** esqueça o try/catch  
? **NÃO** esqueça o logging  
? **NÃO** esqueça `.AsNoTracking()` em SELECTs  

---

## ?? Arquivos dos Repositórios

```
ReguaDisparo.Infrastructure/Repositories/
??? Corporativo/
?   ??? ICorporativoStoredProceduresRepository.cs
?   ??? CorporativoStoredProceduresRepository.cs
??? ControleAcesso/
?   ??? IControleAcessoStoredProceduresRepository.cs
?   ??? ControleAcessoStoredProceduresRepository.cs
??? ClienteMais/
    ??? IClienteMaisStoredProceduresRepository.cs
    ??? ClienteMaisStoredProceduresRepository.cs
```

---

**Status**: ? Repositórios Limpos e Prontos para Receber Procedures Reais  
**Próximo Passo**: Adicionar apenas procedures que **existem** no banco de dados
