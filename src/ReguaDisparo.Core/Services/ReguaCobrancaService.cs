using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Entities.Corporativo;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Domain.Interfaces.Repositories.Corporativo;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Core.Interfaces.UAU;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Services;

public class ReguaCobrancaService : IReguaCobrancaService
{
    private readonly ILogger<ReguaCobrancaService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IOrganizacaoService _organizacaoService;
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;
    private readonly IWhatsAppService _whatsAppService;
    private readonly IConfigGeralService _configGeralService;
    private readonly IEtlService _etlService;
    private readonly IUauIntegracaoService _uauIntegracaoService;
    private readonly IReguaCobrancaEtapaAcaoAgendamentoService _agendamentoService;
    private readonly IReguaCobrancaHistoricoEnvioService _historicoEnvioService;
    private readonly IReguaCobrancaConfigService _reguaConfigService;
    private readonly IReguaCobrancaEtapaService _reguaEtapaService;
    private readonly IReguaCobrancaEtapaAcaoService _reguaEtapaAcaoService;
    private readonly IReguaCobrancaEtapaAcaoFiltroService _filtroService;
    private readonly IReguaCobrancaEtapaOrdenacaoService _ordenacaoService;
    private readonly IMensageriaService _mensageriaService;
    private readonly ILoggerFactory _loggerFactory;

    // Constantes do projeto antigo
    private const int NUM_MAX_SMS = 999999;
    private const int NUM_MAX_EMAIL = 999999;

    public ReguaCobrancaService(
        ILogger<ReguaCobrancaService> logger,
        IConfiguration configuration,
        IOrganizacaoService organizacaoService,
        ITenantDbContextFactory tenantFactory,
        IEmailService emailService,
        ISmsService smsService,
        IWhatsAppService whatsAppService,
        IConfigGeralService configGeralService,
        IEtlService etlService,
        IUauIntegracaoService uauIntegracaoService,
        IReguaCobrancaEtapaAcaoAgendamentoService agendamentoService,
        IReguaCobrancaHistoricoEnvioService historicoEnvioService,
        IReguaCobrancaConfigService reguaConfigService,
        IReguaCobrancaEtapaService reguaEtapaService,
        IReguaCobrancaEtapaAcaoService reguaEtapaAcaoService,
        IReguaCobrancaEtapaAcaoFiltroService filtroService,
        IReguaCobrancaEtapaOrdenacaoService ordenacaoService,
        IMensageriaService mensageriaService,
        ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _organizacaoService = organizacaoService;
        _tenantFactory = tenantFactory;
        _emailService = emailService;
        _smsService = smsService;
        _whatsAppService = whatsAppService;
        _configGeralService = configGeralService;
        _etlService = etlService;
        _uauIntegracaoService = uauIntegracaoService;
        _agendamentoService = agendamentoService;
        _historicoEnvioService = historicoEnvioService;
        _reguaConfigService = reguaConfigService;
        _reguaEtapaService = reguaEtapaService;
        _reguaEtapaAcaoService = reguaEtapaAcaoService;
        _filtroService = filtroService;
        _ordenacaoService = ordenacaoService;
        _mensageriaService = mensageriaService;
        _loggerFactory = loggerFactory;
    }

    public async Task ExecutarReguaCobrancaAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");

            var listaOrganizacao = await _organizacaoService.ListarAtivasAsync();

            var organizacoesFiltradas = listaOrganizacao
                .Where(o => !string.IsNullOrEmpty(o.NOME_BANCO_CRM))
                .Where(o => o.DS_NOME_FANTASIA.Contains("CASA E TERRA"))
                .OrderBy(o => o.DS_NOME_FANTASIA)
                .ToList();

