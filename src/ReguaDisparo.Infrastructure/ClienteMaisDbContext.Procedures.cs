using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ReguaDisparo.Infrastructure;

/// <summary>
/// Partial class do ClienteMaisDbContext contendo métodos para stored procedures
/// Retorna DataTable diretamente sem necessidade de DTOs
/// </summary>
public partial class ClienteMaisDbContext
{
    /// <summary>
    /// Executa a procedure CMCRM_sp_ListaBaseMensageria
    /// </summary>
    public async Task<DataTable> ListaBaseMensageriaAsync(DateTime dtMesReferencia)
    {
        var parameter = new SqlParameter("@DT_MES_REFERENCIA", SqlDbType.DateTime) { Value = dtMesReferencia };
        return await ExecutarStoredProcedureAsync("CMCRM_sp_ListaBaseMensageria", parameter);
    }

    /// <summary>
    /// Executa a procedure CMCRM_sp_ListaBaseMensageriaParcelas
    /// </summary>
    public async Task<DataTable> ListaBaseMensageriaParcelasAsync(DateTime dtMesReferencia)
    {
        var parameter = new SqlParameter("@DT_MES_REFERENCIA", SqlDbType.DateTime) { Value = dtMesReferencia };
        return await ExecutarStoredProcedureAsync("CMCRM_sp_ListaBaseMensageriaParcelas", parameter);
    }

    /// <summary>
    /// Executa a procedure CMCRM_sp_ListaBaseMensageriaAReceber
    /// </summary>
    public async Task<DataTable> ListaBaseMensageriaAReceberAsync(DateTime dtMesReferencia)
    {
        var parameter = new SqlParameter("@DT_MES_REFERENCIA", SqlDbType.DateTime) { Value = dtMesReferencia };
        return await ExecutarStoredProcedureAsync("CMCRM_sp_ListaBaseMensageriaAReceber", parameter);
    }

    /// <summary>
    /// Executa a procedure CMCRM_sp_ListaBaseMailRelacionamentoComCliente
    /// </summary>
    public async Task<DataTable> ListaBaseMailRelacionamentoComClienteAsync(bool flAniversariante)
    {
        var parameters = new[]
        {
            new SqlParameter("@FL_ANIVERSARIANTE", SqlDbType.Bit) { Value = flAniversariante }
        };
        return await ExecutarStoredProcedureAsync("CMCRM_sp_ListaBaseMailRelacionamentoComCliente", parameters);
    }

    /// <summary>
    /// Método helper para executar stored procedure e retornar DataTable
    /// </summary>
    private async Task<DataTable> ExecutarStoredProcedureAsync(string procedureName, params SqlParameter[] parameters)
    {
        var dt = new DataTable();
        var connection = Database.GetDbConnection();
        var needsClose = connection.State != ConnectionState.Open;

        try
        {
            if (needsClose)
            {
                await connection.OpenAsync();
            }

            using var command = connection.CreateCommand();
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 300; // 5 minutos

            if (parameters != null && parameters.Length > 0)
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
