# ReguaDisparo - Instruções do Projeto

## ?? Índice
- [Visão Geral](#visão-geral)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Arquitetura e Padrões](#arquitetura-e-padrões)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Bibliotecas e Dependências](#bibliotecas-e-dependências)
- [Configuração](#configuração)
- [Execução do Projeto](#execução-do-projeto)
- [Validação e Testes](#validação-e-testes)
- [Regras e Convenções](#regras-e-convenções)

---

## ?? Visão Geral

O **ReguaDisparo** é um sistema de disparo automatizado de notificações desenvolvido como um Worker Service em .NET 8. O projeto utiliza agendamento de tarefas com Hangfire para processar notificações em horários programados.

### Objetivo
Gerenciar e automatizar o envio de notificações para múltiplas empresas através de um sistema de regras de disparo.

---

## ??? Tecnologias Utilizadas

### Framework e Runtime
- **.NET 8** (SDK)
- **C# 12**
- **Worker Service** (.NET Background Service)

### Principais Tecnologias
- **Hangfire** - Agendamento e processamento de jobs em background
- **Serilog** - Logging estruturado
- **SQL Server** - Persistência de dados do Hangfire
- **MailKit** - Envio de e-mails via SMTP
- **SendGrid** - Provedor alternativo de e-mail

### Configuração
- **appsettings.json** - Configurações da aplicação
- **User Secrets** - Gerenciamento seguro de credenciais

---

## ??? Arquitetura e Padrões

### Arquitetura em Camadas (Clean Architecture)

O projeto segue uma arquitetura em camadas bem definida:

```
ReguaDisparo/
??? ReguaDisparo.App          # Camada de Apresentação (Worker Service)
??? ReguaDisparo.Scheduler    # Camada de Agendamento
??? ReguaDisparo.Core         # Camada de Aplicação (Use Cases)
??? ReguaDisparo.Domain       # Camada de Domínio (Entidades)
??? ReguaDisparo.Infrastructure # Camada de Infraestrutura
??? ReguaDisparo.Common       # Utilitários Compartilhados
??? ReguaDisparo.IoC          # Injeção de Dependências
```

### Padrões de Projeto Utilizados

1. **Dependency Injection (DI)**
   - Gerenciado pelo `Microsoft.Extensions.DependencyInjection`
   - Configurado na camada `ReguaDisparo.IoC`

2. **Repository Pattern**
   - Abstrações de acesso a dados
   - Implementações em `ReguaDisparo.Infrastructure`

3. **Service Pattern**
   - Lógica de negócio encapsulada em serviços
   - Serviços de aplicação em `ReguaDisparo.Core`
   - Serviços de infraestrutura em `ReguaDisparo.Infrastructure`

4. **Orchestrator Pattern**
   - `INotificationOrchestrator` coordena o processamento de notificações
   - Gerencia o fluxo de trabalho entre múltiplos serviços

5. **Background Service Pattern**
   - Implementação de `BackgroundService` para processamento contínuo
   - Worker hospedado como serviço do Windows/Linux

---

## ?? Estrutura do Projeto

### ReguaDisparo.App
**Tipo**: Worker Service Application  
**Responsabilidade**: Ponto de entrada da aplicação e configuração do host

**Arquivos Principais**:
- `Program.cs` - Configuração do host, DI, Hangfire e Serilog
- `Worker.cs` - BackgroundService que inicializa o scheduler
- `appsettings.json` - Configurações da aplicação
- `appsettings.Development.json` - Configurações de desenvolvimento

**Dependências de Projeto**:
- ReguaDisparo.Core
- ReguaDisparo.IoC
- ReguaDisparo.Scheduler

### ReguaDisparo.Scheduler
**Tipo**: Class Library  
**Responsabilidade**: Gerenciamento de agendamento de jobs

**Arquivos Principais**:
- `NotificationScheduler.cs` - Configuração de jobs recorrentes no Hangfire

**Dependências de Projeto**:
- ReguaDisparo.Core

### ReguaDisparo.Core
**Tipo**: Class Library  
**Responsabilidade**: Casos de uso e interfaces da aplicação

**Estrutura**:
- `/Interfaces` - Contratos de serviços (ex: INotificationOrchestrator)
- `/Services` - Implementações de serviços de aplicação

**Dependências de Projeto**:
- ReguaDisparo.Domain

### ReguaDisparo.Domain
**Tipo**: Class Library  
**Responsabilidade**: Entidades de domínio e regras de negócio

**Características**:
- Não possui dependências de outros projetos
- Contém entidades de domínio puras
- Independente de frameworks

### ReguaDisparo.Infrastructure
**Tipo**: Class Library  
**Responsabilidade**: Implementações de serviços externos e acesso a dados

**Estrutura**:
- `/Services` - Serviços de infraestrutura (E-mail, etc.)
- `/Repositories` - Implementações de repositórios

**Dependências de Projeto**:
- ReguaDisparo.Domain

### ReguaDisparo.IoC
**Tipo**: Class Library  
**Responsabilidade**: Configuração de Injeção de Dependências

**Responsabilidades**:
- Registrar todos os serviços na DI
- Configurar dependências entre camadas

**Dependências de Projeto**:
- ReguaDisparo.Core
- ReguaDisparo.Infrastructure
- ReguaDisparo.Scheduler

### ReguaDisparo.Common
**Tipo**: Class Library  
**Responsabilidade**: Utilitários e helpers compartilhados

---

## ?? Bibliotecas e Dependências

### ReguaDisparo.App
```xml
- Hangfire (v1.8.22)
- Hangfire.SqlServer (v1.8.22)
- Microsoft.Extensions.Hosting (v10.0.2)
- Serilog (v4.3.0)
- Serilog.Extensions.Hosting (v10.0.0)
- Serilog.Sinks.Console (v6.1.1)
- Serilog.Sinks.File (v7.0.0)
```

**Finalidade**:
- **Hangfire**: Gerenciamento de jobs em background com persistência
- **Hangfire.SqlServer**: Armazenamento de jobs no SQL Server
- **Serilog**: Logging estruturado com múltiplos destinos (Console e File)

### ReguaDisparo.Scheduler
```xml
- Hangfire (v1.8.22)
```

### ReguaDisparo.Infrastructure
```xml
- MailKit (v4.14.1)
- SendGrid (v9.29.3)
```

**Finalidade**:
- **MailKit**: Biblioteca completa para envio de e-mails via SMTP
- **SendGrid**: Cliente oficial do SendGrid para envio de e-mails em nuvem

### ReguaDisparo.IoC
```xml
- Microsoft.Extensions.DependencyInjection.Abstractions (v10.0.2)
```

---

## ?? Configuração

### 1. Configurações do appsettings.json

```json
{
  "ConnectionStrings": {
    "HangfireConnection": "Server=localhost;Database=ReguaDisparo_Hangfire;Trusted_Connection=True;TrustServerCertificate=True;",
    "DefaultConnection": "Server=localhost;Database=ReguaDisparo;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Email": {
    "UseSendGrid": false,
    "From": "noreply@example.com"
  },
  "SendGrid": {
    "ApiKey": "SEU_API_KEY_AQUI"
  },
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "User": "seu-email@gmail.com",
    "Password": "sua-senha"
  }
}
```

### 2. Configurações Importantes

#### Connection Strings
- **HangfireConnection**: Banco de dados para persistência dos jobs do Hangfire
- **DefaultConnection**: Banco de dados principal da aplicação

#### E-mail
- **UseSendGrid**: Define se usa SendGrid (true) ou SMTP (false)
- **From**: Endereço de e-mail remetente

#### Provedor de E-mail
Configure apenas o provedor que será utilizado:
- **SendGrid**: Requer ApiKey válida
- **SMTP**: Requer Host, Port, User e Password

### 3. User Secrets (Recomendado para Desenvolvimento)

```bash
# Configurar User Secrets
dotnet user-secrets init --project ReguaDisparo.App
dotnet user-secrets set "SendGrid:ApiKey" "sua-chave-aqui" --project ReguaDisparo.App
dotnet user-secrets set "Smtp:Password" "sua-senha" --project ReguaDisparo.App
```

### 4. Variáveis de Ambiente (Produção)

Para produção, configure através de variáveis de ambiente:
```
ConnectionStrings__HangfireConnection=...
Email__UseSendGrid=true
SendGrid__ApiKey=...
```

---

## ?? Execução do Projeto

### Pré-requisitos

1. **.NET 8 SDK** instalado
2. **SQL Server** (Local ou Remoto)
3. **Visual Studio 2022** ou **VS Code** com C# extension
4. Configuração de provedor de e-mail (SendGrid ou SMTP)

### Passo a Passo para Execução

#### 1. Clonar/Baixar o Projeto
```bash
git clone <url-do-repositorio>
cd ReguaDisparo
```

#### 2. Restaurar Dependências
```bash
dotnet restore
```

#### 3. Configurar Banco de Dados

##### SQL Server
Certifique-se de que o SQL Server está rodando e acessível.

##### Criar Banco do Hangfire
```sql
CREATE DATABASE ReguaDisparo_Hangfire;
```

##### Criar Banco Principal (se aplicável)
```sql
CREATE DATABASE ReguaDisparo;
```

**Nota**: O Hangfire cria automaticamente as tabelas necessárias na primeira execução.

#### 4. Configurar appsettings.json
Edite `ReguaDisparo.App/appsettings.json` com suas configurações:
- Connection strings válidas
- Configurações de e-mail

#### 5. Compilar o Projeto
```bash
dotnet build
```

#### 6. Executar a Aplicação

##### Modo Development
```bash
cd ReguaDisparo.App
dotnet run
```

##### Modo Production
```bash
cd ReguaDisparo.App
dotnet run --configuration Release
```

#### 7. Verificar Execução

**Logs no Console**:
```
[INF] Iniciando ReguaDisparo Worker Service
[INF] Worker iniciado em: <timestamp>
[INF] Configurando jobs do Hangfire
[INF] Jobs configurados com sucesso
```

**Logs em Arquivo**:
- Localização: `ReguaDisparo.App/logs/log-YYYYMMDD.txt`
- Rolling diário automático

#### 8. Acessar Dashboard do Hangfire (Opcional)

Se habilitado, acesse: `http://localhost:<porta>/hangfire`

---

## ?? Validação e Testes

### Checklist de Validação

#### ? Configuração
- [ ] SQL Server está acessível
- [ ] Connection strings estão corretas
- [ ] Provedor de e-mail está configurado
- [ ] Credenciais estão seguras (User Secrets ou Variáveis de Ambiente)

#### ? Build e Compilação
```bash
dotnet build
```
- [ ] Build sem erros
- [ ] Todos os projetos compilam corretamente
- [ ] Dependências resolvidas

#### ? Execução
```bash
dotnet run --project ReguaDisparo.App
```
- [ ] Aplicação inicia sem exceções
- [ ] Worker service executa
- [ ] Logs aparecem no console
- [ ] Arquivo de log é criado

#### ? Hangfire
- [ ] Tabelas do Hangfire criadas no banco
- [ ] Job recorrente "daily-notifications" registrado
- [ ] Job executa no horário configurado (8:00 AM BRT)

#### ? Logs
```bash
# Verificar logs em tempo real
Get-Content -Path "ReguaDisparo.App/logs/log-<data>.txt" -Wait
```
- [ ] Logs estruturados corretamente
- [ ] Nível de log apropriado (Information, Warning, Error)
- [ ] Timestamps corretos

#### ? Funcionalidade
- [ ] Orquestrador de notificações é invocado
- [ ] E-mails são processados
- [ ] Erros são capturados e logados

### Testes Manuais

#### 1. Testar Execução Imediata do Job
```csharp
// Adicionar endpoint temporário ou método de teste
_scheduler.ExecuteNow();
```

#### 2. Validar Envio de E-mail
- Configure um e-mail de teste
- Verifique recebimento
- Confirme formatação correta

#### 3. Simular Falhas
- Desconectar banco de dados
- Configurar credenciais inválidas
- Verificar tratamento de erros

### Monitoramento em Produção

#### Métricas a Observar
1. **Logs de Erro**: Verificar logs diariamente
2. **Jobs do Hangfire**: Monitorar execuções bem-sucedidas/falhadas
3. **Performance**: Tempo de execução dos jobs
4. **Recursos**: CPU e memória do servidor

#### Ferramentas Recomendadas
- **Application Insights** (Azure)
- **Seq** (Centralizador de logs Serilog)
- **Hangfire Dashboard** (Monitoramento de jobs)

---

## ?? Regras e Convenções

### Estrutura de Código

#### 1. Nomenclatura
- **Classes**: PascalCase (ex: `NotificationScheduler`)
- **Métodos**: PascalCase (ex: `ConfigureJobs()`)
- **Propriedades**: PascalCase (ex: `ApiKey`)
- **Variáveis privadas**: camelCase com underscore (ex: `_logger`)
- **Parâmetros**: camelCase (ex: `stoppingToken`)

#### 2. Organização de Usings
```csharp
// Usings do .NET
using System;
using Microsoft.Extensions.Logging;

// Usings de terceiros
using Hangfire;
using Serilog;

// Usings do projeto
using ReguaDisparo.Core.Interfaces;
```

#### 3. Injeção de Dependências
- Sempre usar injeção via construtor
- Armazenar dependências em campos readonly privados
- Registrar serviços na camada IoC

```csharp
public class ExampleService
{
    private readonly ILogger<ExampleService> _logger;
    
    public ExampleService(ILogger<ExampleService> logger)
    {
        _logger = logger;
    }
}
```

### Logging

#### Padrões de Log
```csharp
// Informação
_logger.LogInformation("Operação concluída: {OperationName}", operationName);

// Aviso
_logger.LogWarning("Tentativa {Attempt} de {MaxAttempts} falhou", attempt, maxAttempts);

// Erro
_logger.LogError(ex, "Erro ao processar notificação para empresa {CompanyId}", companyId);
```

#### Níveis de Log
- **Information**: Eventos normais do fluxo
- **Warning**: Situações incomuns mas tratadas
- **Error**: Exceções e falhas
- **Fatal**: Erros críticos que encerram a aplicação

### Tratamento de Erros

#### Try-Catch em Métodos Críticos
```csharp
try
{
    await ProcessAsync();
}
catch (Exception ex)
{
    _logger.LogError(ex, "Erro crítico em ProcessAsync");
    throw; // Re-throw se necessário
}
```

#### Validação de Argumentos
```csharp
public void ProcessCompany(int companyId)
{
    if (companyId <= 0)
        throw new ArgumentException("CompanyId deve ser positivo", nameof(companyId));
}
```

### Async/Await

#### Sempre usar Async para I/O
```csharp
public async Task<Result> ProcessAsync(CancellationToken cancellationToken)
{
    var data = await _repository.GetDataAsync(cancellationToken);
    return await _service.ProcessAsync(data, cancellationToken);
}
```

#### Nomenclatura de Métodos Assíncronos
- Sufixo `Async` em métodos assíncronos
- Aceitar `CancellationToken` quando aplicável

### Configuração

#### Strongly-Typed Configuration
```csharp
// Preferir
public class EmailSettings
{
    public bool UseSendGrid { get; set; }
    public string From { get; set; }
}

// Registrar
services.Configure<EmailSettings>(configuration.GetSection("Email"));
```

### Banco de Dados

#### Connection Strings
- Sempre usar `appsettings.json` ou variáveis de ambiente
- Nunca commitar credenciais no código
- Usar User Secrets em desenvolvimento

#### Transações
- Usar transações para operações críticas
- Garantir rollback em caso de erro

### Agendamento (Hangfire)

#### Configuração de Jobs
```csharp
// Job Recorrente
RecurringJob.AddOrUpdate<IService>(
    "job-id",
    service => service.MethodAsync(),
    Cron.Daily(8, 0), // 8:00 AM
    new RecurringJobOptions
    {
        TimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
    });
```

#### Retry Policy
- Configurar retries para jobs que podem falhar temporariamente
- Usar exponential backoff quando apropriado

### Segurança

#### Secrets
- User Secrets para desenvolvimento
- Azure Key Vault ou variáveis de ambiente para produção
- Nunca logar informações sensíveis

#### Validação de Input
- Sempre validar dados de entrada
- Sanitizar dados antes de processar

### Performance

#### Background Services
- Evitar processamento pesado no thread do Worker
- Usar `Task.Delay` com `CancellationToken`
- Respeitar shutdown graceful

```csharp
while (!stoppingToken.IsCancellationRequested)
{
    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
}
```

### Documentação

#### XML Comments
```csharp
/// <summary>
/// Processa notificações para todas as empresas
/// </summary>
/// <returns>Task representando a operação assíncrona</returns>
Task ProcessAllCompaniesAsync();
```

#### README e Documentação
- Manter README atualizado
- Documentar mudanças significativas
- Incluir exemplos de uso

---

## ?? Fluxo de Trabalho

### 1. Inicialização
```
Program.cs ? Configura DI, Hangfire, Serilog
           ? Registra Worker como HostedService
           ? Inicia aplicação
```

### 2. Worker Service
```
Worker.ExecuteAsync ? Injeta NotificationScheduler
                    ? Chama ConfigureJobs()
                    ? Entra em loop de monitoramento
```

### 3. Agendamento
```
NotificationScheduler.ConfigureJobs ? Registra job recorrente no Hangfire
                                    ? Job: daily-notifications (8:00 AM)
```

### 4. Execução do Job
```
Hangfire Server ? Invoca INotificationOrchestrator.ProcessAllCompaniesAsync()
                ? Orquestrador coordena processamento
                ? Serviços de e-mail enviam notificações
```

### 5. Logging
```
Serilog ? Console (tempo real)
        ? Arquivo (logs/log-YYYYMMDD.txt)
```

---

## ?? Notas Adicionais

### Timezone
O projeto utiliza **E. South America Standard Time** (Brasília) para agendamento.

### Graceful Shutdown
O Worker Service respeita `CancellationToken` para shutdown gracioso.

### Escalabilidade
- Hangfire suporta múltiplos workers
- Pode ser executado em múltiplas instâncias
- SQL Server gerencia concorrência de jobs

### Troubleshooting

#### Problema: Hangfire não cria tabelas
**Solução**: Verificar permissões do usuário SQL e connection string

#### Problema: E-mails não enviados
**Solução**: 
1. Verificar credenciais do provedor
2. Checar logs para detalhes do erro
3. Validar configuração SMTP/SendGrid

#### Problema: Worker não inicia
**Solução**:
1. Verificar logs no console
2. Validar configuração do appsettings.json
3. Confirmar que SQL Server está acessível

---

## ?? Referências

- [.NET Worker Services](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers)
- [Hangfire Documentation](https://docs.hangfire.io/)
- [Serilog Documentation](https://serilog.net/)
- [MailKit Documentation](http://www.mimekit.net/)
- [SendGrid .NET SDK](https://github.com/sendgrid/sendgrid-csharp)

---

**Versão do Documento**: 1.0  
**Última Atualização**: 2024  
**Autor**: Equipe ReguaDisparo
