# ? Checklist de Migração - ReguaDisparo

## ?? Progresso Geral: 16% (Fase 1/6 Completa)

```
[???????????????????????????] 16% - Fase 1 Completa
```

---

## ?? Fases da Migração

### ? Fase 1: Estrutura Base (100% Completa)
**Status**: ? CONCLUÍDA  
**Data Início**: 2024  
**Data Conclusão**: 2024

- [x] Criar solução .NET 8
- [x] Criar 7 projetos com Clean Architecture
- [x] Configurar Worker Service
- [x] Implementar Hangfire para agendamento
- [x] Configurar Serilog para logging
- [x] Criar camadas (Domain, Core, Infrastructure, etc.)
- [x] Definir interfaces base
- [x] Criar entidades de domínio
- [x] Implementar estrutura de serviços
- [x] Configurar Injeção de Dependências
- [x] Criar documentação completa
- [x] Validar compilação sem erros

**Entregáveis**:
- ? 7 Projetos criados
- ? 17 Arquivos de código
- ? 5 Interfaces
- ? 4 Entidades
- ? 5 Serviços base
- ? 6 Documentos (222 KB)

---

### ? Fase 2: Implementação de Repositórios (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? ALTA  
**Estimativa**: 2 semanas

#### 2.1 Configuração de Acesso a Dados
- [ ] Adicionar pacote Dapper ao Infrastructure
- [ ] Adicionar pacote Microsoft.Data.SqlClient
- [ ] Criar BaseRepository com conexões dinâmicas
- [ ] Configurar connection strings no appsettings
- [ ] Testar conexão com banco de dados

#### 2.2 Implementação de Repositórios
- [ ] Implementar OrganizationRepository.GetActiveOrganizationsAsync()
- [ ] Implementar OrganizationRepository.GetByIdAsync()
- [ ] Implementar ReguaCobrancaRepository.GetActiveReguasAsync()
- [ ] Implementar ReguaCobrancaRepository.GetEtapasByReguaAsync()
- [ ] Implementar ReguaCobrancaRepository.GetAcoesByEtapaAsync()
- [ ] Implementar ReguaCobrancaRepository.SaveHistoricoEnvioAsync()

#### 2.3 Repositórios Adicionais
- [ ] Criar IConfigGeralRepository
- [ ] Implementar ConfigGeralRepository
- [ ] Criar ITemplateRepository
- [ ] Implementar TemplateRepository
- [ ] Criar IDestinatarioRepository
- [ ] Implementar DestinatarioRepository

#### 2.4 Testes de Repositórios
- [ ] Testar OrganizationRepository
- [ ] Testar ReguaCobrancaRepository
- [ ] Testar ConfigGeralRepository
- [ ] Validar queries SQL
- [ ] Testar performance de consultas

**Entregáveis Esperados**:
- [ ] 6 Repositórios funcionais
- [ ] Queries SQL validadas
- [ ] Testes de integração
- [ ] Documentação de queries

---

### ? Fase 3: Migração de Lógica de Negócio (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? ALTA  
**Estimativa**: 4 semanas

#### 3.1 Análise do Código Legado
- [ ] Mapear métodos de ExecutaReguaCobranca() (3456 linhas)
- [ ] Identificar dependências externas
- [ ] Mapear lógica de filtros
- [ ] Mapear tipos de ação (EMAIL, SMS, WHATSAPP, PESQUISA, NPS)
- [ ] Documentar regras de negócio

#### 3.2 Migração de Processamento Principal
- [ ] Migrar ExecutaReguaCobranca()
- [ ] Migrar ExecutaReguaCobrancaOrganizacao()
- [ ] Implementar processamento de réguas
- [ ] Implementar processamento de etapas
- [ ] Implementar processamento de ações
- [ ] Migrar lógica de validação de fim de semana

#### 3.3 Migração de Processamento de Ações
- [ ] Implementar processamento de ações EMAIL
- [ ] Implementar processamento de ações SMS
- [ ] Implementar processamento de ações WHATSAPP
- [ ] Implementar processamento de ações PESQUISA
- [ ] Implementar processamento de ações NPS
- [ ] Implementar validação de agendamentos

#### 3.4 Migração de Lógica de Templates
- [ ] Criar ITemplateService
- [ ] Implementar TemplateService
- [ ] Migrar lógica de substituição de variáveis
- [ ] Migrar geração de conteúdo HTML
- [ ] Implementar cache de templates
- [ ] Testar templates com dados reais

#### 3.5 Migração de Lógica de Filtros
- [ ] Migrar lógica de filtros por etapa/ação
- [ ] Implementar consultas dinâmicas
- [ ] Migrar validações de filtros
- [ ] Testar filtros complexos

**Entregáveis Esperados**:
- [ ] Toda lógica do CAPYS_ReguaDisparo_Model migrada
- [ ] Serviços de processamento funcionais
- [ ] Templates funcionando
- [ ] Filtros implementados

---

### ? Fase 4: Implementação de Integrações (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? MÉDIA  
**Estimativa**: 3 semanas

