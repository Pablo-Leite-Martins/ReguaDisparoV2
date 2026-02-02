# ReguaDisparo - .NET 8

## Estrutura do Projeto

- **App**: Camada de entrada (Worker Service)
- **Core**: Regras de negócio
- **Domain**: Modelos e entidades
- **Infrastructure**: Implementações técnicas
- **Scheduler**: Configuração do Hangfire
- **IoC**: Injeção de Dependência
- **Common**: Utilitários

## Configuração

1. Configure as connection strings em appsettings.json
2. Configure as credenciais de email (SendGrid ou SMTP)
3. Execute: dotnet run --project src/ReguaDisparo.App

## Features

- Envio de emails com fallback (SendGrid -> SMTP)
- Envio de SMS
- Envio de WhatsApp
- Agendamento com Hangfire
- Logging com Serilog
