# ?? Guia Prático - Implementação dos Próximos Passos

## ?? Visão Geral

Este guia fornece exemplos práticos e código de referência para implementar as próximas fases da migração.

---

## 1?? Implementar Repositórios com Dapper

### Instalar Pacote NuGet

```bash
cd ReguaDisparo.Infrastructure
dotnet add package Dapper
dotnet add package Microsoft.Data.SqlClient
```

### Atualizar ReguaDisparo.Infrastructure.csproj

```xml
<ItemGroup>
  <PackageReference Include="Dapper" Version="2.1.35" />
  <PackageReference Include="Microsoft.Data.SqlClient" Version="5.2.1" />
</ItemGroup>
```

### Criar Base Repository

```csharp
// ReguaDisparo.Infrastructure/Repositories/BaseRepository.cs
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ReguaDisparo.Infrastructure.Repositories;

public abstract class BaseRepository
{
    private readonly IConfiguration _configuration;

    protected BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected SqlConnection CreateConnection(string? databaseName = null)
    {
        var connectionString = databaseName != null
            ? GetConnectionStringForDatabase(databaseName)
            : _configuration.GetConnectionString("DefaultConnection");

        return new SqlConnection(connectionString);
    }

    private string GetConnectionStringForDatabase(string databaseName)
    {
        var baseConnectionString = _configuration.GetConnectionString("DefaultConnection");
        var builder = new SqlConnectionStringBuilder(baseConnectionString)
        {
            InitialCatalog = databaseName
        };
        return builder.ConnectionString;
    }
}
```

### Implementar OrganizationRepository

```csharp
// ReguaDisparo.Infrastructure/Repositories/OrganizationRepository.cs
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities;

namespace ReguaDisparo.Infrastructure.Repositories;

public class OrganizationRepository : BaseRepository, IOrganizationRepository
{
    private readonly ILogger<OrganizationRepository> _logger;

    public OrganizationRepository(
        ILogger<OrganizationRepository> logger,
        IConfiguration configuration)
        : base(configuration)
    {
        _logger = logger;
    }

    public async Task<List<Organization>> GetActiveOrganizationsAsync()
    {
        try
        {
            const string sql = @"
                SELECT 
                    ID_ORGANIZACAO as Id,
                    DS_NOME_FANTASIA as NomeFantasia,
                    DS_RAZAO_SOCIAL as RazaoSocial,
                    NOME_BANCO_CRM as NomeBancoCRM,
                    FL_ATIVO as Ativa,
                    DT_CADASTRO as DataCadastro,
                    DT_ATUALIZACAO as DataAtualizacao
                FROM ORGANIZACAO
                WHERE FL_ATIVO = 1
                  AND NOME_BANCO_CRM IS NOT NULL
                  AND NOME_BANCO_CRM <> ''
                ORDER BY DS_NOME_FANTASIA";

            using var connection = CreateConnection();
            var organizations = await connection.QueryAsync<Organization>(sql);
            var list = organizations.ToList();

            _logger.LogInformation("Encontradas {Count} organizações ativas", list.Count);
            return list;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar organizações ativas");
            throw;
        }
    }

    public async Task<Organization?> GetByIdAsync(string organizationId)
    {
        try
        {
            const string sql = @"
                SELECT 
                    ID_ORGANIZACAO as Id,
                    DS_NOME_FANTASIA as NomeFantasia,
                    DS_RAZAO_SOCIAL as RazaoSocial,
                    NOME_BANCO_CRM as NomeBancoCRM,
                    FL_ATIVO as Ativa,
                    DT_CADASTRO as DataCadastro,
                    DT_ATUALIZACAO as DataAtualizacao
                FROM ORGANIZACAO
                WHERE ID_ORGANIZACAO = @OrganizationId";

            using var connection = CreateConnection();
            var organization = await connection.QueryFirstOrDefaultAsync<Organization>(
                sql,
                new { OrganizationId = organizationId });

            return organization;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar organização {OrganizationId}", organizationId);
            throw;
        }
    }
}
```

### Implementar ReguaCobrancaRepository

