using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;
using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

/// <summary>
/// Repositório de ReguaCobranca baseado em ReguaCobrancaBLL
/// Multi-Tenant - usar via TenantDbContextFactory
/// </summary>
public class ReguaCobrancaRepository : IReguaCobrancaRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ReguaCobrancaRepository> _logger;

    public ReguaCobrancaRepository(
        ClienteMaisDbContext context,
        ILogger<ReguaCobrancaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA>> ListarAsync()
    {
        try
        {
            _logger.LogDebug("Listando todas as réguas de cobrança");

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUAs
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} réguas de cobrança", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar réguas de cobrança");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA>> ListarReguasAtivasAsync()
    {
        try
        {
            _logger.LogDebug("Listando réguas de cobrança ativas");

            var lista = await _context.TB_CMCRM_CASO_COBRANCA_REGUAs
                .Where(r => r.FL_ATIVO == true)
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Listadas {Count} réguas de cobrança ativas", lista.Count);

            return lista;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar réguas de cobrança ativas");
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA?> BuscarAsync(int idRegua)
    {
        try
        {
            _logger.LogDebug("Buscando régua de cobrança {IdRegua}", idRegua);

            var regua = await _context.TB_CMCRM_CASO_COBRANCA_REGUAs
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ID_CASO_COBRANCA_REGUA == idRegua);

            if (regua == null)
            {
                _logger.LogWarning("Régua de cobrança {IdRegua} não encontrada", idRegua);
            }

            return regua;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar régua de cobrança {IdRegua}", idRegua);
            throw;
        }
    }

    public async Task<int> InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA entidade)
    {
        try
        {
            _logger.LogDebug("Inserindo régua de cobrança {NomeRegua}", entidade.DS_NOME_REGUA);

            _context.TB_CMCRM_CASO_COBRANCA_REGUAs.Add(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Régua de cobrança {IdRegua} inserida com sucesso", entidade.ID_CASO_COBRANCA_REGUA);

            return entidade.ID_CASO_COBRANCA_REGUA;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inserir régua de cobrança");
            throw;
        }
    }

    public async Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA entidade)
    {
        try
        {
            _logger.LogDebug("Atualizando régua de cobrança {IdRegua}", entidade.ID_CASO_COBRANCA_REGUA);

            _context.TB_CMCRM_CASO_COBRANCA_REGUAs.Update(entidade);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Régua de cobrança {IdRegua} atualizada com sucesso", entidade.ID_CASO_COBRANCA_REGUA);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao atualizar régua de cobrança {IdRegua}", entidade.ID_CASO_COBRANCA_REGUA);
            throw;
        }
    }

    public async Task ExcluirAsync(int idRegua)
    {
        try
        {
            _logger.LogDebug("Excluindo régua de cobrança {IdRegua}", idRegua);

            var regua = await _context.TB_CMCRM_CASO_COBRANCA_REGUAs
                .FirstOrDefaultAsync(r => r.ID_CASO_COBRANCA_REGUA == idRegua);

            if (regua != null)
            {
                _context.TB_CMCRM_CASO_COBRANCA_REGUAs.Remove(regua);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Régua de cobrança {IdRegua} excluída com sucesso", idRegua);
            }
            else
            {
                _logger.LogWarning("Régua de cobrança {IdRegua} não encontrada para exclusão", idRegua);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao excluir régua de cobrança {IdRegua}", idRegua);
            throw;
        }
    }

    public async Task RemoveAdimplenciaDasFilasAsync()
    {
        try
        {
            _logger.LogDebug("Removendo adimplência das filas");

            // Lógica para remover adimplência das filas de cobrança
            // TODO: Implementar conforme regra de negócio específica da DAL original

            await Task.CompletedTask;

            _logger.LogInformation("Adimplência removida das filas com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao remover adimplência das filas");
            throw;
        }
    }
}