            foreach (var organizacao in organizacoesFiltradas)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning("Execução cancelada pelo usuário");
                    break;
                }

                try
                {
                    bool podeDispararFimDeSemana = await _configGeralService.PodeDispararEmailFimDeSemanaAsync(organizacao.NOME_BANCO_CRM!);

                    bool deveExecutar = DateTime.Now.DayOfWeek != DayOfWeek.Saturday 
                                     && DateTime.Now.DayOfWeek != DayOfWeek.Sunday
                                     || podeDispararFimDeSemana;

                    if (deveExecutar)
                    {
                        _logger.LogInformation("{NomeOrganizacao} - R�guas de Disparo - IN�CIO", organizacao.DS_NOME_FANTASIA);
                        
                        await ExecutarReguaCobrancaOrganizacaoAsync(organizacao, cancellationToken);
                        
                        _logger.LogInformation("{NomeOrganizacao} - R�guas de Disparo - FIM", organizacao.DS_NOME_FANTASIA);
                    }
                    else
                    {
                        _logger.LogInformation("Organiza��o {NomeOrganizacao} n�o executada - Fim de semana sem permiss�o", 
                            organizacao.DS_NOME_FANTASIA);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar organiza��o {NomeOrganizacao}", organizacao.DS_NOME_FANTASIA);
                    // Continua para pr�xima organiza��o
                }
            }

            _logger.LogInformation("Execu��o da R�gua de Cobran�a finalizada");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro no m�todo ExecutarReguaCobrancaAsync");
            throw;
        }
    }

    /// <summary>
    /// Executa a r�gua de cobran�a para uma organiza��o espec�fica
    /// Baseado em: ExecutaReguaCobrancaOrganizacao()
    /// </summary>
    public async Task ExecutarReguaCobrancaOrganizacaoAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Processando organiza��o: {NomeOrganizacao}", organizacao.DS_NOME_FANTASIA);

            // Verificar se ETL foi executado 
            var etl = await _etlService.BuscarPorOrganizacaoAsync(organizacao.ID_ORGANIZACAO);
            if (etl == null)
            {
                _logger.LogWarning("ETL n�o encontrado para organiza��o {IdOrganizacao}", organizacao.ID_ORGANIZACAO);
                return;
            }
            else if (!etl.EtlExecutadoHoje())
            {
                _logger.LogWarning("ETL não executado hoje para organiza��o {IdOrganizacao}", organizacao.ID_ORGANIZACAO);
                return;
            }

            bool flProUauExecutado = true;
            if (!string.IsNullOrEmpty(organizacao.COD_ERP_INTEGRACAO) && 
                organizacao.COD_ERP_INTEGRACAO.Equals("UAU", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogDebug("Organiza��o {IdOrganizacao} usa ERP UAU, verificando execu��o do PRO_UAU", 
                    organizacao.ID_ORGANIZACAO);
                
                if (!string.IsNullOrEmpty(organizacao.DS_URL_WEBSERVICE_CAPYS))
                {
                    flProUauExecutado = await _uauIntegracaoService.VerificaProUauExecutouAsync(
                        organizacao.DS_URL_WEBSERVICE_CAPYS);
                }
                else
                {
                    _logger.LogWarning("Organiza��o {IdOrganizacao} usa UAU mas não possui URL do webservice configurada", 
                        organizacao.ID_ORGANIZACAO);
                    flProUauExecutado = false;
                }

                if (!flProUauExecutado)
                {
                    _logger.LogWarning("PRO_UAU NA ORGANIZAÇÃO: {NomeOrganizacao} NÃO EXECUTOU", 
                        organizacao.DS_NOME_FANTASIA);
                    return;
                }
            }

            using var crmDb = await _tenantFactory.CreateDbContextAsync(organizacao.NOME_BANCO_CRM!);
            
            var reguaRepo = new ReguaCobrancaRepository(crmDb, _loggerFactory.CreateLogger<ReguaCobrancaRepository>());
            var listaReguas = await reguaRepo.ListarReguasAtivasAsync();

            foreach (var regua in listaReguas)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    await ProcessarReguaAsync(organizacao, regua, crmDb, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar r�gua {IdRegua} para organiza��o {NomeOrganizacao}", 
                        regua.ID_CASO_COBRANCA_REGUA, organizacao.DS_NOME_FANTASIA);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar r�gua de cobran�a para organiza��o {IdOrganizacao}", 
                organizacao.ID_ORGANIZACAO);
            throw;
        }
    }
    private async Task ProcessarReguaAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        ClienteMaisDbContext crmDb,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processando régua {IdRegua} - {NomeRegua}", 
                regua.ID_CASO_COBRANCA_REGUA, regua.DS_NOME_REGUA);

            // Buscar configura��o da r�gua
            var reguaConfig = await _reguaConfigService.BuscarPorReguaAsync(
                regua.ID_CASO_COBRANCA_REGUA,
                organizacao.NOME_BANCO_CRM!);

            if (reguaConfig == null)
            {
                _logger.LogWarning("Configuração não encontrada para régua {IdRegua}", regua.ID_CASO_COBRANCA_REGUA);
                return;
            }

            // Validar horário de execução da régua
            if (string.IsNullOrEmpty(reguaConfig.NR_HORA_INICIAL) || string.IsNullOrEmpty(reguaConfig.NR_HORA_FINAL))
            {
                _logger.LogWarning("Régua {NomeRegua} não processada - horários inicial ou final não configurados",
                    regua.DS_NOME_REGUA);
                return;
            }

            var horaAtual = TimeOnly.FromDateTime(DateTime.Now);
            
            if (!TimeOnly.TryParse(reguaConfig.NR_HORA_INICIAL, out var horaInicial) || 
                !TimeOnly.TryParse(reguaConfig.NR_HORA_FINAL, out var horaFinal))
            {
                _logger.LogWarning("Régua {NomeRegua} não processada - formato de horário inválido. Inicial: {HoraInicial}, Final: {HoraFinal}",
                    regua.DS_NOME_REGUA, reguaConfig.NR_HORA_INICIAL, reguaConfig.NR_HORA_FINAL);
                return;
            }

            if (horaAtual < horaInicial || horaAtual > horaFinal)
            {
                _logger.LogInformation(
                    "Régua {NomeRegua} não processada - horário fora do período permitido. Horário atual: {HoraAtual}, Permitido: {HoraInicial} - {HoraFinal}",
                    regua.DS_NOME_REGUA, horaAtual.ToString("HH:mm"), reguaConfig.NR_HORA_INICIAL, reguaConfig.NR_HORA_FINAL);
                return;
            }

            // Buscar etapas da régua
            var listaEtapas = await _reguaEtapaService.ListarPorReguaAsync(
                regua.ID_CASO_COBRANCA_REGUA, 
                organizacao.NOME_BANCO_CRM!);

            _logger.LogInformation("Régua {NomeRegua} possui {Count} etapas", regua.DS_NOME_REGUA, listaEtapas.Count);

            foreach (var etapa in listaEtapas)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // Buscar ações da etapa usando service
                    var listaAcoes = await _reguaEtapaAcaoService.ListarPorReguaEtapaAsync(
                        etapa.ID_CASO_COBRANCA_REGUA_ETAPA,
                        organizacao.NOME_BANCO_CRM!);

                    if (listaAcoes.Count != 0)
                    {
                        await ExecutarAcaoEtapaReguaAsync(organizacao, etapa, regua, reguaConfig, listaAcoes, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar etapa {IdEtapa} da r�gua {IdRegua}", 
                        etapa.ID_CASO_COBRANCA_REGUA_ETAPA, regua.ID_CASO_COBRANCA_REGUA);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar r�gua {IdRegua}", regua.ID_CASO_COBRANCA_REGUA);
            throw;
        }
    }

    /// <summary>
    /// Executa uma a��o de etapa da r�gua
    /// Baseado em: ExecutaAcaoEtapaRegua()
    /// </summary>
    public async Task ExecutarAcaoEtapaReguaAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA reguaEtapa,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG reguaConfig,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO> listaAcoes,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogDebug("Executando {Count} ações para etapa {IdEtapa}", 
                listaAcoes.Count, reguaEtapa.ID_CASO_COBRANCA_REGUA_ETAPA);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(organizacao.NOME_BANCO_CRM!);

            // Para cada Ação da Etapa
            foreach (var acao in listaAcoes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    int qtdeEnvioNoDia = 0;
                    bool existeAgendamento = true;
                    
                    if (acao.TIPO_ACAO!.FL_ACAO_AGENDADA)
                    {
                        existeAgendamento = false;
                        var agendamentos = await _agendamentoService.ObterAgendamentosPendentesAsync(
                            acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, 
                            organizacao.NOME_BANCO_CRM!);
                                              
                        foreach (var agendamento in agendamentos)
                        {
                            existeAgendamento = true;
                            await _agendamentoService.ExecutarAgendamentoAsync(
                                agendamento.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA, 
                                organizacao.NOME_BANCO_CRM!);
                        }
                    }
                    else
                    {
                        qtdeEnvioNoDia = await _historicoEnvioService.VerificarQuantidadeEnviosNoDiaAsync(
                            acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO,
                            DateTime.Now.Date,
                            organizacao.NOME_BANCO_CRM!);
                    }

                    // Processa a ação se não foi enviada hoje E (não é agendada OU tem agendamento para executar)
                    if (qtdeEnvioNoDia == 0 && existeAgendamento)
                    {
                        await ProcessarAcaoAsync(organizacao, reguaEtapa, regua, reguaConfig, acao, crmDb, cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao executar ação {IdAcao}", acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar ações da etapa {IdEtapa}", reguaEtapa.ID_CASO_COBRANCA_REGUA_ETAPA);
            throw;
        }
    }

    private async Task ProcessarAcaoAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA reguaEtapa,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG reguaConfig,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        ClienteMaisDbContext crmDb,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Processando ação {IdAcao} - {NomeAcao} - Tipo ID: {TipoAcaoId}", 
                acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, acao.DS_NOME_ACAO, acao.ID_TIPO_ACAO);

            // Buscar filtros configurados para esta ação usando service
            var listaFiltros = await _filtroService.ListarPorAcaoAsync(
                acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO,
                organizacao.NOME_BANCO_CRM!);

            // Obter tipo de ação da navigation property (Include feito no repository)
            string tipoAcao = acao.TIPO_ACAO?.DS_TIPO_ACAO!;
                
            // Buscar base de dados para mensageria conforme tipo de ação
            // Retorna DataTable para compatibilidade com lógica original
            var dtDados = await _mensageriaService.BuscarBaseMensageriaAsync(
                acao,
                cobrancaPreventiva: reguaEtapa.FL_COBRANCA_PREVENTIVA ?? false,
                nomeBancoCrm: organizacao.NOME_BANCO_CRM!);

            if (dtDados == null || dtDados.Rows.Count == 0)
            {
                _logger.LogInformation("Nenhum destinatário encontrado para ação {IdAcao}", acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
                return;
            }

            dtDados = _filtroService.AplicarFiltros(dtDados, listaFiltros);
            _logger.LogInformation("Após filtros: {Count} destinatários", dtDados.Rows.Count);
            if (dtDados is null || dtDados.Rows.Count == 0)
            {
                _logger.LogInformation("Nenhum destinatário restante após aplicação de filtros para ação {IdAcao}", 
                    acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
                return;
            }
            _logger.LogInformation("Etapa: {Etapa}, Ação: {Acao}, Tipo: {Tipo} ({Count} disparos)",
                reguaEtapa.DS_NOME_ETAPA,
                acao.DS_NOME_ACAO,
                tipoAcao,
                dtDados.Rows.Count);

            // Aplicar ordenação se tipo = DISTRIBUIÇÃO E não é cobrança preventiva
            if (!(reguaEtapa.FL_COBRANCA_PREVENTIVA ?? false) && 
                tipoAcao?.Equals("DISTRIBUIÇÃO", StringComparison.OrdinalIgnoreCase) == true)
            {
                _logger.LogDebug("Aplicando ordenação para ação tipo DISTRIBUIÇÃO");
                var listaOrdenacao = await _ordenacaoService.ListarPorEtapaAsync(
                    reguaEtapa.ID_CASO_COBRANCA_REGUA_ETAPA,
                    organizacao.NOME_BANCO_CRM!);

                if (listaOrdenacao.Count > 0)
                {
                    dtDados = _ordenacaoService.AplicarOrdenacao(dtDados, listaOrdenacao);
                    _logger.LogInformation("Ordenação aplicada: {Count} ordenações configuradas", listaOrdenacao.Count);
                }
                else
                {
                    _logger.LogDebug("Nenhuma ordenação configurada para esta etapa");
                }
            }

            // Verificar validação da régua (modo teste/homologação)
            VerificarReguaValidacao(ref dtDados, regua, reguaConfig, tipoAcao ?? string.Empty);

            if (dtDados == null || dtDados.Rows.Count == 0)
            {
                _logger.LogInformation("Nenhum destinatário após verificação de validação para ação {IdAcao}", 
                    acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
                return;
            }

            // TODO: Executar ação final (envio de email/sms/whatsapp)

            _logger.LogInformation("Ação {IdAcao} processada: {Count} destinatários válidos", 
                acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, dtDados.Rows.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar ação {IdAcao}", acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
            throw;
        }
    }

    /// <summary>
    /// Verifica a validação da régua - se não estiver validada (modo teste/homologação),
    /// substitui as colunas de email e telefone pelos valores de teste
    /// </summary>
    private void VerificarReguaValidacao(
        ref DataTable dtDados,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG reguaConfig,
        string tipoAcao)
    {
        if (dtDados == null || dtDados.Rows.Count == 0)
            return;

        // Homologar a Régua antes de Enviar
        // Se não estiver validada, redireciona para email/telefone de teste
        if (!(regua.FL_VALIDADO ?? false))
        {
            _logger.LogWarning("Régua NÃO VALIDADA - Modo teste/homologação ativo. Redirecionando para contatos de teste.");

            // Substituir coluna de email
            if (dtDados.Columns.Contains("DS_EMAIL"))
                dtDados.Columns.Remove("DS_EMAIL");
            
            DataColumn colEmail = new DataColumn("DS_EMAIL", typeof(string))
            {
                DefaultValue = reguaConfig.DS_EMAIL_RECEPTIVO_TESTE ?? string.Empty
            };
            dtDados.Columns.Add(colEmail);

            // Para tipos diferentes de "ARQUIVO TELEFONIA", substituir também telefone
            if (!tipoAcao.Equals("ARQUIVO TELEFONIA", StringComparison.OrdinalIgnoreCase))
            {
                // Substituir coluna de telefone
                if (dtDados.Columns.Contains("NR_TELEFONE"))
                    dtDados.Columns.Remove("NR_TELEFONE");
                
                DataColumn colTelefone = new DataColumn("NR_TELEFONE", typeof(string))
                {
                    DefaultValue = reguaConfig.NR_TELEFONE_RECEPTIVO_TESTE ?? string.Empty
                };
                dtDados.Columns.Add(colTelefone);

                // Substituir coluna de DDD
                if (dtDados.Columns.Contains("COD_DDD"))
                    dtDados.Columns.Remove("COD_DDD");
                
                DataColumn colDDD = new DataColumn("COD_DDD", typeof(string))
                {
                    DefaultValue = string.Empty
                };
                dtDados.Columns.Add(colDDD);
            }

            _logger.LogInformation("Dados redirecionados para email de teste: {EmailTeste}", 
                reguaConfig.DS_EMAIL_RECEPTIVO_TESTE);
        }
        else
        {
            _logger.LogDebug("Régua validada - Disparos serão enviados para destinatários reais");
        }
    }}