```csharp
// ReguaDisparo.Infrastructure/Repositories/ReguaCobrancaRepository.cs
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities;

namespace ReguaDisparo.Infrastructure.Repositories;

public class ReguaCobrancaRepository : BaseRepository, IReguaCobrancaRepository
{
    private readonly ILogger<ReguaCobrancaRepository> _logger;

    public ReguaCobrancaRepository(
        ILogger<ReguaCobrancaRepository> logger,
        IConfiguration configuration)
        : base(configuration)
    {
        _logger = logger;
    }

    public async Task<List<ReguaCobranca>> GetActiveReguasAsync(string databaseName)
    {
        try
        {
            const string sql = @"
                SELECT 
                    ID_CASO_COBRANCA_REGUA as Id,
                    DS_DESCRICAO as Descricao,
                    FL_ATIVO as Ativa,
                    DT_CADASTRO as DataCadastro
                FROM CASO_COBRANCA_REGUA
                WHERE FL_ATIVO = 1
                ORDER BY ID_CASO_COBRANCA_REGUA";

            using var connection = CreateConnection(databaseName);
            var reguas = await connection.QueryAsync<ReguaCobranca>(sql);
            var list = reguas.ToList();

            _logger.LogInformation("Encontradas {Count} réguas ativas no database {Database}", 
                list.Count, databaseName);
            return list;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar réguas ativas no database {Database}", databaseName);
            throw;
        }
    }

    public async Task<List<ReguaCobrancaEtapa>> GetEtapasByReguaAsync(int reguaId, string databaseName)
    {
        try
        {
            const string sql = @"
                SELECT 
                    ID_CASO_COBRANCA_REGUA_ETAPA as Id,
                    ID_CASO_COBRANCA_REGUA as ReguaCobrancaId,
                    DS_DESCRICAO as Descricao,
                    NR_ORDEM as Ordem,
                    NR_DIAS_APOS_VENCIMENTO as DiasAposVencimento,
                    FL_ATIVO as Ativa
                FROM CASO_COBRANCA_REGUA_ETAPA
                WHERE ID_CASO_COBRANCA_REGUA = @ReguaId
                  AND FL_ATIVO = 1
                ORDER BY NR_ORDEM";

            using var connection = CreateConnection(databaseName);
            var etapas = await connection.QueryAsync<ReguaCobrancaEtapa>(
                sql,
                new { ReguaId = reguaId });

            return etapas.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar etapas da régua {ReguaId} no database {Database}", 
                reguaId, databaseName);
            throw;
        }
    }

    public async Task<List<ReguaCobrancaEtapaAcao>> GetAcoesByEtapaAsync(int etapaId, string databaseName)
    {
        try
        {
            const string sql = @"
                SELECT 
                    ID_CASO_COBRANCA_REGUA_ETAPA_ACAO as Id,
                    ID_CASO_COBRANCA_REGUA_ETAPA as EtapaId,
                    DS_TIPO_ACAO as TipoAcao,
                    DS_DESCRICAO as Descricao,
                    FL_ACAO_AGENDADA as AcaoAgendada,
                    ID_TEMPLATE as TemplateId,
                    FL_ATIVO as Ativa
                FROM CASO_COBRANCA_REGUA_ETAPA_ACAO
                WHERE ID_CASO_COBRANCA_REGUA_ETAPA = @EtapaId
                  AND FL_ATIVO = 1
                ORDER BY ID_CASO_COBRANCA_REGUA_ETAPA_ACAO";

            using var connection = CreateConnection(databaseName);
            var acoes = await connection.QueryAsync<ReguaCobrancaEtapaAcao>(
                sql,
                new { EtapaId = etapaId });

            return acoes.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ações da etapa {EtapaId} no database {Database}", 
                etapaId, databaseName);
            throw;
        }
    }

    public async Task SaveHistoricoEnvioAsync(ReguaCobrancaHistoricoEnvio historico, string databaseName)
    {
        try
        {
            const string sql = @"
                INSERT INTO CASO_COBRANCA_REGUA_HISTORICO_ENVIO
                (
                    ID_CASO_COBRANCA_REGUA_ETAPA_ACAO,
                    DS_EMAIL_DESTINATARIO,
                    DS_TELEFONE_DESTINATARIO,
                    DT_ENVIO,
                    FL_ENVIADO,
                    DS_MENSAGEM_ERRO,
                    DS_TIPO_ENVIO
                )
                VALUES
                (
                    @AcaoId,
                    @DestinatarioEmail,
                    @DestinatarioTelefone,
                    @DataEnvio,
                    @Enviado,
                    @MensagemErro,
                    @TipoEnvio
                )";

            using var connection = CreateConnection(databaseName);
            await connection.ExecuteAsync(sql, historico);

            _logger.LogDebug("Histórico de envio salvo para ação {AcaoId}", historico.AcaoId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao salvar histórico de envio no database {Database}", databaseName);
            throw;
        }
    }
}
```

