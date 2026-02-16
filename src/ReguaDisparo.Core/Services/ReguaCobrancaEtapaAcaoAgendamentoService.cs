using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciamento de agendamentos de ações de régua de cobrança
/// </summary>
public class ReguaCobrancaEtapaAcaoAgendamentoService : IReguaCobrancaEtapaAcaoAgendamentoService
{
    private readonly ILogger<ReguaCobrancaEtapaAcaoAgendamentoService> _logger;
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;

    public ReguaCobrancaEtapaAcaoAgendamentoService(
        ILogger<ReguaCobrancaEtapaAcaoAgendamentoService> logger,
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Listando todos os agendamentos para banco {NomeBancoCrm}", nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar agendamentos para banco {NomeBancoCrm}", nomeBancoCrm);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarPorEtapaAcaoAsync(int idEtapaAcao, string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Listando agendamentos para etapa ação {IdEtapaAcao} no banco {NomeBancoCrm}", 
                idEtapaAcao, nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            return await repository.ListarPorEtapaAcaoAsync(idEtapaAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar agendamentos para etapa ação {IdEtapaAcao}", idEtapaAcao);
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ObterAgendamentosPendentesAsync(int idEtapaAcao, string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Obtendo agendamentos pendentes para etapa ação {IdEtapaAcao}", idEtapaAcao);

            var agendamentos = await ListarPorEtapaAcaoAsync(idEtapaAcao, nomeBancoCrm);
            
            return agendamentos
                .Where(x => !x.FL_ENVIADO)
                .OrderBy(x => x.DT_ENVIO)
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter agendamentos pendentes para etapa ação {IdEtapaAcao}", idEtapaAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA?> BuscarAsync(int idAgenda, string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Buscando agendamento {IdAgenda} no banco {NomeBancoCrm}", idAgenda, nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            return await repository.BuscarAsync(idAgenda);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar agendamento {IdAgenda}", idAgenda);
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade, string nomeBancoCrm)
    {
        try
        {
            _logger.LogInformation("Inserindo agendamento para etapa ação {IdEtapaAcao} no banco {NomeBancoCrm}", 
                entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO, nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            await repository.InserirAsync(entidade);

            _logger.LogInformation("Agendamento inserido com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir agendamento");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade, string nomeBancoCrm)
    {
        try
        {
            _logger.LogInformation("Atualizando agendamento {IdAgendamento} no banco {NomeBancoCrm}", 
                entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA, nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            await repository.AtualizarAsync(entidade);

            _logger.LogInformation("Agendamento atualizado com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar agendamento {IdAgendamento}", 
                entidade.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA);
            throw;
        }
    }

    public async Task ExecutarAgendamentoAsync(int idAgendamento, string nomeBancoCrm)
    {
        try
        {
            _logger.LogInformation("Executando agendamento {IdAgendamento} no banco {NomeBancoCrm}", 
                idAgendamento, nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            await repository.ExecutarAgendamentoAsync(idAgendamento);

            _logger.LogInformation("Agendamento {IdAgendamento} executado com sucesso", idAgendamento);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar agendamento {IdAgendamento}", idAgendamento);
            throw;
        }
    }

    public async Task<bool> VerificarSeAcaoTemAgendamentosAsync(int idEtapaAcao, string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Verificando se etapa ação {IdEtapaAcao} possui agendamentos", idEtapaAcao);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoAgendamentoRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoAgendamentoRepository>());

            var agendamentos = await repository.ListarPorEtapaAcaoAsync(idEtapaAcao);
            return agendamentos.Any();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar se etapa ação {IdEtapaAcao} possui agendamentos", idEtapaAcao);
            return false;
        }
    }
}
