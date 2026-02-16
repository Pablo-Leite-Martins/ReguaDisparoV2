using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar histórico de envios das ações da régua de cobrança
/// </summary>
public class ReguaCobrancaHistoricoEnvioService : IReguaCobrancaHistoricoEnvioService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaHistoricoEnvioService> _logger;

    public ReguaCobrancaHistoricoEnvioService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaHistoricoEnvioService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoEnvioRepository>());

            return await repository.ListarPorReguaEtapaAcaoAsync(idAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de envio para ação {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO?> ObterPorIdAsync(int id, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoEnvioRepository>());

            return await repository.BuscarAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter histórico de envio {Id}", id);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO> AdicionarAsync(
        TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO historicoEnvio, 
        string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoEnvioRepository>());

            await repository.InserirAsync(historicoEnvio);
            return historicoEnvio;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao adicionar histórico de envio");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO historicoEnvio, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            // Repositório não tem método de atualização, apenas inserção
            // Se precisar, implementar no repositório primeiro
            _logger.LogWarning("Método AtualizarAsync não implementado no repositório");
            throw new NotImplementedException("Método AtualizarAsync não disponível no repositório");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar histórico de envio {Id}", historicoEnvio.ID_CASO_COBRANCA_REGUA_HISTORICO_ENVIO);
            throw;
        }
    }

    public async Task RemoverAsync(int id, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            // Repositório não tem método de remoção
            // Se precisar, implementar no repositório primeiro
            _logger.LogWarning("Método RemoverAsync não implementado no repositório");
            throw new NotImplementedException("Método RemoverAsync não disponível no repositório");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover histórico de envio {Id}", id);
            throw;
        }
    }

    public async Task<int> VerificarQuantidadeEnviosNoDiaAsync(int idAcao, DateTime data, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoEnvioRepository>());

            return await repository.QuantidadeRegistrosDataAsync(idAcao, data);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar quantidade de envios no dia {Data} para ação {IdAcao}", data, idAcao);
            return 0;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO>> ListarPorPeriodoAsync(
        int idAcao,
        DateTime dataInicio,
        DateTime dataFim,
        string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaHistoricoEnvioRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaHistoricoEnvioRepository>());

            // Repositório não tem método específico para período
            // Busca todos e filtra em memória (não é ideal, mas funciona)
            var historicos = await repository.ListarPorReguaEtapaAcaoAsync(idAcao);
            return historicos
                .Where(h => h.DT_ENVIO >= dataInicio && h.DT_ENVIO <= dataFim)
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar históricos de envio por período para ação {IdAcao}", idAcao);
            throw;
        }
    }
}