### Atualizar IoC para Injetar IConfiguration

```csharp
// ReguaDisparo.IoC/ApplicationServiceCollectionExtensions.cs
public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
{
    // ... código existente ...

    // Infrastructure Repositories (agora recebem IConfiguration)
    services.AddScoped<IOrganizationRepository>(sp => 
        new OrganizationRepository(
            sp.GetRequiredService<ILogger<OrganizationRepository>>(),
            configuration));
    
    services.AddScoped<IReguaCobrancaRepository>(sp =>
        new ReguaCobrancaRepository(
            sp.GetRequiredService<ILogger<ReguaCobrancaRepository>>(),
            configuration));

    return services;
}
```

---

## 2?? Implementar Serviço de Configuração

### Criar Interface

```csharp
// ReguaDisparo.Core/Interfaces/IConfigGeralRepository.cs
using ReguaDisparo.Domain.Entities;

namespace ReguaDisparo.Core.Interfaces;

public interface IConfigGeralRepository
{
    Task<ConfigGeral?> GetConfigGeralAsync(string databaseName);
}
```

### Implementar Repository

```csharp
// ReguaDisparo.Infrastructure/Repositories/ConfigGeralRepository.cs
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities;

namespace ReguaDisparo.Infrastructure.Repositories;

public class ConfigGeralRepository : BaseRepository, IConfigGeralRepository
{
    private readonly ILogger<ConfigGeralRepository> _logger;

    public ConfigGeralRepository(
        ILogger<ConfigGeralRepository> logger,
        IConfiguration configuration)
        : base(configuration)
    {
        _logger = logger;
    }

    public async Task<ConfigGeral?> GetConfigGeralAsync(string databaseName)
    {
        try
        {
            const string sql = @"
                SELECT TOP 1
                    ID_CONFIG_GERAL as Id,
                    FL_COB_DISPARAR_EMAIL_COBRANCA_FIM_DE_SEMANA as DispararEmailCobrancaFimDeSemana,
                    FL_HABILITAR_ENVIO_EMAIL as HabilitarEnvioEmail,
                    FL_HABILITAR_ENVIO_SMS as HabilitarEnvioSMS,
                    FL_HABILITAR_ENVIO_WHATSAPP as HabilitarEnvioWhatsApp,
                    NR_LIMITE_ENVIO_EMAIL_DIARIO as LimiteEnvioEmailDiario,
                    NR_LIMITE_ENVIO_SMS_DIARIO as LimiteEnvioSMSDiario,
                    DS_EMAIL_REMETENTE as EmailRemetente,
                    DS_NOME_REMETENTE as NomeRemetente
                FROM CONFIG_GERAL";

            using var connection = CreateConnection(databaseName);
            var config = await connection.QueryFirstOrDefaultAsync<ConfigGeral>(sql);

            return config;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar configuração geral do database {Database}", databaseName);
            throw;
        }
    }
}
```

### Usar no Orchestrator

```csharp
// ReguaDisparo.Core/Services/NotificationOrchestrator.cs
private readonly IConfigGeralRepository _configRepository;

public async Task ProcessCompanyAsync(string companyId)
{
    var organization = await _organizationRepository.GetByIdAsync(companyId);
    if (organization == null) return;

    // Buscar configuração da organização
    var config = await _configRepository.GetConfigGeralAsync(organization.NomeBancoCRM);
    
    // Verificar se processa em fim de semana
    var hoje = DateTime.Now.DayOfWeek;
    if ((hoje == DayOfWeek.Saturday || hoje == DayOfWeek.Sunday) 
        && !config?.DispararEmailCobrancaFimDeSemana == true)
    {
        _logger.LogInformation("Pulando processamento de {Company} - Fim de semana desabilitado", 
            organization.NomeFantasia);
        return;
    }

    await ProcessReguasCobrancaAsync(organization, config);
}
```

---

## 3?? Implementar Template Service

### Criar Interface

