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
                .Where(o => o.ID_ORGANIZACAO != "PLANET_SMART_CITIES" 
                         && o.ID_ORGANIZACAO != "TERIVA_URBANISMO"
                         && o.ID_ORGANIZACAO != "EMCCAMP"
                         && o.ID_ORGANIZACAO != "HABITAT"
                         && o.ID_ORGANIZACAO != "RESECOM_CONSTRUTORA_LTDA"
                         && o.ID_ORGANIZACAO != "RESECOM_TRINUS"
                         && o.ID_ORGANIZACAO != "COLORADO_MEGA")
                .OrderByDescending(o => o.NOME_BANCO_CRM)
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

            using var crmDb = await _tenantFactory.CreateDbContextAsync(organizacao.ID_ORGANIZACAO!);
            
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
                    // Buscar a��es da etapa
                    var acaoRepo = new ReguaCobrancaEtapaAcaoRepository(crmDb, _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoRepository>());
                    var listaAcoes = await acaoRepo.ListarPorReguaEtapaAsync(etapa.ID_CASO_COBRANCA_REGUA_ETAPA);

                    if (listaAcoes.Any())
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
                    
                    if (acao.FL_ACAO_AGENDADA)
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
        _logger.LogInformation("Processando ação {IdAcao} - {NomeAcao} - Tipo ID: {TipoAcaoId}", 
            acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, acao.DS_NOME_ACAO, acao.ID_TIPO_ACAO);

        // TODO: Buscar dados base conforme tipo de ação
        // Por enquanto, vamos implementar a estrutura básica
        
        // Buscar filtros configurados
        var filtroRepo = new ReguaCobrancaEtapaAcaoFiltroRepository(
            crmDb,
            _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoFiltroRepository>());
        
        var listaFiltros = await filtroRepo.ListarPorAcaoAsync(acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);

        // TODO: Implementar busca de dados base (ver ListaBaseMensageria, etc do projeto antigo)
        // TODO: Aplicar filtros aos dados
        // TODO: Aplicar ordenação se necessário
        // TODO: Verificar validação da régua
        // TODO: Executar ação final (envio)

        _logger.LogInformation("Ação {IdAcao} processada com sucesso", acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
    }
}
