using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar ações de etapas de régua de cobrança
/// </summary>
public class ReguaCobrancaEtapaAcaoService : IReguaCobrancaEtapaAcaoService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaEtapaAcaoService> _logger;

    public ReguaCobrancaEtapaAcaoService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaEtapaAcaoService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações de etapa de régua");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorReguaEtapaAsync(int idReguaEtapa, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoRepository>());

            return await repository.ListarPorReguaEtapaAsync(idReguaEtapa);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações para etapa {IdReguaEtapa}", idReguaEtapa);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO>> ListarPorTipoAcaoAsync(int idTipoAcao, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoRepository>());

            return await repository.ListarPorTipoAcaoAsync(idTipoAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar ações por tipo {IdTipoAcao}", idTipoAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO?> BuscarAsync(int idAcao, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoRepository>());

            return await repository.BuscarAsync(idAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ação {IdAcao}", idAcao);
            throw;
        }
    }
}