```csharp
// ReguaDisparo.Core/Interfaces/ITemplateService.cs
namespace ReguaDisparo.Core.Interfaces;

public interface ITemplateService
{
    Task<string> GetTemplateContentAsync(int templateId, string databaseName);
    string ReplaceVariables(string template, Dictionary<string, string> variables);
}
```

### Implementar Service

```csharp
// ReguaDisparo.Core/Services/TemplateService.cs
using ReguaDisparo.Core.Interfaces;
using System.Text.RegularExpressions;

namespace ReguaDisparo.Core.Services;

public class TemplateService : ITemplateService
{
    public async Task<string> GetTemplateContentAsync(int templateId, string databaseName)
    {
        // TODO: Buscar template do banco de dados
        await Task.CompletedTask;
        return string.Empty;
    }

    public string ReplaceVariables(string template, Dictionary<string, string> variables)
    {
        var result = template;

        foreach (var variable in variables)
        {
            // Substituir {NomeCliente}, {ValorParcela}, etc.
            var pattern = $@"\{{{variable.Key}\}}";
            result = Regex.Replace(result, pattern, variable.Value, RegexOptions.IgnoreCase);
        }

        return result;
    }
}
```

### Exemplo de Uso

```csharp
var variables = new Dictionary<string, string>
{
    { "NomeCliente", "João Silva" },
    { "ValorParcela", "R$ 500,00" },
    { "DataVencimento", "15/01/2024" },
    { "NumeroParcela", "5" }
};

var template = "Olá {NomeCliente}, sua parcela {NumeroParcela} no valor de {ValorParcela} vence em {DataVencimento}.";
var mensagem = _templateService.ReplaceVariables(template, variables);
// Resultado: "Olá João Silva, sua parcela 5 no valor de R$ 500,00 vence em 15/01/2024."
```

---

## 4?? Implementar Lógica de Envio Real

### Atualizar NotificationOrchestrator

```csharp
private async Task ProcessEmailActionAsync(ReguaCobrancaEtapaAcao acao, Organization organization)
{
    _logger.LogInformation("Processando envio de e-mails para ação {AcaoId}", acao.Id);

    // 1. Buscar dados dos destinatários
    var destinatarios = await _reguaCobrancaRepository.GetDestinatariosAsync(acao.Id, organization.NomeBancoCRM);
    
    if (!destinatarios.Any())
    {
        _logger.LogInformation("Nenhum destinatário encontrado para ação {AcaoId}", acao.Id);
        return;
    }

    // 2. Buscar template
    var templateContent = await _templateService.GetTemplateContentAsync(
        acao.TemplateId ?? 0, 
        organization.NomeBancoCRM);

    // 3. Preparar mensagens
    var emailMessages = new List<EmailMessage>();
    foreach (var destinatario in destinatarios)
    {
        var variables = new Dictionary<string, string>
        {
            { "NomeCliente", destinatario.Nome },
            { "ValorParcela", destinatario.ValorParcela.ToString("C") },
            { "DataVencimento", destinatario.DataVencimento.ToString("dd/MM/yyyy") }
            // ... outras variáveis
        };

        var body = _templateService.ReplaceVariables(templateContent, variables);

        emailMessages.Add(new EmailMessage
        {
            To = destinatario.Email,
            Subject = "Lembrete de Parcela",
            Body = body,
            Metadata = new Dictionary<string, string>
            {
                { "AcaoId", acao.Id.ToString() },
                { "ClienteId", destinatario.ClienteId }
            }
        });
    }

    // 4. Enviar e-mails
    var sucessos = await _emailService.SendBulkEmailsAsync(emailMessages);

    // 5. Registrar histórico
    foreach (var email in emailMessages)
    {
        var historico = new ReguaCobrancaHistoricoEnvio
        {
            AcaoId = acao.Id,
            DestinatarioEmail = email.To,
            DataEnvio = DateTime.Now,
            Enviado = true, // TODO: Verificar resultado real
            TipoEnvio = "EMAIL"
        };

        await _reguaCobrancaRepository.SaveHistoricoEnvioAsync(historico, organization.NomeBancoCRM);
    }

    _logger.LogInformation("Enviados {Sucessos}/{Total} e-mails para ação {AcaoId}", 
        sucessos, emailMessages.Count, acao.Id);
}
```

---

## 5?? Adicionar Testes Unitários

### Instalar Pacotes de Teste

