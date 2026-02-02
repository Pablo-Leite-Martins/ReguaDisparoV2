using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

public class ConfigGeralRepository : IConfigGeralRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ConfigGeralRepository> _logger;

    public ConfigGeralRepository(
        ClienteMaisDbContext context,
        ILogger<ConfigGeralRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TB_CMCRM_CONFIG_GERAL?> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando configuração geral");

            var config = await _context.TB_CMCRM_CONFIG_GERALs
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return config;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar configuração geral");
            throw;
        }
    }

    public async Task InserirAsync(TB_CMCRM_CONFIG_GERAL entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo configuração geral");

            _context.TB_CMCRM_CONFIG_GERALs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Configuração geral inserida com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir configuração geral");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CONFIG_GERAL entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando configuração geral");

            _context.TB_CMCRM_CONFIG_GERALs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Configuração geral atualizada com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar configuração geral");
            throw;
        }
    }
}