#### 4.1 Integração de E-mail
- [ ] Finalizar SendGridEmailService
- [ ] Finalizar SmtpEmailService
- [ ] Implementar retry logic
- [ ] Implementar rate limiting
- [ ] Testar envio real de e-mails
- [ ] Validar templates HTML

#### 4.2 Integração de SMS
- [ ] Criar ISmsService
- [ ] Implementar TwilioSmsService (ou provedor escolhido)
- [ ] Configurar credenciais
- [ ] Implementar envio de SMS
- [ ] Implementar validação de número de telefone
- [ ] Testar envio real

#### 4.3 Integração de WhatsApp
- [ ] Criar IWhatsAppService
- [ ] Implementar WhatsAppService
- [ ] Configurar API do WhatsApp Business
- [ ] Implementar envio de mensagens
- [ ] Implementar templates de WhatsApp
- [ ] Testar envio real

#### 4.4 Integrações Externas
- [ ] Migrar integração com UAU API
- [ ] Implementar client HTTP para APIs externas
- [ ] Configurar timeouts e retries
- [ ] Implementar tratamento de erros
- [ ] Documentar endpoints

**Entregáveis Esperados**:
- [ ] Serviços de e-mail funcionais
- [ ] Serviço de SMS funcional
- [ ] Serviço de WhatsApp funcional
- [ ] Integrações externas migradas

---

### ? Fase 5: Configurações e Otimizações (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? BAIXA  
**Estimativa**: 2 semanas

#### 5.1 Configurações Dinâmicas
- [ ] Implementar carregamento de organizações do BD
- [ ] Implementar ConfigGeral por organização
- [ ] Configurar connection strings dinâmicas
- [ ] Implementar cache de configurações
- [ ] Validar configurações ao startup

#### 5.2 Otimizações de Performance
- [ ] Implementar processamento em paralelo (quando aplicável)
- [ ] Otimizar queries SQL
- [ ] Implementar caching inteligente
- [ ] Adicionar índices no banco de dados
- [ ] Profiling de performance

#### 5.3 Limitações e Controles
- [ ] Implementar limite diário de envios (e-mail/SMS)
- [ ] Implementar blacklist/whitelist
- [ ] Implementar throttling
- [ ] Implementar circuit breaker
- [ ] Implementar health checks

#### 5.4 Monitoramento
- [ ] Configurar Application Insights (ou similar)
- [ ] Implementar métricas customizadas
- [ ] Configurar alertas
- [ ] Implementar dashboard de monitoramento

**Entregáveis Esperados**:
- [ ] Sistema configurável por organização
- [ ] Performance otimizada
- [ ] Limites e controles implementados
- [ ] Monitoramento completo

---

### ? Fase 6: Testes e Validação (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? ALTA  
**Estimativa**: 4 semanas

#### 6.1 Testes Unitários
- [ ] Testes para NotificationOrchestrator
- [ ] Testes para todos os Repositories
- [ ] Testes para EmailService
- [ ] Testes para SmsService
- [ ] Testes para WhatsAppService
- [ ] Testes para TemplateService
- [ ] Cobertura mínima: 80%

#### 6.2 Testes de Integração
- [ ] Testes de integração com banco de dados
- [ ] Testes de integração com Hangfire
- [ ] Testes de integração com SendGrid/SMTP
- [ ] Testes de integração com SMS
- [ ] Testes de integração com WhatsApp
- [ ] Testes end-to-end

#### 6.3 Testes de Performance
- [ ] Load testing
- [ ] Stress testing
- [ ] Testes de concorrência
- [ ] Profiling de memória
- [ ] Profiling de CPU

#### 6.4 Validação com Dados Reais
- [ ] Comparação de resultados legado vs novo
- [ ] Validação de envios
- [ ] Validação de logs
- [ ] Validação de históricos
- [ ] Testes com volume real de dados

#### 6.5 Testes de Segurança
- [ ] Testes de vulnerabilidades
- [ ] Validação de credenciais
- [ ] Testes de SQL injection
- [ ] Validação de TLS/SSL
- [ ] Audit de segurança

**Entregáveis Esperados**:
- [ ] Suite de testes completa
- [ ] Cobertura de código >80%
- [ ] Relatórios de performance
- [ ] Validação com dados reais aprovada
- [ ] Aprovação de segurança

---

### ? Fase 7: Deploy e Produção (0% Completa)
**Status**: ?? PENDENTE  
**Prioridade**: ?? MÉDIA  
**Estimativa**: 2 semanas

#### 7.1 Preparação
- [ ] Configurar CI/CD pipeline
- [ ] Preparar scripts de deploy
- [ ] Configurar ambientes (Dev/Staging/Prod)
- [ ] Documentar processo de deploy
- [ ] Criar runbook operacional

#### 7.2 Deploy em Staging
- [ ] Deploy inicial em staging
- [ ] Configurar monitoring
- [ ] Executar smoke tests
- [ ] Validação completa
- [ ] Aprovação para produção

