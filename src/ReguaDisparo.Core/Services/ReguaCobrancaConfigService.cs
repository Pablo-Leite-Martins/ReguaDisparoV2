using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar configurações de régua de cobrança
/// </summary>
public class ReguaCobrancaConfigService : IReguaCobrancaConfigService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaConfigService> _logger;

    public ReguaCobrancaConfigService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaConfigService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar configurações de régua");
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarPorReguaAsync(int idRegua, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            return await repository.BuscarPorReguaAsync(idRegua);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar configuração para régua {IdRegua}", idRegua);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarAsync(int idConfig, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            return await repository.BuscarAsync(idConfig);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar configuração {IdConfig}", idConfig);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            await repository.InserirAsync(entidade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir configuração de régua");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            await repository.AtualizarAsync(entidade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar configuração {IdConfig}", entidade.ID_CASO_COBRANCA_REGUA_CONFIG);
            throw;
        }
    }

    public async Task ExcluirAsync(int idConfig, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaConfigRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaConfigRepository>());

            await repository.ExcluirAsync(idConfig);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir configuração {IdConfig}", idConfig);
            throw;
        }
    }
}
