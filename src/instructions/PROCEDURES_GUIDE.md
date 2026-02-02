# ??? Guia de Uso - Procedures nos DbContexts

## ?? Visão Geral

As procedures SQL foram integradas diretamente nos DbContexts como métodos, permitindo acesso direto e tipado.

---

## ? Como Usar

### Exemplo 1: CorporativoDbContext

```csharp
public class MeuServico
{
    private readonly CorporativoDbContext _corporativoDb;

    public async Task ProcessarAsync()
    {
        // Listar organizações ativas
        var organizacoes = await _corporativoDb.CMCORP_sp_organizacao_listar_ativas();

        // Buscar organização por ID
        var org = await _corporativoDb.CMCORP_sp_organizacao_buscar_por_id("ORG123");

        // Inserir log de ETL
        await _corporativoDb.CMCORP_sp_etl_log_inserir(
            idEtl: 1,
            idOrganizacao: "ORG123",
            descricao: "Processamento concluído",
            tipo: "INFO",
            dataExecucao: DateTime.Now);
    }
}
```

### Exemplo 2: ControleAcessoDbContext

```csharp
public class AuthService
{
    private readonly ControleAcessoDbContext _controleAcessoDb;

    public async Task<TB_CMC_USUARIO?> ValidarLoginAsync(string login, string senha)
    {
        // Validar login
        var usuario = await _controleAcessoDb.CMC_sp_usuario_validar_login(login, senha);

        return usuario;
    }

    public async Task<List<TB_CMC_USUARIO>> GetUsuariosPorOrganizacaoAsync(string orgId)
    {
        // Listar usuários da organização
        return await _controleAcessoDb.CMC_sp_usuario_listar_por_organizacao(orgId);
    }
}
```

### Exemplo 3: ClienteMaisDbContext (Multi-Tenant)

```csharp
public class ReguaCobrancaService
{
    private readonly ITenantDbContextFactory _tenantFactory;

    public async Task ProcessarAsync(string organizationId)
    {
        // Criar contexto para a organização
        using var crmDb = await _tenantFactory.CreateDbContextAsync(organizationId);

        // Listar propostas vencidas
        var propostas = await crmDb.CMCRM_sp_proposta_listar_vencidas(
            dataReferencia: DateTime.Now,
            diasAposVencimento: 30);

        // Listar casos de cobrança
        var casos = await crmDb.CMCRM_sp_caso_listar_por_tipo(idTipoCaso: 1);

        // Registrar histórico de envio
        await crmDb.CMCRM_sp_historico_envio_inserir(
            idProposta: 123,
            idAcao: 1,
            tipoEnvio: "EMAIL",
            destinatarioEmail: "cliente@email.com",
            destinatarioTelefone: "11999999999",
            mensagem: "Email enviado",
            enviado: true,
            mensagemErro: null);
    }
}
```

---

## ?? Procedures Disponíveis

### CorporativoDbContext

| Procedure | Método | Descrição |
|-----------|--------|-----------|
| SP_CMCORP_ORGANIZACAO_LISTAR_ATIVAS | `CMCORP_sp_organizacao_listar_ativas()` | Lista organizações ativas |
| SP_CMCORP_ORGANIZACAO_BUSCAR_POR_ID | `CMCORP_sp_organizacao_buscar_por_id(id)` | Busca organização por ID |
| SP_CMCORP_ETL_LOG_INSERIR | `CMCORP_sp_etl_log_inserir(...)` | Insere log de ETL |
| SP_CMCORP_ORGANIZACAO_ATUALIZAR_BANCO_CRM | `CMCORP_sp_organizacao_atualizar_banco_crm(...)` | Atualiza banco CRM |

### ControleAcessoDbContext

| Procedure | Método | Descrição |
|-----------|--------|-----------|
| SP_CMC_USUARIO_VALIDAR_LOGIN | `CMC_sp_usuario_validar_login(login, senha)` | Valida login |
| SP_CMC_USUARIO_LISTAR_POR_ORGANIZACAO | `CMC_sp_usuario_listar_por_organizacao(orgId)` | Lista usuários |
| SP_CMC_GRUPO_LISTAR_POR_SISTEMA | `CMC_sp_grupo_listar_por_sistema(idSistema)` | Lista grupos |
| SP_CMC_USUARIO_INSERIR | `CMC_sp_usuario_inserir(...)` | Insere usuário |

### ClienteMaisDbContext

| Procedure | Método | Descrição |
|-----------|--------|-----------|
| SP_CMCRM_PROPOSTA_LISTAR_VENCIDAS | `CMCRM_sp_proposta_listar_vencidas(...)` | Lista propostas vencidas |
| SP_CMCRM_CASO_LISTAR_POR_TIPO | `CMCRM_sp_caso_listar_por_tipo(idTipo)` | Lista casos por tipo |
| SP_CMCRM_HISTORICO_ENVIO_INSERIR | `CMCRM_sp_historico_envio_inserir(...)` | Registra envio |
| SP_CMCRM_LISTARTIPODOCUMENTO | `CMCRM_sp_listartipodocumento()` | Lista tipos de documento |
| SP_CMCRM_PRODUTO_LISTAR_ATIVOS | `CMCRM_sp_produto_listar_ativos()` | Lista produtos ativos |
| SP_CMCRM_CONTRATO_LISTAR_ATIVOS | `CMCRM_sp_contrato_listar_ativos()` | Lista contratos ativos |
| SP_CMCRM_DOCUMENTO_LISTAR_POR_CASO | `CMCRM_sp_documento_listar_por_caso(idCaso)` | Lista documentos |

---

## ?? Adicionar Novas Procedures

Para adicionar uma nova procedure, edite o arquivo `*.Procedures.cs` correspondente:

```csharp
// ReguaDisparo.Infrastructure/Data/Generated/ClienteMais/ClienteMaisDbContext.Procedures.cs

public partial class ClienteMaisDbContext
{
    /// <summary>
    /// SP_CMCRM_MINHA_NOVA_PROCEDURE
    /// </summary>
    public async Task<List<TB_CMCRM_TABELA>> CMCRM_sp_minha_nova_procedure(int parametro)
    {
        var param = new SqlParameter("@PARAMETRO", parametro);

        return await TB_CMCRM_TABELAs
            .FromSqlRaw("EXEC SP_CMCRM_MINHA_NOVA_PROCEDURE @PARAMETRO", param)
            .ToListAsync();
    }
}
```

---

**Status**: ? Procedures Integradas nos Contextos  
**Uso**: Acesso direto via `_context.NOME_sp_procedure(...)`
