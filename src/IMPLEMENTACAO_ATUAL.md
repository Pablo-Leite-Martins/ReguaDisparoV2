# Implementação do Fluxo de Régua de Disparo

## Resumo do que foi implementado

### 1. **Camada de Serviços (Core)**

#### Services Criados:
- **OrganizacaoService** - Gerencia organizações (criado anteriormente)
- **ReguaFiltroService** - Processa filtros e validações de dados
- **ComunicacaoService** - Gerencia envio de comunicações (Email/SMS/WhatsApp)
- **ReguaCobrancaService** - Orquestrador principal (já existia, foi mantido)

#### Interfaces Criadas:
- `IOrganizacaoService`
- `IReguaFiltroService`
- `IComunicacaoService`
- Classes de modelo: `DestinatarioEmail`, `DestinatarioSms`, `DestinatarioWhatsApp`

---

### 2. **Camada de Repositórios (Infrastructure)**

#### Repositórios Criados:
- **ReguaCobrancaConfigRepository** - Configurações de réguas
- **ReguaCobrancaEtapaRepository** - Etapas das réguas
- **ReguaCobrancaEtapaAcaoRepository** - Ações de cada etapa (já existia)
- **ReguaCobrancaEtapaAcaoFiltroRepository** - Filtros das ações
- **ReguaCobrancaEtapaAcaoAgendamentoRepository** - Agendamentos de ações
- **ReguaCobrancaEtapaOrdenacaoRepository** - Ordenações personalizadas
- **ReguaCobrancaHistoricoEnvioRepository** - Histórico de envios (já existia)

#### Interfaces Criadas:
- `IReguaCobrancaConfigRepository`
- `IReguaCobrancaEtapaRepository`
- `IReguaCobrancaEtapaAcaoFiltroRepository`
- `IReguaCobrancaEtapaAcaoAgendamentoRepository`
- `IReguaCobrancaEtapaOrdenacaoRepository`

---

### 3. **Registro de Dependências (IoC)**

Todos os services foram registrados em:
- [ApplicationModule.cs](ReguaDisparo.IoC/Modules/ApplicationModule.cs)

```csharp
services.AddScoped<IOrganizacaoService, OrganizacaoService>();
services.AddScoped<IReguaCobrancaService, ReguaCobrancaService>();
services.AddScoped<IReguaFiltroService, ReguaFiltroService>();
services.AddScoped<IComunicacaoService, ComunicacaoService>();
```

---

## Funcionalidades Implementadas

### ✅ Completo
1. **Busca de organizações ativas** - Service e Repository criados
2. **Estrutura de réguas** - Repositórios para todas as entidades
3. **Sistema de filtros** - Lógica de filtros implementada
4. **Sistema de validação** - Modo teste vs produção
5. **Sistema de ordenação** - Ordenação de resultados
6. **Registro de histórico** - Envios e falhas
7. **Envio de e-mails** - Implementação básica funcional

### ⚠️ Implementação Parcial
1. **Busca de dados de mensageria** - Precisa de stored procedures
2. **Templates de e-mail** - Precisa implementar substituição de variáveis
3. **Envio de SMS** - Interface criada, implementação pendente
4. **Envio de WhatsApp** - Interface criada, implementação pendente

### ❌ Não Implementado
1. **Integração com UAU** - Verificação PRO_UAU
2. **Ações especiais** - FGR, MAC, RE, etc.
3. **Geração de arquivos** - Arquivo de telefonia
4. **NPS e pesquisas** - Fluxos específicos
5. **Distribuição de casos** - Filas de atendimento

---

## Próximos Passos para Testar

### Passo 1: Configurar Connection Strings

No `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "ControleAcessoConnection": "Server=SEU_SERVIDOR;Database=CLIENTEMAIS_CONTROLE_ACESSO;...",
    "CorporativoConnection": "Server=SEU_SERVIDOR;Database=CLIENTEMAIS_CORPORATIVO;...",
    "ClienteMaisConnection": "Server=SEU_SERVIDOR;Database={0};..."
  },
  "Email": {
    "UseSendGrid": false,
    "From": "seu-email@dominio.com",
    "FromName": "Régua de Disparo"
  },
  "Smtp": {
    "Host": "smtp.gmail.com",
    "Port": 587,
    "User": "seu-email@gmail.com",
    "Password": "sua-senha-app"
  }
}
```

### Passo 2: Criar Stored Procedures

Precisa implementar as stored procedures de mensageria:
- `SP_LISTA_BASE_MENSAGERIA` - Para buscar dados de cobrança
- `SP_LISTA_BASE_MENSAGERIA_PARCELAS` - Para parcelas vencidas
- `SP_LISTA_BASE_MENSAGERIA_A_RECEBER` - Para cobrança preventiva

**Local**: Criar em `ReguaDisparo.Domain/Entities/ClienteMais/Procedures/`

### Passo 3: Implementar Service de Mensageria

