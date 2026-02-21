using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

/// <summary>
/// Repositório de stored procedures do banco ClienteMais CRM
/// Retorna DataTable para compatibilidade com lógica original
/// As stored procedures são executadas através do DbContext
/// </summary>
public class ClienteMaisStoredProceduresRepository : IClienteMaisStoredProceduresRepository
{
    private readonly ClienteMaisDbContext _context;
    private readonly ILogger<ClienteMaisStoredProceduresRepository> _logger;

    public ClienteMaisStoredProceduresRepository(
        ClienteMaisDbContext context,
        ILogger<ClienteMaisStoredProceduresRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DataTable> BuscarBaseMensageriaCobrancaAsync(DateTime dataInicio)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de cobrança desde {DataInicio}", dataInicio);

            var dtMesReferencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dtResult = await _context.ListaBaseMensageriaAsync(dtMesReferencia);
            
            _logger.LogInformation("Base de mensageria de cobrança retornou {Count} registros", dtResult.Rows.Count);
            return dtResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de cobrança");
            throw;
        }
    }

    public async Task<DataTable> BuscarBaseMensageriaParcelasAsync(DateTime dataInicio)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de parcelas desde {DataInicio}", dataInicio);

            var dtMesReferencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dtResult = await _context.ListaBaseMensageriaParcelasAsync(dtMesReferencia);
            
            _logger.LogInformation("Base de mensageria de parcelas retornou {Count} registros", dtResult.Rows.Count);
            return dtResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de parcelas");
            throw;
        }
    }

    public async Task<DataTable> BuscarBaseMensageriaAReceberAsync(DateTime dataInicio)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria a receber (preventiva) desde {DataInicio}", dataInicio);

            var dtMesReferencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dtResult = await _context.ListaBaseMensageriaAReceberAsync(dtMesReferencia);
            
            _logger.LogInformation("Base de mensageria a receber retornou {Count} registros", dtResult.Rows.Count);
            return dtResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria a receber");
            throw;
        }
    }

    public async Task<DataTable> BuscarBaseMensageriaPosOcupacionalAsync()
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria pós-ocupacional");

            // TODO: Substituir por EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_POS_OCUPACIONAL quando procedure existir
            
            var sql = @"
                SELECT 
                    c.ID_EMPRESA,
                    c.ID_OBRA,
                    c.ID_VENDA,
                    p.DS_NOME as DS_CLIENTE,
                    p.DS_EMAIL,
                    p.COD_DDD,
                    p.NR_TELEFONE,
                    v.DT_ENTREGA_CHAVES
                FROM TB_CMREC_CONTA c WITH(NOLOCK)
                INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
                LEFT JOIN TB_CMVEN_VENDA v WITH(NOLOCK) ON c.ID_VENDA = v.ID_VENDA
                WHERE v.DT_ENTREGA_CHAVES IS NOT NULL
                    AND DATEDIFF(DAY, v.DT_ENTREGA_CHAVES, GETDATE()) >= 30
                    AND DATEDIFF(DAY, v.DT_ENTREGA_CHAVES, GETDATE()) <= 90
                    AND p.DS_EMAIL IS NOT NULL
                    AND p.DS_EMAIL <> ''
                ORDER BY v.DT_ENTREGA_CHAVES DESC";

            var dtResult = await ExecutarQueryAsync(sql);
            
            _logger.LogInformation("Base de mensageria pós-ocupacional retornou {Count} registros", dtResult.Rows.Count);
            return dtResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria pós-ocupacional");
            throw;
        }
    }

    public async Task<DataTable> BuscarBaseMensageriaRelacionamentoAsync(bool apenasAniversariantes)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de relacionamento (aniversariantes: {Flag})", apenasAniversariantes);

            var dtMesReferencia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dtResult = await _context.ListaBaseMailRelacionamentoComClienteAsync(apenasAniversariantes);
            
            _logger.LogInformation("Base de mensageria de relacionamento retornou {Count} registros", dtResult.Rows.Count);
            return dtResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de relacionamento");
            throw;
        }
    }

    /// <summary>
    /// Método helper para executar query e retornar DataTable
    /// </summary>
    private async Task<DataTable> ExecutarQueryAsync(string sql, SqlParameter[]? parameters = null)
    {
        var dt = new DataTable();
        
        var connection = _context.Database.GetDbConnection();
        var needsClose = connection.State != ConnectionState.Open;
        
        try
        {
            if (needsClose)
            {
                await connection.OpenAsync();
            }

            using var command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandTimeout = 300; // 5 minutos

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using var reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            
            return dt;
        }
        finally
        {
            if (needsClose && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