#### 7.3 Deploy em Produção
- [ ] Plano de rollout gradual
- [ ] Deploy inicial (1 organização piloto)
- [ ] Monitoramento intensivo
- [ ] Validação de resultados
- [ ] Expansão gradual para mais organizações
- [ ] Rollout completo

#### 7.4 Desativação do Legado
- [ ] Validar que novo sistema está estável
- [ ] Backup final do sistema legado
- [ ] Desativar sistema legado
- [ ] Arquivar código legado
- [ ] Documentar lições aprendidas

#### 7.5 Pós-Deploy
- [ ] Monitoramento contínuo (30 dias)
- [ ] Ajustes e correções
- [ ] Otimizações baseadas em métricas
- [ ] Treinamento de equipe de suporte
- [ ] Documentação final

**Entregáveis Esperados**:
- [ ] Sistema em produção
- [ ] Sistema legado desativado
- [ ] Documentação de operação
- [ ] Equipe treinada
- [ ] Monitoramento ativo

---

## ?? Métricas de Progresso

### Por Fase

| Fase | Status | Progresso | Tarefas Total | Concluídas | Pendentes |
|------|--------|-----------|---------------|------------|-----------|
| 1. Estrutura Base | ? Completa | 100% | 12 | 12 | 0 |
| 2. Repositórios | ? Pendente | 0% | 19 | 0 | 19 |
| 3. Lógica de Negócio | ? Pendente | 0% | 28 | 0 | 28 |
| 4. Integrações | ? Pendente | 0% | 21 | 0 | 21 |
| 5. Configurações | ? Pendente | 0% | 17 | 0 | 17 |
| 6. Testes | ? Pendente | 0% | 27 | 0 | 27 |
| 7. Deploy | ? Pendente | 0% | 21 | 0 | 21 |
| **TOTAL** | **Em Andamento** | **16%** | **145** | **12** | **133** |

### Timeline Estimado

```
Fase 1: ?????????? (2 semanas) ? COMPLETA
Fase 2: ?????????? (2 semanas) ? Pendente
Fase 3: ?????????? (4 semanas) ? Pendente
Fase 4: ?????????? (3 semanas) ? Pendente
Fase 5: ?????????? (2 semanas) ? Pendente
Fase 6: ?????????? (4 semanas) ? Pendente
Fase 7: ?????????? (2 semanas) ? Pendente

Total Estimado: 19 semanas (~4.5 meses)
Progresso Atual: 2 semanas (10.5%)
```

---

## ?? Próximas Ações Prioritárias

### Esta Semana
1. [ ] Adicionar Dapper ao Infrastructure
2. [ ] Criar BaseRepository
3. [ ] Implementar OrganizationRepository
4. [ ] Testar conexão com banco de dados

### Próxima Semana
1. [ ] Implementar ReguaCobrancaRepository
2. [ ] Implementar ConfigGeralRepository
3. [ ] Criar primeiros testes unitários
4. [ ] Validar queries SQL

### Este Mês
1. [ ] Completar Fase 2 (Repositórios)
2. [ ] Iniciar Fase 3 (Lógica de Negócio)
3. [ ] Mapear código legado detalhadamente
4. [ ] Começar migração de ExecutaReguaCobranca()

---

## ?? Marcos Importantes

- [x] **Marco 1**: Estrutura Base Completa (Fase 1) ?
- [ ] **Marco 2**: Repositórios Funcionais (Fase 2)
- [ ] **Marco 3**: Lógica Core Migrada (Fase 3)
- [ ] **Marco 4**: Integrações Completas (Fase 4)
- [ ] **Marco 5**: Sistema Otimizado (Fase 5)
- [ ] **Marco 6**: Testes Completos (Fase 6)
- [ ] **Marco 7**: Em Produção (Fase 7)

---

## ?? Notas e Observações

### Decisões Tomadas
- ? Usar Dapper em vez de Entity Framework Core (performance)
- ? Usar Hangfire para agendamento (confiabilidade)
- ? Usar Serilog para logging (flexibilidade)
- ? Manter SendGrid + SMTP como opções de e-mail

### Riscos Identificados
- ?? Complexidade do código legado (3456 linhas)
- ?? Múltiplos bancos de dados dinâmicos
- ?? Integrações externas não documentadas
- ?? Dependências de bibliotecas antigas

### Bloqueadores Atuais
- ?? Nenhum bloqueador identificado

---

## ?? Atualização de Status

**Última Atualização**: 2024  
**Responsável**: Time de Desenvolvimento  
**Próxima Revisão**: Semanal

---

## ? Como Usar Este Checklist

1. **Revisar semanalmente**: Atualizar progresso de tarefas
2. **Marcar tarefas concluídas**: Substituir `[ ]` por `[x]`
3. **Adicionar observações**: Documentar decisões e bloqueadores
4. **Comunicar progresso**: Compartilhar com stakeholders
5. **Ajustar estimativas**: Atualizar conforme necessário

---

**Checklist**: Tracking de Migração  
**Versão**: 1.0  
**Status**: Ativo ??  
**Última Atualização**: 2024
