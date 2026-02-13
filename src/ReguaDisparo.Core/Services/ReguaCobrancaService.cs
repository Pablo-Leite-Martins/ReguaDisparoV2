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

/// <summary>
/// Servi�o principal de R�gua de Cobran�a
/// Baseado em CAPYS_ReguaDisparo_Model.cs do projeto antigo
/// </summary>
public class ReguaCobrancaService : IReguaCobrancaService
{
    private readonly ILogger<ReguaCobrancaService> _logger;
    private readonly IConfiguration _configuration;
    private readonly IOrganizacaoService _organizacaoService;
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly IEmailService _emailService;
    private readonly IConfigGeralService _configGeralService;
    private readonly IEtlService _etlService;
    private readonly IUauIntegracaoService _uauIntegracaoService;

    // Constantes do projeto antigo
    private const int NUM_MAX_SMS = 999999;
    private const int NUM_MAX_EMAIL = 999999;

    public ReguaCobrancaService(
        ILogger<ReguaCobrancaService> logger,
        IConfiguration configuration,
        IOrganizacaoService organizacaoService,
        ITenantDbContextFactory tenantFactory,
        IEmailService emailService,
        IConfigGeralService configGeralService,
        IEtlService etlService,
        IUauIntegracaoService uauIntegracaoService)
    {
        _logger = logger;
        _configuration = configuration;
        _organizacaoService = organizacaoService;
        _tenantFactory = tenantFactory;
        _emailService = emailService;
        _configGeralService = configGeralService;
        _etlService = etlService;
        _uauIntegracaoService = uauIntegracaoService;
    }

    /// <summary>
    /// Executa a r�gua de cobran�a para todas as organiza��es ativas
    /// Baseado em: ExecutaReguaCobranca()
    /// </summary>
    public async Task ExecutarReguaCobrancaAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("pt-BR");

            _logger.LogInformation("Iniciando execução da Régua de Cobrança para todas as organizações");

            // Lista organizações ativas (baseado no código antigo com filtros)
            var listaOrganizacao = await _organizacaoService.ListarAtivasAsync();

            // Filtrar organizações conforme lógica do projeto antigo
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

            _logger.LogInformation("Encontradas {Count} organiza��es ativas para processar", organizacoesFiltradas.Count);

            foreach (var organizacao in organizacoesFiltradas)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogWarning("Execu��o cancelada pelo usu�rio");
                    break;
                }

                try
                {
                    // Verificar configuração de fim de semana
                    bool podeDispararFimDeSemana = await _configGeralService.PodeDispararEmailFimDeSemanaAsync(organizacao.NOME_BANCO_CRM!);

                    bool deveExecutar = DateTime.Now.DayOfWeek != DayOfWeek.Saturday 
                                     && DateTime.Now.DayOfWeek != DayOfWeek.Sunday
                                     || podeDispararFimDeSemana;

                    if (deveExecutar)
                    {
                        _logger.LogInformation("=".PadRight(100, '='));
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

            // Verificar se PRO_UAU foi executado (apenas para ERP UAU)
            bool flProUauExecutado = false;
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
                }

                if (!flProUauExecutado)
                {
                    _logger.LogWarning("PRO_UAU NA ORGANIZAÇÃO: {NomeOrganizacao} NÃO EXECUTOU", 
                        organizacao.DS_NOME_FANTASIA);
                    return;
                }
            }

            // Criar contexto multi-tenant para esta organização
            using var crmDb = await _tenantFactory.CreateDbContextAsync(organizacao.ID_ORGANIZACAO!);
            
            // Buscar r�guas ativas
            var reguaRepo = new ReguaCobrancaRepository(crmDb, (_logger as ILogger<ReguaCobrancaRepository>)!);
            var listaReguas = await reguaRepo.ListarReguasAtivasAsync();

            _logger.LogInformation("Encontradas {Count} r�guas ativas para {NomeOrganizacao}", 
                listaReguas.Count, organizacao.DS_NOME_FANTASIA);

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

    /// <summary>
    /// Processa uma r�gua espec�fica
    /// L�gica extra�da do ExecutaReguaCobrancaOrganizacao
    /// </summary>
    private async Task ProcessarReguaAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        ClienteMaisDbContext crmDb,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processando r�gua {IdRegua} - {NomeRegua}", 
                regua.ID_CASO_COBRANCA_REGUA, regua.DS_NOME_REGUA);

            // Buscar configura��o da r�gua
            var reguaConfig = await crmDb.TB_CMCRM_CASO_COBRANCA_REGUA_CONFIGs
                .FirstOrDefaultAsync(c => c.ID_CASO_COBRANCA_REGUA == regua.ID_CASO_COBRANCA_REGUA, cancellationToken);

            if (reguaConfig == null)
            {
                _logger.LogWarning("Configura��o n�o encontrada para r�gua {IdRegua}", regua.ID_CASO_COBRANCA_REGUA);
                return;
            }

            // Buscar etapas da r�gua
            var listaEtapas = await crmDb.TB_CMCRM_CASO_COBRANCA_REGUA_ETAPAs
                .Where(e => e.ID_CASO_COBRANCA_REGUA == regua.ID_CASO_COBRANCA_REGUA)
                .OrderBy(e => e.NR_ETAPA)
                .ToListAsync(cancellationToken);

            _logger.LogInformation("R�gua {NomeRegua} possui {Count} etapas", regua.DS_NOME_REGUA, listaEtapas.Count);

            foreach (var etapa in listaEtapas)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // Buscar a��es da etapa
                    var acaoRepo = new ReguaCobrancaEtapaAcaoRepository(crmDb, (_logger as ILogger<ReguaCobrancaEtapaAcaoRepository>)!);
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
            _logger.LogDebug("Executando {Count} a��es para etapa {IdEtapa}", 
                listaAcoes.Count, reguaEtapa.ID_CASO_COBRANCA_REGUA_ETAPA);

            foreach (var acao in listaAcoes)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // TODO: Implementar l�gica completa de cada tipo de a��o
                    // Baseado no c�digo antigo, temos v�rios tipos de a��o:
                    // - EMAIL
                    // - SMS
                    // - WHATSAPP
                    // - ARQUIVO TELEFONIA
                    // - FGR - COMUNICADO 3
                    // - FGR - COMUNICADO 6
                    // - MAC - COBRAN�A
                    // - RE - CARTA COBRAN�A
                    // etc...

                    _logger.LogInformation("Processando a��o {IdAcao} - Tipo: {TipoAcao}", 
                        acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, acao.ID_TIPO_ACAO);

                    // A implementa��o completa vir� nas pr�ximas etapas
                    // Por enquanto, apenas logging
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao executar a��o {IdAcao}", acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar a��es da etapa {IdEtapa}", reguaEtapa.ID_CASO_COBRANCA_REGUA_ETAPA);
            throw;
        }
    }
}
