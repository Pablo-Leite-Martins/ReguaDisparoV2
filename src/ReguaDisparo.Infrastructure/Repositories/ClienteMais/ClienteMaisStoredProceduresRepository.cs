using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;

namespace ReguaDisparo.Infrastructure.Repositories.ClienteMais;

/// <summary>
/// Repositório de stored procedures do banco ClienteMais CRM
/// NOTA: Procedures SQL precisam ser criadas no banco. 
/// Implementação temporária usa queries diretas até procedures serem criadas.
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

    public async Task<List<BaseMensageriaCobranca>> BuscarBaseMensageriaCobrancaAsync(DateTime dataInicio)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de cobrança desde {DataInicio}", dataInicio);

            // TODO: Substituir por EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_COBRANCA quando procedure existir
            // Por ora, implementa query direta (será mais lento, mas funcional)
            
            var sql = @"
                SELECT DISTINCT
                    c.ID_EMPRESA,
                    c.ID_OBRA,
                    c.ID_VENDA,
                    p.DS_NOME as DS_CLIENTE,
                    p.DS_EMAIL,
                    p.COD_DDD,
                    p.NR_TELEFONE,
                    prod.DS_PRODUTO,
                    c.ID_CHAVE_ERP,
                    c.ID_IDENTIFICADOR as DS_IDENTIFICADOR,
                    c.DS_CLASSIFICACAO_CONTRATO,
                    DATEDIFF(DAY, MIN(pc.DT_VENCIMENTO), GETDATE()) as NR_AGING_DIAS_CONTRATO,
                    SUM(CASE WHEN pc.DT_VENCIMENTO < GETDATE() THEN pc.VL_VALOR ELSE 0 END) as VL_TOTAL_VENCIDO,
                    SUM(CASE WHEN pc.DT_VENCIMENTO >= GETDATE() THEN pc.VL_VALOR ELSE 0 END) as VL_TOTAL_A_VENCER,
                    MIN(pc.DT_VENCIMENTO) as DT_VENCIMENTO_MAIS_ANTIGO,
                    COUNT(CASE WHEN pc.DT_VENCIMENTO < GETDATE() AND pc.FL_LIQUIDADO = 0 THEN 1 END) as QT_PARCELAS_VENCIDAS
                FROM TB_CMREC_CONTA c WITH(NOLOCK)
                INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
                LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
                LEFT JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
                WHERE pc.FL_LIQUIDADO = 0 
                    AND pc.DT_VENCIMENTO < GETDATE()
                    AND p.DS_EMAIL IS NOT NULL
                    AND p.DS_EMAIL <> ''
                GROUP BY 
                    c.ID_EMPRESA, c.ID_OBRA, c.ID_VENDA, p.DS_NOME, p.DS_EMAIL, 
                    p.COD_DDD, p.NR_TELEFONE, prod.DS_PRODUTO, c.ID_CHAVE_ERP,
                    c.ID_IDENTIFICADOR, c.DS_CLASSIFICACAO_CONTRATO
                HAVING COUNT(CASE WHEN pc.DT_VENCIMENTO < GETDATE() AND pc.FL_LIQUIDADO = 0 THEN 1 END) > 0
                ORDER BY NR_AGING_DIAS_CONTRATO DESC";

            var result = await _context.Database
                .SqlQueryRaw<BaseMensageriaCobranca>(sql)
                .ToListAsync();

            _logger.LogInformation("Base de mensageria de cobrança retornou {Count} registros", result.Count);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de cobrança");
            throw;
        }
    }

    public async Task<List<BaseMensageriaParcelas>> BuscarBaseMensageriaParcelasAsync(DateTime dataInicio, bool incluirTodasEmpresas = false)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de parcelas desde {DataInicio}", dataInicio);

            // TODO: Substituir por EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_PARCELAS quando procedure existir
            
            var sql = @"
                SELECT 
                    c.ID_EMPRESA,
                    c.ID_OBRA,
                    c.ID_VENDA,
                    p.DS_NOME as DS_CLIENTE,
                    p.DS_EMAIL,
                    p.COD_DDD,
                    p.NR_TELEFONE,
                    prod.DS_PRODUTO,
                    pc.NR_PARCELA,
                    pc.DT_VENCIMENTO,
                    pc.VL_VALOR as VL_PARCELA,
                    c.DS_CLASSIFICACAO_CONTRATO
                FROM TB_CMREC_CONTA c WITH(NOLOCK)
                INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
                LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
                INNER JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
                WHERE pc.FL_LIQUIDADO = 0 
                    AND pc.DT_VENCIMENTO >= @dataInicio
                    AND p.DS_EMAIL IS NOT NULL
                    AND p.DS_EMAIL <> ''
                ORDER BY pc.DT_VENCIMENTO, p.DS_NOME";

            var parameters = new[] { new SqlParameter("@dataInicio", dataInicio) };
            
            var result = await _context.Database
                .SqlQueryRaw<BaseMensageriaParcelas>(sql, parameters)
                .ToListAsync();

            _logger.LogInformation("Base de mensageria de parcelas retornou {Count} registros", result.Count);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de parcelas");
            throw;
        }
    }

    public async Task<List<BaseMensageriaAReceber>> BuscarBaseMensageriaAReceberAsync(DateTime dataInicio, bool incluirTodasEmpresas = false)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria a receber (preventiva) desde {DataInicio}", dataInicio);

            // TODO: Substituir por EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_A_RECEBER quando procedure existir
            
            var sql = @"
                SELECT 
                    c.ID_EMPRESA,
                    c.ID_OBRA,
                    c.ID_VENDA,
                    p.DS_NOME as DS_CLIENTE,
                    p.DS_EMAIL,
                    p.COD_DDD,
                    p.NR_TELEFONE,
                    prod.DS_PRODUTO,
                    MIN(pc.DT_VENCIMENTO) as DT_VENCIMENTO_PROXIMO,
                    SUM(pc.VL_VALOR) as VL_PROXIMO_VENCIMENTO,
                    DATEDIFF(DAY, GETDATE(), MIN(pc.DT_VENCIMENTO)) as DIAS_ATE_VENCIMENTO
                FROM TB_CMREC_CONTA c WITH(NOLOCK)
                INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
                LEFT JOIN TB_CMCAD_PRODUTO prod WITH(NOLOCK) ON c.ID_PRODUTO = prod.ID_PRODUTO
                INNER JOIN TB_CMREC_CONTA_PARCELA pc WITH(NOLOCK) ON c.ID_CONTA = pc.ID_CONTA
                WHERE pc.FL_LIQUIDADO = 0 
                    AND pc.DT_VENCIMENTO > GETDATE()
                    AND pc.DT_VENCIMENTO >= @dataInicio
                    AND DATEDIFF(DAY, GETDATE(), pc.DT_VENCIMENTO) <= 30
                    AND p.DS_EMAIL IS NOT NULL
                    AND p.DS_EMAIL <> ''
                GROUP BY 
                    c.ID_EMPRESA, c.ID_OBRA, c.ID_VENDA, p.DS_NOME, 
                    p.DS_EMAIL, p.COD_DDD, p.NR_TELEFONE, prod.DS_PRODUTO
                ORDER BY DT_VENCIMENTO_PROXIMO";

            var parameters = new[] { new SqlParameter("@dataInicio", dataInicio) };
            
            var result = await _context.Database
                .SqlQueryRaw<BaseMensageriaAReceber>(sql, parameters)
                .ToListAsync();

            _logger.LogInformation("Base de mensageria a receber retornou {Count} registros", result.Count);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria a receber");
            throw;
        }
    }

    public async Task<List<BaseMensageriaPosOcupacional>> BuscarBaseMensageriaPosOcupacionalAsync()
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

            var result = await _context.Database
                .SqlQueryRaw<BaseMensageriaPosOcupacional>(sql)
                .ToListAsync();

            _logger.LogInformation("Base de mensageria pós-ocupacional retornou {Count} registros", result.Count);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria pós-ocupacional");
            throw;
        }
    }

    public async Task<List<BaseMensageriaRelacionamento>> BuscarBaseMensageriaRelacionamentoAsync(bool apenasAniversariantes)
    {
        try
        {
            _logger.LogDebug("Buscando base de mensageria de relacionamento (aniversariantes: {Flag})", apenasAniversariantes);

            // TODO: Substituir por EXEC SP_CMCRM_SEL_BASE_MENSAGERIA_RELACIONAMENTO quando procedure existir
            
            var sql = @"
                SELECT 
                    c.ID_EMPRESA,
                    c.ID_OBRA,
                    c.ID_VENDA,
                    p.DS_NOME as DS_CLIENTE,
                    p.DS_EMAIL,
                    p.COD_DDD,
                    p.NR_TELEFONE,
                    p.DT_NASCIMENTO,
                    CASE 
                        WHEN MONTH(p.DT_NASCIMENTO) = MONTH(GETDATE()) 
                        THEN CAST(1 AS BIT) 
                        ELSE CAST(0 AS BIT) 
                    END as FL_ANIVERSARIANTE_MES
                FROM TB_CMREC_CONTA c WITH(NOLOCK)
                INNER JOIN TB_CMCAD_PESSOA p WITH(NOLOCK) ON c.ID_PESSOA = p.ID_PESSOA
                WHERE p.DT_NASCIMENTO IS NOT NULL
                    AND p.DS_EMAIL IS NOT NULL
                    AND p.DS_EMAIL <> ''
                    " + (apenasAniversariantes ? "AND MONTH(p.DT_NASCIMENTO) = MONTH(GETDATE())" : "") + @"
                ORDER BY MONTH(p.DT_NASCIMENTO), DAY(p.DT_NASCIMENTO)";

            var result = await _context.Database
                .SqlQueryRaw<BaseMensageriaRelacionamento>(sql)
                .ToListAsync();

            _logger.LogInformation("Base de mensageria de relacionamento retornou {Count} registros", result.Count);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar base de mensageria de relacionamento");
            throw;
        }
    }
}
