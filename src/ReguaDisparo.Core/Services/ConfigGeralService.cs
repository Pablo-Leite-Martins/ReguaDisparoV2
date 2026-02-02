using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciamento de configurações gerais do sistema
/// </summary>
public class ConfigGeralService : IConfigGeralService
{
    private readonly ILogger<ConfigGeralService> _logger;
    private readonly ITenantDbContextFactory _tenantFactory;

    public ConfigGeralService(
        ILogger<ConfigGeralService> logger,
        ITenantDbContextFactory tenantFactory)
    {
        _logger = logger;
        _tenantFactory = tenantFactory;
    }

    public async Task<TB_CMCRM_CONFIG_GERAL?> ObterConfiguracaoAsync(string nomeBancoCrm)
    {
        try
        {
            _logger.LogDebug("Obtendo configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ConfigGeralRepository(crmDb, (_logger as ILogger<ConfigGeralRepository>)!);

            var configuracao = await repository.ListarAsync();

            if (configuracao == null)
            {
                _logger.LogWarning("Configuração geral não encontrada para banco {NomeBancoCrm}", nomeBancoCrm);
            }

            return configuracao;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);
            throw;
        }
    }

    public async Task<bool> PodeDispararEmailFimDeSemanaAsync(string nomeBancoCrm)
    {
        try
        {
            var configuracao = await ObterConfiguracaoAsync(nomeBancoCrm);

            if (configuracao == null)
            {
                _logger.LogWarning("Configuração não encontrada para {NomeBancoCrm}. Assumindo disparo apenas em dias úteis.", nomeBancoCrm);
                return false;
            }

            var podeDisparar = configuracao.FL_COB_DISPARAR_EMAIL_COBRANCA_FIM_DE_SEMANA;
            
            _logger.LogDebug("Configuração de disparo em fim de semana para {NomeBancoCrm}: {PodeDisparar}", 
                nomeBancoCrm, podeDisparar);

            return podeDisparar;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar configuração de disparo em fim de semana para {NomeBancoCrm}", nomeBancoCrm);
            // Em caso de erro, retorna false por segurança
            return false;
        }
    }

    public async Task AtualizarConfiguracaoAsync(TB_CMCRM_CONFIG_GERAL configuracao, string nomeBancoCrm)
    {
        try
        {
            _logger.LogInformation("Atualizando configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ConfigGeralRepository(crmDb, (_logger as ILogger<ConfigGeralRepository>)!);

            await repository.AtualizarAsync(configuracao);

            _logger.LogInformation("Configuração geral atualizada com sucesso para banco {NomeBancoCrm}", nomeBancoCrm);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);
            throw;
        }
    }

    public async Task InserirConfiguracaoAsync(TB_CMCRM_CONFIG_GERAL configuracao, string nomeBancoCrm)
    {
        try
        {
            _logger.LogInformation("Inserindo configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);

            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ConfigGeralRepository(crmDb, (_logger as ILogger<ConfigGeralRepository>)!);

            await repository.InserirAsync(configuracao);

            _logger.LogInformation("Configuração geral inserida com sucesso para banco {NomeBancoCrm}", nomeBancoCrm);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir configuração geral para banco {NomeBancoCrm}", nomeBancoCrm);
            throw;
        }
    }
}