Criar `IMensageriaService` e `MensageriaService` para:
- Executar as stored procedures
- Retornar DataTables com os dados
- Processar os dados conforme tipo de ação

### Passo 4: Completar o ReguaCobrancaService

Atualizar o método `ExecutarAcaoEtapaReguaAsync` para:
1. Buscar dados via MensageriaService
2. Aplicar filtros via ReguaFiltroService
3. Aplicar validações via ReguaFiltroService
4. Converter DataTable para lista de destinatários
5. Chamar ComunicacaoService para enviar

### Passo 5: Testar Localmente

```bash
cd ReguaDisparo.App
dotnet run
```

---

## Estrutura de Dados

### Fluxo Simplificado:

```
1. NotificationOrchestrator
   ↓
2. OrganizacaoService.ListarAtivasAsync()
   ↓
3. ReguaCobrancaService.ExecutarReguaCobrancaOrganizacaoAsync()
   ↓
4. Para cada Régua Ativa:
   - Buscar Configurações
   - Buscar Etapas
   - Para cada Etapa:
     - Buscar Ações
     - Para cada Ação:
       ↓
5. MensageriaService.BuscarDados() [A IMPLEMENTAR]
   ↓
6. ReguaFiltroService.ExecutarFiltros()
   ↓
7. ReguaFiltroService.VerificarValidacao()
   ↓
8. ComunicacaoService.EnviarEmailsAsync()
   ↓
9. Registrar Histórico
```

---

## Arquivos Criados/Modificados

### Novos Arquivos:
- `ReguaDisparo.Core/Interfaces/IOrganizacaoService.cs`
- `ReguaDisparo.Core/Interfaces/IReguaFiltroService.cs`
- `ReguaDisparo.Core/Interfaces/IComunicacaoService.cs`
- `ReguaDisparo.Core/Services/OrganizacaoService.cs`
- `ReguaDisparo.Core/Services/ReguaFiltroService.cs`
- `ReguaDisparo.Core/Services/ComunicacaoService.cs`
- `ReguaDisparo.Domain/Interfaces/Repositories/ClienteMais/IReguaCobrancaConfigRepository.cs`
- `ReguaDisparo.Domain/Interfaces/Repositories/ClienteMais/IReguaCobrancaEtapaRepository.cs`
- `ReguaDisparo.Domain/Interfaces/Repositories/ClienteMais/IReguaCobrancaEtapaAcaoFiltroRepository.cs`
- `ReguaDisparo.Domain/Interfaces/Repositories/ClienteMais/IReguaCobrancaEtapaAcaoAgendamentoRepository.cs`
- `ReguaDisparo.Domain/Interfaces/Repositories/ClienteMais/IReguaCobrancaEtapaOrdenacaoRepository.cs`
- `ReguaDisparo.Infrastructure/Repositories/ClienteMais/ReguaCobrancaConfigRepository.cs`
- `ReguaDisparo.Infrastructure/Repositories/ClienteMais/ReguaCobrancaEtapaRepository.cs`
- `ReguaDisparo.Infrastructure/Repositories/ClienteMais/ReguaCobrancaEtapaAcaoFiltroRepository.cs`
- `ReguaDisparo.Infrastructure/Repositories/ClienteMais/ReguaCobrancaEtapaAcaoAgendamentoRepository.cs`
- `ReguaDisparo.Infrastructure/Repositories/ClienteMais/ReguaCobrancaEtapaOrdenacaoRepository.cs`

### Arquivos Modificados:
- `ReguaDisparo.Core/Services/NotificationOrchestrator.cs` - Agora usa IOrganizacaoService
- `ReguaDisparo.IoC/Modules/ApplicationModule.cs` - Registros de DI atualizados

---

## Observações Importantes

### Limitações Atuais:
1. **Filtros**: Implementação básica - alguns tipos de filtros complexos podem não funcionar
2. **Templates**: Não está processando variáveis dinâmicas nos e-mails
3. **Dados**: Não está buscando dados reais do banco (precisa das SPs)
4. **Validação horários**: Não está validando horário de envio das réguas
5. **Agendamentos**: Lógica de agendamento precisa ser testada

### Para Produção:
1. Implementar todas as stored procedures de mensageria
2. Criar service de templates com substituição de variáveis
3. Implementar integrações de SMS e WhatsApp
4. Adicionar tratamento robusto de erros
5. Implementar retry policies
6. Adicionar métricas e monitoring
7. Implementar testes unitários e de integração

---

## Como Contribuir

1. **Mensageria**: Implementar `IMensageriaService` com as SPs
2. **Templates**: Criar sistema de templates dinâmicos
3. **Integrações**: Implementar SMS e WhatsApp
4. **Testes**: Adicionar testes unitários
5. **Documentação**: Expandir esta documentação

---

## Suporte

Para dúvidas ou problemas:
1. Verificar logs em `ReguaDisparo.App/bin/Debug/net8.0/logs/`
2. Verificar configurações em `appsettings.json`
3. Validar connection strings
4. Verificar se as tabelas existem no banco de dados
