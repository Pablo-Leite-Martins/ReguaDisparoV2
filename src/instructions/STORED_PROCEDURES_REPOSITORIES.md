# ??? Repositórios de Stored Procedures

## ?? Visão Geral

Todos os acessos a stored procedures foram centralizados em repositórios específicos, garantindo:
- ? Encapsulamento total do acesso a dados
- ? Logging centralizado
- ? Tratamento de exceções padronizado
- ? Testabilidade (via interfaces)
- ? Isolamento de lógica de persistência

---

## ??? Estrutura

```
ReguaDisparo.Infrastructure/
??? Repositories/
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

## ?? Como Usar

### 1?? Corporativo (Fixo)

```csharp
public class MeuServico
{
    private readonly ICorporativoStoredProceduresRepository _corporativoSpRepo;

    public MeuServico(ICorporativoStoredProceduresRepository corporativoSpRepo)
    {
        _corporativoSpRepo = corporativoSpRepo;
    }

    public async Task ProcessarAsync()
    {
        // Listar organizações ativas
        var organizacoes = await _corporativoSpRepo.ListarOrganizacoesAtivasAsync();

        // Buscar organização específica
        var org = await _corporativoSpRepo.BuscarOrganizacaoPorIdAsync("ORG123");

        // Inserir log de ETL
        await _corporativoSpRepo.InserirEtlLogAsync(
            idEtl: 1,
            idOrganizacao: "ORG123",
            descricao: "Processamento concluído",
            tipo: "INFO",
            dataExecucao: DateTime.Now);

        // Atualizar banco CRM
        await _corporativoSpRepo.AtualizarBancoCrmOrganizacaoAsync(
            idOrganizacao: "ORG123",
            nomeBancoCrm: "CLIENTEMAIS_CRM_NOVO");
    }
}
```

### 2?? Controle de Acesso (Fixo)

```csharp
public class AuthService
{
    private readonly IControleAcessoStoredProceduresRepository _controleAcessoSpRepo;

    public AuthService(IControleAcessoStoredProceduresRepository controleAcessoSpRepo)
    {
        _controleAcessoSpRepo = controleAcessoSpRepo;
    }

