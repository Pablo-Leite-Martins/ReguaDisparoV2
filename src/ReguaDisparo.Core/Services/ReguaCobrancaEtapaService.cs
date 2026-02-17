using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar etapas de régua de cobrança
/// </summary>
public class ReguaCobrancaEtapaService : IReguaCobrancaEtapaService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaEtapaService> _logger;

    public ReguaCobrancaEtapaService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaEtapaService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar etapas de régua");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarPorReguaAsync(int idRegua, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            return await repository.ListarPorReguaAsync(idRegua);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar etapas para régua {IdRegua}", idRegua);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA?> BuscarAsync(int idEtapa, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            return await repository.BuscarAsync(idEtapa);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar etapa {IdEtapa}", idEtapa);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            await repository.InserirAsync(entidade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir etapa de régua");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            await repository.AtualizarAsync(entidade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar etapa {IdEtapa}", entidade.ID_CASO_COBRANCA_REGUA_ETAPA);
            throw;
        }
    }

    public async Task ExcluirAsync(int idEtapa, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaRepository>());

            await repository.ExcluirAsync(idEtapa);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir etapa {IdEtapa}", idEtapa);
            throw;
        }
    }
}
