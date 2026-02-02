# ReguaDisparo - Sistema de Disparo Automatizado de Notificações

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-239120?logo=c-sharp)
![License](https://img.shields.io/badge/license-Proprietary-red)

Sistema modernizado de disparo automatizado de notificações (e-mails, SMS, WhatsApp) para gestão de réguas de cobrança e relacionamento com clientes.

## ?? Sobre o Projeto

O **ReguaDisparo** é um Worker Service desenvolvido em .NET 8 que automatiza o envio de notificações baseadas em réguas de cobrança configuráveis. O sistema processa múltiplas organizações/empresas, gerenciando etapas e ações de forma escalável e confiável.

### Principais Funcionalidades

- ? **Processamento Multi-Tenant**: Suporte a múltiplas organizações
- ? **Agendamento Robusto**: Hangfire para jobs recorrentes e sob demanda
- ? **Múltiplos Canais**: E-mail (SendGrid/SMTP), SMS, WhatsApp
- ? **Logging Estruturado**: Serilog com múltiplos destinos
- ? **Arquitetura Limpa**: Separação clara de responsabilidades
- ? **Escalável**: Suporte a execução distribuída

---

## ??? Arquitetura

O projeto segue os princípios de **Clean Architecture** com separação em camadas:

```
???????????????????????????????????????????????
?         ReguaDisparo.App (Worker)           ?
?         - BackgroundService                  ?
?         - Configuração Hangfire/Serilog     ?
???????????????????????????????????????????????
                   ?
???????????????????????????????????????????????
?      ReguaDisparo.Scheduler (Jobs)          ?
?         - NotificationScheduler              ?
???????????????????????????????????????????????
                   ?
???????????????????????????????????????????????
?    ReguaDisparo.Core (Application)          ?
?         - Use Cases                          ?
?         - Interfaces                         ?
?         - Services                           ?
???????????????????????????????????????????????
                   ?
???????????????????????????????????????????????
?      ReguaDisparo.Domain (Entities)         ?
?         - Organization                       ?
?         - ReguaCobranca                      ?
?         - ConfigGeral                        ?
???????????????????????????????????????????????
                   ?
???????????????????????????????????????????????
?  ReguaDisparo.Infrastructure (Services)     ?
?         - Repositories                       ?
?         - Email Services                     ?
?         - External APIs                      ?
???????????????????????????????????????????????
                   ?
???????????????????????????????????????????????
?       ReguaDisparo.IoC (DI Container)       ?
?         - Service Registration               ?
???????????????????????????????????????????????
```

---

## ?? Começando

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (2016+) ou SQL Server Express
- Visual Studio 2022 ou VS Code

### Instalação

1. **Clone o repositório**
```bash
git clone <repository-url>
cd ReguaDisparo
```

2. **Restaure os pacotes**
```bash
dotnet restore
```

3. **Configure o banco de dados**

Crie os bancos de dados necessários:
```sql
CREATE DATABASE ReguaDisparo_Hangfire;
CREATE DATABASE ReguaDisparo;
```

4. **Configure as credenciais**

**Opção 1: User Secrets (Recomendado para desenvolvimento)**
```bash
cd ReguaDisparo.App
dotnet user-secrets set "ConnectionStrings:HangfireConnection" "Server=localhost;Database=ReguaDisparo_Hangfire;Trusted_Connection=True;"
dotnet user-secrets set "SendGrid:ApiKey" "SG.your-api-key"
dotnet user-secrets set "Smtp:Password" "your-smtp-password"
```

**Opção 2: Edite appsettings.json** (não recomendado para produção)
```json
{
  "ConnectionStrings": {
    "HangfireConnection": "Server=localhost;Database=ReguaDisparo_Hangfire;Trusted_Connection=True;"
  },
  "Email": {
    "UseSendGrid": false,
    "From": "noreply@example.com"
  },
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "User": "seu-email@gmail.com",
    "Password": "sua-senha"
  }
}
```

5. **Execute a aplicação**
```bash
cd ReguaDisparo.App
dotnet run
```

---

## ?? Configuração

### Estrutura do appsettings.json

```json
{
  "ConnectionStrings": {
    "HangfireConnection": "...",
    "DefaultConnection": "..."
  },
  "SchedulerSettings": {
    "Mode": "Interval",
    "IntervalMinutes": 5,
    "CronExpression": "0 8 * * *",
    "TimeZone": "E. South America Standard Time"
  },
  "Email": {
    "UseSendGrid": false,
    "From": "noreply@example.com",
    "FromName": "Sistema Régua Disparo"
  },
  "ReguaDisparo": {
    "MaxEmailsPerDay": 999999,
    "MaxSmsPerDay": 999999,
    "ProcessOnWeekends": false,
    "LogPath": "logs/"
  }
}
```

### Variáveis de Ambiente (Produção)

```bash
ConnectionStrings__HangfireConnection="Server=...;Database=ReguaDisparo_Hangfire;..."
Email__UseSendGrid=true
SendGrid__ApiKey=SG.xxxxxxxxxxxx
```

---

## ?? Tecnologias Utilizadas

### Framework e Runtime
- **.NET 8** - Framework moderno e performático
- **C# 12** - Última versão da linguagem

### Principais Bibliotecas

| Biblioteca | Versão | Finalidade |
|------------|--------|------------|
| Hangfire | 1.8.22 | Agendamento de jobs em background |
| Hangfire.SqlServer | 1.8.22 | Persistência de jobs no SQL Server |
| Serilog | 4.3.0 | Logging estruturado |
| SendGrid | 9.29.3 | Envio de e-mails (cloud) |
| MailKit | 4.14.1 | Envio de e-mails (SMTP) |
| Microsoft.Extensions.Hosting | 10.0.2 | Worker Service framework |

---

## ?? Uso

### Executar como Aplicação Console
```bash
cd ReguaDisparo.App
dotnet run
```

### Executar como Windows Service

1. **Publicar o projeto**
```bash
dotnet publish -c Release -o ./publish
```

2. **Instalar como serviço**
```powershell
sc create ReguaDisparoService binPath="C:\path\to\publish\ReguaDisparo.App.exe"
sc description ReguaDisparoService "Sistema de Disparo Automatizado de Notificações"
sc start ReguaDisparoService
```

3. **Gerenciar o serviço**
```powershell
sc stop ReguaDisparoService
sc start ReguaDisparoService
sc delete ReguaDisparoService
```

### Acessar Dashboard do Hangfire

Se configurado, acesse: `http://localhost:<porta>/hangfire`

---

## ?? Monitoramento

### Logs

**Localização**: `ReguaDisparo.App/logs/log-YYYYMMDD.txt`

**Níveis de Log**:
- `Information`: Eventos normais do fluxo
- `Warning`: Situações incomuns mas tratadas
- `Error`: Exceções e falhas
- `Fatal`: Erros críticos

**Exemplo de Log**:
```
[2024-01-15 08:00:00 INF] Iniciando processamento de todas as empresas
[2024-01-15 08:00:01 INF] Encontradas 25 organizações ativas
[2024-01-15 08:00:05 INF] Processamento concluído para Empresa XYZ
```

### Métricas do Hangfire

- Jobs agendados
- Jobs executados com sucesso
- Jobs com falha
- Tempo médio de execução
- Fila de processamento

---

## ?? Testes

```bash
# Executar todos os testes
dotnet test

# Executar com cobertura
dotnet test /p:CollectCoverage=true
```

---

## ?? Desenvolvimento

### Adicionar um Novo Provedor de E-mail

1. Crie uma classe implementando `IEmailService`:
```csharp
public class CustomEmailService : IEmailService
{
    public async Task<bool> SendEmailAsync(string to, string subject, string body, string? attachmentPath = null)
    {
        // Implementação
    }
}
```

2. Registre no IoC:
```csharp
services.AddScoped<IEmailService, CustomEmailService>();
```

### Adicionar um Novo Tipo de Ação

1. Adicione o tipo em `ReguaCobrancaEtapaAcao.TipoAcao`
2. Implemente o processamento em `NotificationOrchestrator.ProcessAcaoAsync()`

---

## ?? Estrutura de Diretórios

```
ReguaDisparo/
??? ReguaDisparo.App/
?   ??? Program.cs              # Configuração e startup
?   ??? Worker.cs               # Background service
?   ??? appsettings.json        # Configurações
?   ??? logs/                   # Arquivos de log
??? ReguaDisparo.Scheduler/
?   ??? NotificationScheduler.cs # Agendamento Hangfire
??? ReguaDisparo.Core/
?   ??? Interfaces/             # Contratos
?   ??? Services/               # Lógica de aplicação
??? ReguaDisparo.Domain/
?   ??? Entities/               # Modelos de domínio
??? ReguaDisparo.Infrastructure/
?   ??? Repositories/           # Acesso a dados
?   ??? Services/               # Serviços externos
??? ReguaDisparo.IoC/
?   ??? ApplicationServiceCollectionExtensions.cs
??? instructions/
    ??? PROJECT_INSTRUCTIONS.md # Documentação completa
    ??? MIGRATION_GUIDE.md      # Guia de migração
```

---

## ?? Troubleshooting

### Problema: Hangfire não cria tabelas
**Solução**: Verifique permissões do usuário SQL e valide a connection string.

### Problema: E-mails não são enviados
**Solução**: 
1. Verifique credenciais do provedor (SendGrid ou SMTP)
2. Consulte logs em `logs/log-YYYYMMDD.txt`
3. Valide configuração de firewall/antivírus

### Problema: Worker não inicia
**Solução**:
1. Verifique logs no console
2. Valide `appsettings.json`
3. Confirme que SQL Server está acessível

---

## ?? Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### Padrões de Código

- Use **PascalCase** para classes e métodos
- Use **camelCase** para variáveis privadas (com `_`)
- Sempre adicione `/// <summary>` para métodos públicos
- Siga os padrões de logging estabelecidos
- Escreva testes para novas funcionalidades

---

## ?? Licença

Este projeto é propriedade privada. Todos os direitos reservados.

---

## ?? Equipe

- **Desenvolvedor Principal**: [Nome]
- **Arquiteto**: [Nome]
- **QA**: [Nome]

---

## ?? Suporte

Para suporte e dúvidas:
- **E-mail**: suporte@example.com
- **Documentação**: [Link para Wiki]
- **Issues**: [Link para Issue Tracker]

---

## ??? Roadmap

### Fase Atual (v1.0)
- [x] Estrutura base do Worker Service
- [x] Integração com Hangfire
- [x] Logging com Serilog
- [ ] Migração completa de lógica de negócio
- [ ] Implementação de repositórios

### Próximas Versões
- [ ] v1.1: Dashboard customizado
- [ ] v1.2: API REST para configuração
- [ ] v1.3: Suporte a templates dinâmicos
- [ ] v2.0: Migração para microserviços

---

## ?? Documentação Adicional

- [?? Instruções Completas do Projeto](instructions/PROJECT_INSTRUCTIONS.md)
- [?? Guia de Migração](instructions/MIGRATION_GUIDE.md)
- [??? Decisões de Arquitetura](instructions/ARCHITECTURE.md) _(a criar)_

---

**Versão**: 1.0.0  
**Última Atualização**: 2024  
**Status**: Em Desenvolvimento Ativo ??
