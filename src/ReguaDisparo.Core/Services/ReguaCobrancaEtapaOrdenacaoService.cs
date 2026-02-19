using System.Data;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Interfaces.Repositories.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para ordenação de dados de régua de cobrança
/// Baseado em ExecutaOrdemRegua do projeto original
/// </summary>
public class ReguaCobrancaEtapaOrdenacaoService : IReguaCobrancaEtapaOrdenacaoService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILogger<ReguaCobrancaEtapaOrdenacaoService> _logger;

    public ReguaCobrancaEtapaOrdenacaoService(
        ITenantDbContextFactory tenantFactory,
        ILogger<ReguaCobrancaEtapaOrdenacaoService> logger)
    {
        _tenantFactory = tenantFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>> ListarPorEtapaAsync(
        int idEtapa, 
        string nomeBancoCrm)
    {
        try
        {
            using var context = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new Infrastructure.Repositories.ClienteMais.ReguaCobrancaEtapaOrdenacaoRepository(
                context,
                (_logger as ILogger<Infrastructure.Repositories.ClienteMais.ReguaCobrancaEtapaOrdenacaoRepository>)!);

            var ordenacoes = await repository.ListarPorEtapaAsync(idEtapa);

            _logger.LogDebug("Encontradas {Count} ordenações para etapa {IdEtapa}", 
                ordenacoes.Count, idEtapa);

            return ordenacoes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar ordenações para etapa {IdEtapa}", idEtapa);
            return new List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>();
        }
    }

    /// <summary>
    /// Aplica ordenações em um DataTable
    /// Baseado em: ExecutaOrdemRegua do projeto original
    /// </summary>
    public DataTable AplicarOrdenacao(
        DataTable dtDados, 
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO> listaOrdenacao)
    {
        try
        {
            if (dtDados == null || dtDados.Rows.Count == 0)
            {
                _logger.LogDebug("DataTable vazio, nenhuma ordenação aplicada");
                return dtDados ?? new DataTable();
            }

            if (listaOrdenacao == null || listaOrdenacao.Count == 0)
            {
                _logger.LogDebug("Nenhuma ordenação configurada");
                return dtDados;
            }

            // Constrói string de ordenação SQL
            string sort = string.Empty;
            foreach (var entidade in listaOrdenacao)
            {
                if (!string.IsNullOrEmpty(entidade.DS_CAMPO))
                {
                    if (!string.IsNullOrEmpty(sort))
                        sort += ", ";

                    sort += entidade.DS_CAMPO + " " + (entidade.FL_ORDEM_CRESCENTE == true ? "ASC" : "DESC");
                }
            }

            if (string.IsNullOrEmpty(sort))
            {
                _logger.LogDebug("Nenhum campo válido para ordenação");
                return dtDados;
            }

            _logger.LogDebug("Aplicando ordenação: {Sort}", sort);

            // Aplica ordenação usando DataView
            DataView dvDados = new DataView(dtDados);
            dvDados.Sort = sort;

            return dvDados.ToTable();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao aplicar ordenação no DataTable");
            // Em caso de erro, retorna os dados originais sem ordenação
            return dtDados;
        }
    }
}