    public async Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha)
    {
        // Validar login via stored procedure
        var usuario = await _controleAcessoSpRepo.ValidarLoginAsync(login, senha);
        return usuario;
    }

    public async Task<List<TB_CMC_USUARIO>> GetUsuariosOrganizacaoAsync(string orgId)
    {
        // Listar usuários da organização
        return await _controleAcessoSpRepo.ListarUsuariosPorOrganizacaoAsync(orgId);
    }

    public async Task<List<TB_CMC_GRUPO>> GetGruposSistemaAsync(int idSistema)
    {
        // Listar grupos do sistema
        return await _controleAcessoSpRepo.ListarGruposPorSistemaAsync(idSistema);
    }

    public async Task CriarUsuarioAsync(string login, string nome, string email, string senha, string orgId)
    {
        // Inserir novo usuário
        await _controleAcessoSpRepo.InserirUsuarioAsync(
            login: login,
            nome: nome,
            email: email,
            senha: senha,
            idOrganizacao: orgId,
            administrador: false);
    }
}
```

### 3?? ClienteMais (Multi-Tenant) ??

**IMPORTANTE**: O repositório ClienteMais NÃO é registrado no DI. Você deve criá-lo manualmente via Factory.

```csharp
public class ReguaCobrancaService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILogger<ClienteMaisStoredProceduresRepository> _logger;

    public ReguaCobrancaService(
        ITenantDbContextFactory tenantFactory,
        ILogger<ClienteMaisStoredProceduresRepository> logger)
    {
        _tenantFactory = tenantFactory;
        _logger = logger;
    }

    public async Task ProcessarReguaAsync(string organizationId)
    {
        // 1. Criar DbContext para a organização
        using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

        // 2. Criar repositório de stored procedures manualmente
        var spRepo = new ClienteMaisStoredProceduresRepository(crmDb, _logger);

        // 3. Usar o repositório
        var propostas = await spRepo.ListarPropostasVencidasAsync(
            dataReferencia: DateTime.Now,
            diasAposVencimento: 30);

        foreach (var proposta in propostas)
        {
            // Processar proposta...

            // Registrar histórico de envio
            await spRepo.InserirHistoricoEnvioAsync(
                idProposta: proposta.ID_PROPOSTA,
                idAcao: 1,
                tipoEnvio: "EMAIL",
                destinatarioEmail: "cliente@email.com",
                destinatarioTelefone: "11999999999",
                mensagem: "Email de cobrança enviado",
                enviado: true,
                mensagemErro: null);
        }
    }

    public async Task ConsultarDadosClienteAsync(string organizationId)
    {
        using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);
        var spRepo = new ClienteMaisStoredProceduresRepository(crmDb, _logger);

        // Listar tipos de documentos
        var tiposDocumento = await spRepo.ListarTiposDocumentoAsync();

        // Listar produtos ativos
        var produtos = await spRepo.ListarProdutosAtivosAsync();

        // Listar contratos ativos
        var contratos = await spRepo.ListarContratosAtivosAsync();

        // Listar documentos de um caso
        var documentos = await spRepo.ListarDocumentosPorCasoAsync(idCaso: 123);
    }
}
```

---

## ?? Métodos Disponíveis

### CorporativoStoredProceduresRepository

| Método | Stored Procedure | Descrição |
|--------|------------------|-----------|
| `ListarOrganizacoesAtivasAsync()` | SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS | Lista organizações ativas |
| `BuscarOrganizacaoPorIdAsync(id)` | SP_CMCORP_ORGANIZACAO_BUSCAR_POR_ID | Busca organização por ID |
| `InserirEtlLogAsync(...)` | SP_CMCORP_ETL_LOG_INSERIR | Insere log de ETL |
| `AtualizarBancoCrmOrganizacaoAsync(...)` | SP_CMCORP_ORGANIZACAO_ATUALIZAR_BANCO_CRM | Atualiza banco CRM |

### ControleAcessoStoredProceduresRepository

| Método | Stored Procedure | Descrição |
|--------|------------------|-----------|
| `ValidarLoginAsync(login, senha)` | SP_CMC_USUARIO_VALIDAR_LOGIN | Valida login de usuário |
| `ListarUsuariosPorOrganizacaoAsync(orgId)` | SP_CMC_USUARIO_LISTAR_POR_ORGANIZACAO | Lista usuários da organização |
| `ListarGruposPorSistemaAsync(idSistema)` | SP_CMC_GRUPO_LISTAR_POR_SISTEMA | Lista grupos do sistema |
| `InserirUsuarioAsync(...)` | SP_CMC_USUARIO_INSERIR | Insere novo usuário |

### ClienteMaisStoredProceduresRepository

| Método | Stored Procedure | Descrição |
|--------|------------------|-----------|
| `ListarPropostasVencidasAsync(...)` | SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS | Lista propostas vencidas |
| `ListarCasosPorTipoAsync(idTipo)` | SP_CMCRM_CASO_LISTAR_POR_TIPO | Lista casos por tipo |
| `InserirHistoricoEnvioAsync(...)` | SP_CMCRM_HISTORICO_ENVIO_INSERIR | Registra envio de cobrança |
| `ListarTiposDocumentoAsync()` | SP_CMCRM_LISTARTIPODOCUMENTO | Lista tipos de documento |
| `ListarProdutosAtivosAsync()` | SP_CMCRM_PRODUTO_LISTAR_ATIVOS | Lista produtos ativos |
| `ListarContratosAtivosAsync()` | SP_CMCRM_CONTRATO_LISTAR_ATIVOS | Lista contratos ativos |
| `ListarDocumentosPorCasoAsync(idCaso)` | SP_CMCRM_DOCUMENTO_LISTAR_POR_CASO | Lista documentos de caso |

---

## ? Benefícios

### Encapsulamento
- Todo acesso a stored procedures está isolado em repositórios
- DbContexts não expõem métodos de execução de SP

### Logging Centralizado
- Todos os repositórios incluem logging detalhado
- Fácil rastreamento de execuções de procedures

### Testabilidade
- Interfaces permitem mock fácil em testes
- Testes unitários podem testar lógica sem acessar banco

### Manutenibilidade
- Mudanças em procedures afetam apenas os repositórios
- Camadas superiores não conhecem detalhes de implementação

### Tratamento de Erros
- Exceções são capturadas e logadas
- Possibilidade de adicionar retry policies

---

## ?? Padrão de Implementação

Todos os repositórios seguem o mesmo padrão:

```csharp
public async Task<Result> MetodoAsync(parametros)
{
    try
    {
        // 1. Log de debug
        _logger.LogDebug("Executando SP_NOME para {Param}", param);

        // 2. Criar parâmetros SQL
        var parameters = new[] { ... };

        // 3. Executar stored procedure
        var result = await _context.TABELA
            .FromSqlRaw("EXEC SP_NOME @PARAM", parameters)
            .AsNoTracking() // Para SELECT
            .ToListAsync();

        // 4. Log de sucesso
        _logger.LogInformation("SP_NOME retornou {Count} registros", result.Count);

        // 5. Retornar resultado
        return result;
    }
    catch (Exception ex)
    {
        // 6. Log de erro
        _logger.LogError(ex, "Erro ao executar SP_NOME");
        throw;
    }
}
```

---

## ?? Importante

### Contextos Fixos (Corporativo, ControleAcesso)
? Injetados via DI normalmente
```csharp
public MeuServico(ICorporativoStoredProceduresRepository spRepo) { }
```

### Contexto Multi-Tenant (ClienteMais)
? NÃO injetar via DI
? Criar manualmente via Factory
```csharp
using var crmDb = await _tenantFactory.CreateDbContextAsync(orgId);
var spRepo = new ClienteMaisStoredProceduresRepository(crmDb, _logger);
```

---

## ?? Referências

- ?? [MULTITENANT_GUIDE.md](MULTITENANT_GUIDE.md) - Guia Multi-Tenant
- ?? [MULTIPLE_DBCONTEXTS.md](MULTIPLE_DBCONTEXTS.md) - Múltiplos DbContexts

---

**Status**: ? Repositórios de Procedures Implementados  
**Padrão**: Todo acesso a stored procedures centralizado em repositórios  
**Compilação**: ? Bem-sucedida
