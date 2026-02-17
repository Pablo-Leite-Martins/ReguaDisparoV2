using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar histórico de não envios da régua de cobrança
/// </summary>
public class ReguaCobrancaHistoricoNaoEnvioService : IReguaCobrancaHistoricoNaoEnvioService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaHistoricoNaoEnvioService> _logger;

    public ReguaCobrancaHistoricoNaoEnvioService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaHistoricoNaoEnvioService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de não envio");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            return await repository.ListarPorAcaoAsync(idAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de não envio para ação {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO?> BuscarAsync(int id, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            return await repository.BuscarAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar histórico de não envio {Id}", id);
            throw;
        }
    }

    public async Task RegistrarFalhaAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO falha, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            await repository.InserirAsync(falha);
            
            _logger.LogInformation("Falha de envio registrada para ação {IdAcao}: {Mensagem}", 
                falha.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, 
                falha.DS_MESSAGE);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar falha de envio");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO entidade, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            await repository.AtualizarAsync(entidade);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar histórico de não envio {Id}", entidade.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
            throw;
        }
    }

    public async Task ExcluirAsync(int id, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoNaoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoNaoEnvioRepository>());

            await repository.ExcluirAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir histórico de não envio {Id}", id);
            throw;
        }
    }
}
