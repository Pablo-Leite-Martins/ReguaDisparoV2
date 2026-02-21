using System.Data;
using System.Globalization;
using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;
using ReguaDisparo.Infrastructure.Repositories.ClienteMais;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para gerenciar filtros de ações de régua de cobrança
/// Implementa aplicação de filtros em DataTable de forma performática
/// </summary>
public class ReguaCobrancaEtapaAcaoFiltroService : IReguaCobrancaEtapaAcaoFiltroService
{
    private readonly ITenantDbContextFactory _tenantFactory;
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<ReguaCobrancaEtapaAcaoFiltroService> _logger;

    public ReguaCobrancaEtapaAcaoFiltroService(
        ITenantDbContextFactory tenantFactory,
        ILoggerFactory loggerFactory,
        ILogger<ReguaCobrancaEtapaAcaoFiltroService> logger)
    {
        _tenantFactory = tenantFactory;
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarAsync(string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoFiltroRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoFiltroRepository>());

            return await repository.ListarAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar filtros de ação");
            throw;
        }
    }

    public async Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO>> ListarPorAcaoAsync(int idAcao, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoFiltroRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoFiltroRepository>());

            return await repository.ListarPorAcaoAsync(idAcao);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao listar filtros para ação {IdAcao}", idAcao);
            throw;
        }
    }

    public async Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO?> BuscarAsync(int idFiltro, string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);
            var repository = new ReguaCobrancaEtapaAcaoFiltroRepository(
                crmDb,
                _loggerFactory.CreateLogger<ReguaCobrancaEtapaAcaoFiltroRepository>());

            return await repository.BuscarAsync(idFiltro);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar filtro {IdFiltro}", idFiltro);
            throw;
        }
    }

    /// <summary>
    /// Aplica filtros em DataTable de forma performática usando DataView
    /// Baseado no método ExecutaFiltroRegua do projeto original
    /// </summary>
    public DataTable AplicarFiltros(DataTable dtDados, List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO> listaFiltros)
    {
        try
        {
            if (dtDados == null || dtDados.Rows.Count == 0)
            {
                _logger.LogDebug("DataTable vazio ou nulo, nenhum filtro aplicado");
                return null!;
            }

            if (listaFiltros == null || listaFiltros.Count == 0)
            {
                _logger.LogDebug("Nenhum filtro configurado");
                return null!;
            }

            _logger.LogInformation("Aplicando {Count} filtros ao DataTable com {Rows} registros", 
                listaFiltros.Count, dtDados.Rows.Count);

            foreach (var filtro in listaFiltros)
            {
                if (filtro.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRONavigation == null)
                {
                    _logger.LogWarning("Filtro {IdFiltro} sem navigation property carregada", 
                        filtro.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO);
                    return null!;
                }

                var tipoFiltro = filtro.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRONavigation.DS_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO.ToUpper();
                var operacao = filtro.DS_OPERACAO;
                var valor = filtro.DS_VALOR;

                _logger.LogDebug("Aplicando filtro: {Tipo} {Operacao} {Valor}", tipoFiltro, operacao, valor);

                // Aplica filtro usando DataView para performance
                DataView dvDados = new DataView(dtDados);
                string nomeCampo = ObterNomeCampo(tipoFiltro);

                if (string.IsNullOrEmpty(nomeCampo))
                {
                    _logger.LogWarning("Tipo de filtro não mapeado: {Tipo}", tipoFiltro);
                    return null!;
                }

                // Verifica se a coluna existe no DataTable
                if (!dtDados.Columns.Contains(nomeCampo))
                {
                    _logger.LogWarning("Coluna {NomeCampo} não existe no DataTable", nomeCampo);
                    return null!;
                }

                // Aplica filtro conforme categoria
                if (EhFiltroNumerico(nomeCampo))
                {
                    // Filtros numéricos: AGING DIAS, EMPRESA, VALOR PARCELA, etc
                    dvDados.RowFilter = $"{nomeCampo} {operacao} {valor}";
                }
                else if (EhFiltroTexto(nomeCampo))
                {
                    // Filtros de texto: TIPO PARCELA, OBRA, CLASSIFICAÇÃO CONTRATO, etc
                    if (!operacao.Contains("IN") && !operacao.Contains("LIKE"))
                        dvDados.RowFilter = $"{nomeCampo} {operacao} '{valor}'";
                    else
                        dvDados.RowFilter = $"{nomeCampo} {operacao} {valor}";
                }
                else if (EhFiltroData(nomeCampo))
                {
                    // Filtros de data: DATA INÍCIO GARANTIA, DATA AGI, etc
                    var dataConvertida = Convert.ToDateTime(valor);
                    dvDados.RowFilter = string.Format(CultureInfo.InvariantCulture, 
                        "{0} {1} '{2}'", nomeCampo, operacao, dataConvertida);
                }

                // Atualiza DataTable com resultado filtrado
                dtDados = dvDados.ToTable();
                
                _logger.LogDebug("Após filtro {Tipo}: {Rows} registros", tipoFiltro, dtDados.Rows.Count);
            }

            _logger.LogInformation("Filtros aplicados. Resultado final: {Rows} registros", dtDados.Rows.Count);
            return dtDados;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao aplicar filtros");
            return null!; // Retorna dados originais em caso de erro
        }
    }

    /// <summary>
    /// Mapeia tipo de filtro para nome da coluna no DataTable
    /// </summary>
    private string ObterNomeCampo(string tipoFiltro)
    {
        return tipoFiltro switch
        {
            "TIPO PARCELA" => "ID_TIPO_PARCELA",
            "OBRA" => "ID_OBRA",
            "CLASSIFICAÇÃO CONTRATO" => "DS_CLASSIFICACAO_CONTRATO",
            "STATUS COBRANÇA" => "ST_COBRANCA",
            "STATUS ESCRITURA" => "ST_ESCRITURA",
            "INDICE REAJUSTE" => "DS_INDICE_REAJUSTE",
            "AGING DIAS" => "NR_AGING_DIAS_CONTRATO",
            "EMPRESA" => "ID_EMPRESA",
            "VALOR PARCELA" => "VL_PARCELAS_EM_ABERTO",
            "NUMERO PARCELAS" => "NR_PARCELAS_EM_ABERTO",
            "NUMERO DIAS ULTIMO CASO" => "DATA_ULTIMO_CASO",
            "VALOR RECEBIDO" => "VL_RECEBIDO_VGV	",
            "CASO ABERTO" => "CASO_ABERTO",
            "PERCENTUAL EMPRESA" => "VL_PERCENTUAL_EMPRESA",
            "RENEGOCIACAO" => "RENEGOCIACAO",
            "DATA INÍCIO GARANTIA" => "DT_INICIO_GARANTIA",
            "DATA AGI" => "DT_AGI",
            "DATA RECEBIMENTO ÁREA COMUM" => "DT_RECEBIMENTO_AREA_COMUM",
            "DATA HABITE-SE" => "DT_HABITESE",
            "DATA LANÇAMENTO" => "DT_LANCAMENTO",
            "DATA PATRIMÔNIO AFETAÇÃO" => "DT_PATRIMONIO_AFETACAO",
            "DATA DA VENDA" => "DT_VENDA",
            "DATA ENTREGA CHAVES" => "DT_ENTREGA_CHAVES",
            "DATA EMISSÃO BOLETO" => "DT_EMISSAO_BOLETO",
            "AGING VENDA" => "AGING_VENDA",
            "AGING INÍCIO GARANTIA" => "AGING_INICIO_GARANTIA",
            "AGING AGI" => "AGING_AGI",
            "AGING RECEBIMENTO ÁREA COMUM" => "AGING_RECEBIMENTO_AREA_COMUM",
            "AGING HABITE-SE" => "AGING_HABITESE",
            "AGING LANÇAMENTO" => "AGING_LANCAMENTO",
            "AGING PATRIMÔNIO AFETAÇÃO" => "AGING_PATRIMONIO_AFETACAO",
            "AGING ENTREGA CHAVES" => "AGING_ENTREGA_CHAVES",
            "EVOLUÇÃO OBRA PORTAL" => "EVOLUCAO_OBRA_PORTAL",
            "AGING ASSINATURA CAIXA" => "AGING_ASSINATURA_CAIXA",
            "AGING DATA DA RAI" => "NR_AGING_RAI",
            "AGING DATA DEMANDA MINIMA" => "NR_AGING_DEMANDA_MINIMA",
            "AGING AGENDAMENTO" => "NR_AGING_AGENDAMENTO",
            "AGING EMISSÃO BOLETO" => "AGING_EMISSAO_BOLETO",
            "NOVA MODALIDADE" => "NOVA_MODALIDADE",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Verifica se o campo é numérico
    /// </summary>
    private bool EhFiltroNumerico(string nomeCampo)
    {
        var camposNumericos = new[]
        {
            "NR_AGING_DIAS_CONTRATO", "ID_EMPRESA", "VL_PARCELAS_EM_ABERTO", "NR_PARCELAS_EM_ABERTO",
            "CASO_ABERTO", "VL_RECEBIDO_VGV", "DATA_ULTIMO_CASO",
            "VL_PERCENTUAL_EMPRESA", "RENEGOCIACAO", "AGING_VENDA", "AGING_INICIO_GARANTIA",
            "AGING_AGI", "AGING_RECEBIMENTO_AREA_COMUM", "AGING_HABITESE",
            "AGING_LANCAMENTO", "AGING_PATRIMONIO_AFETACAO", "AGING_ENTREGA_CHAVES",
            "EVOLUCAO_OBRA_PORTAL", "AGING_ASSINATURA_CAIXA",
            "NR_AGING_RAI", "NR_AGING_DEMANDA_MINIMA", "NR_AGING_AGENDAMENTO",
            "AGING_EMISSAO_BOLETO"
        };
        
        return camposNumericos.Contains(nomeCampo);
    }

    /// <summary>
    /// Verifica se o campo é texto
    /// </summary>
    private bool EhFiltroTexto(string nomeCampo)
    {
        var camposTexto = new[]
        {
            "ID_TIPO_PARCELA", "ID_OBRA", "DS_CLASSIFICACAO_CONTRATO",
            "ST_COBRANCA", "ST_ESCRITURA", "DS_INDICE_REAJUSTE",
            "NOVA_MODALIDADE"
        };
        
        return camposTexto.Contains(nomeCampo);
    }

    /// <summary>
    /// Verifica se o campo é data
    /// </summary>
    private bool EhFiltroData(string nomeCampo)
    {
        var camposData = new[]
        {
            "DT_INICIO_GARANTIA", "DT_AGI", "DT_RECEBIMENTO_AREA_COMUM",
            "DT_HABITESE", "DT_LANCAMENTO", "DT_PATRIMONIO_AFETACAO",
            "DT_VENDA", "DT_ENTREGA_CHAVES", "DT_EMISSAO_BOLETO"
        };
        
        return camposData.Contains(nomeCampo);
    }
}