```bash
dotnet new xunit -n ReguaDisparo.Tests
cd ReguaDisparo.Tests
dotnet add package Moq
dotnet add package FluentAssertions
dotnet add reference ../ReguaDisparo.Core/ReguaDisparo.Core.csproj
```

### Exemplo de Teste

```csharp
// ReguaDisparo.Tests/Services/NotificationOrchestratorTests.cs
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Core.Services;
using ReguaDisparo.Domain.Entities;
using Xunit;

namespace ReguaDisparo.Tests.Services;

public class NotificationOrchestratorTests
{
    private readonly Mock<ILogger<NotificationOrchestrator>> _mockLogger;
    private readonly Mock<IOrganizationRepository> _mockOrgRepo;
    private readonly Mock<IReguaCobrancaRepository> _mockReguaRepo;
    private readonly Mock<IEmailService> _mockEmailService;
    private readonly NotificationOrchestrator _orchestrator;

    public NotificationOrchestratorTests()
    {
        _mockLogger = new Mock<ILogger<NotificationOrchestrator>>();
        _mockOrgRepo = new Mock<IOrganizationRepository>();
        _mockReguaRepo = new Mock<IReguaCobrancaRepository>();
        _mockEmailService = new Mock<IEmailService>();

        _orchestrator = new NotificationOrchestrator(
            _mockLogger.Object,
            _mockOrgRepo.Object,
            _mockReguaRepo.Object,
            _mockEmailService.Object);
    }

    [Fact]
    public async Task ProcessAllCompaniesAsync_Should_Call_Repository()
    {
        // Arrange
        var organizations = new List<Organization>
        {
            new Organization { Id = "1", NomeFantasia = "Empresa 1", NomeBancoCRM = "DB1" },
            new Organization { Id = "2", NomeFantasia = "Empresa 2", NomeBancoCRM = "DB2" }
        };

        _mockOrgRepo
            .Setup(r => r.GetActiveOrganizationsAsync())
            .ReturnsAsync(organizations);

        _mockReguaRepo
            .Setup(r => r.GetActiveReguasAsync(It.IsAny<string>()))
            .ReturnsAsync(new List<ReguaCobranca>());

        // Act
        await _orchestrator.ProcessAllCompaniesAsync();

        // Assert
        _mockOrgRepo.Verify(r => r.GetActiveOrganizationsAsync(), Times.Once);
        _mockReguaRepo.Verify(r => r.GetActiveReguasAsync(It.IsAny<string>()), Times.Exactly(2));
    }

    [Fact]
    public async Task ProcessCompanyAsync_Should_Skip_Null_Organization()
    {
        // Arrange
        _mockOrgRepo
            .Setup(r => r.GetByIdAsync("invalid"))
            .ReturnsAsync((Organization?)null);

        // Act
        await _orchestrator.ProcessCompanyAsync("invalid");

        // Assert
        _mockReguaRepo.Verify(r => r.GetActiveReguasAsync(It.IsAny<string>()), Times.Never);
    }
}
```

### Executar Testes

```bash
dotnet test
dotnet test --logger "console;verbosity=detailed"
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

---

## 6?? Configurar Migrations (Entity Framework Core - Opcional)

Se preferir usar EF Core em vez de Dapper:

### Instalar Pacotes

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
```

### Criar DbContext

```csharp
// ReguaDisparo.Infrastructure/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ReguaDisparo.Domain.Entities;

namespace ReguaDisparo.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<ReguaCobranca> ReguasCobranca => Set<ReguaCobranca>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>(entity =>
        {
            entity.ToTable("ORGANIZACAO");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("ID_ORGANIZACAO");
            entity.Property(e => e.NomeFantasia).HasColumnName("DS_NOME_FANTASIA");
            // ... outros mapeamentos
        });
    }
}
```

---

## ?? Recursos Adicionais

### Documentação de Referência
- [Dapper Tutorial](https://github.com/DapperLib/Dapper)
- [xUnit Documentation](https://xunit.net/)
- [Moq Quickstart](https://github.com/moq/moq4/wiki/Quickstart)

### Próximos Documentos a Criar
- [ ] `API_INTEGRATION_GUIDE.md` - Integrações externas
- [ ] `DATABASE_SCHEMA.md` - Esquema do banco de dados
- [ ] `TESTING_GUIDE.md` - Guia completo de testes

---

**Documento criado**: 2024  
**Status**: Pronto para Implementação  
**Versão**: 1.0
