using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using System.Data;
using System.Globalization;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para processamento de filtros e validações de réguas
/// Baseado na lógica do projeto original
/// </summary>
public class ReguaFiltroService : IReguaFiltroService
{
    private readonly ILogger<ReguaFiltroService> _logger;

    public ReguaFiltroService(ILogger<ReguaFiltroService> _logger)
    {
        this._logger = _logger;
    }

    public DataTable ExecutarFiltros(
        DataTable dados,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO> filtros)
    {
        try
        {
            if (!filtros.Any() || dados == null || dados.Rows.Count == 0)
                return dados!;

            DataTable dadosFiltrados = dados.Copy();

            foreach (var filtro in filtros)
            {
                try
                {
                    DataView dv = new DataView(dadosFiltrados);
                    // Nota: Em produção, seria necessário carregar a entidade de tipo filtro
                    // Por simplicidade inicial, vamos usar o ID diretamente
                    string tipoFiltro = filtro.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO.ToString();

                    if (string.IsNullOrEmpty(tipoFiltro))
                        continue;

                    string nomeCampo = ObterNomeCampo(tipoFiltro);
                    
                    if (string.IsNullOrEmpty(nomeCampo))
                        continue;

                    // Verifica se o campo existe no DataTable
                    if (!dadosFiltrados.Columns.Contains(nomeCampo))
                    {
                        _logger.LogWarning("Campo {NomeCampo} não encontrado no DataTable para filtro tipo {TipoFiltro}", 
                            nomeCampo, tipoFiltro);
                        continue;
                    }

                    // Aplica filtro baseado no tipo
                    AplicarFiltro(dv, tipoFiltro, nomeCampo, filtro);
                    
                    dadosFiltrados = dv.ToTable();

                    _logger.LogDebug("Filtro {TipoFiltro} aplicado. Registros restantes: {Count}", 
                        tipoFiltro, dadosFiltrados.Rows.Count);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao aplicar filtro {IdTipoFiltro}", 
                        filtro.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO);
                }
            }

            return dadosFiltrados;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar filtros");
            return dados!; // Retorna dados originais em caso de erro
        }
    }

    public DataTable ExecutarOrdenacao(
        DataTable dados,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO> ordenacoes)
    {
        try
        {
            if (!ordenacoes.Any() || dados == null || dados.Rows.Count == 0)
                return dados!;

            string sort = string.Join(", ", 
                ordenacoes.OrderBy(o => o.NR_ORDEM)
                          .Select(o => $"{o.DS_CAMPO} {(o.FL_ORDEM_CRESCENTE == true ? "ASC" : "DESC")}"));

            if (string.IsNullOrEmpty(sort))
                return dados!;

            DataView dv = new DataView(dados);
            dv.Sort = sort;

            _logger.LogDebug("Ordenação aplicada: {Sort}", sort);

            return dv.ToTable();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar ordenação");
            return dados!;
        }
    }

    public void VerificarValidacao(
        ref DataTable dados,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG config,
        string tipoAcao)
    {
        try
        {
            if (dados == null || dados.Rows.Count == 0)
                return;

            // Se a régua não está validada (modo teste), substitui destinatários
            if (regua.FL_VALIDADO != true)
            {
                _logger.LogWarning("Régua {IdRegua} em modo TESTE - redirecionando envios", regua.ID_CASO_COBRANCA_REGUA);

                // Substitui e-mails
                if (dados.Columns.Contains("DS_EMAIL"))
                {
                    dados.Columns.Remove("DS_EMAIL");
                    DataColumn colEmail = new DataColumn("DS_EMAIL", typeof(string));
                    colEmail.DefaultValue = config.DS_EMAIL_RECEPTIVO_TESTE;
                    dados.Columns.Add(colEmail);
                }

                // Substitui telefones (exceto para arquivo de telefonia)
                if (tipoAcao?.ToUpper().Trim() != "ARQUIVO TELEFONIA")
                {
                    if (dados.Columns.Contains("NR_TELEFONE"))
                    {
                        dados.Columns.Remove("NR_TELEFONE");
                        DataColumn colTelefone = new DataColumn("NR_TELEFONE", typeof(string));
                        colTelefone.DefaultValue = config.NR_TELEFONE_RECEPTIVO_TESTE;
                        dados.Columns.Add(colTelefone);
                    }

                    if (dados.Columns.Contains("COD_DDD"))
                    {
                        dados.Columns.Remove("COD_DDD");
                        DataColumn colDDD = new DataColumn("COD_DDD", typeof(string));
                        colDDD.DefaultValue = "";
                        dados.Columns.Add(colDDD);
                    }
                }

                _logger.LogInformation("Modo teste ativo - E-mails redirecionados para: {Email}, Telefones para: {Telefone}",
                    config.DS_EMAIL_RECEPTIVO_TESTE, config.NR_TELEFONE_RECEPTIVO_TESTE);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao verificar validação da régua");
        }
    }

    private void AplicarFiltro(DataView dv, string tipoFiltro, string nomeCampo, TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO filtro)
    {
        // Filtros numéricos
        if (tipoFiltro is "AGING DIAS" or "EMPRESA" or "VALOR PARCELA" or "NUMERO PARCELAS" or 
            "CASO ABERTO" or "VALOR RECEBIDO" or "NUMERO DIAS ULTIMO CASO" or "PERCENTUAL EMPRESA" or
            "AGING VENDA" or "AGING INÍCIO GARANTIA" or "AGING AGI" or "AGING RECEBIMENTO ÁREA COMUM" or
            "AGING HABITE-SE" or "AGING LANÇAMENTO" or "AGING PATRIMÔNIO AFETAÇÃO" or "AGING ENTREGA CHAVES" or
            "AGING DATA DA RAI" or "AGING DATA DEMANDA MINIMA" or "AGING AGENDAMENTO" or 
            "DATA EMISSÃO BOLETO" or "AGING EMISSÃO BOLETO")
        {
            dv.RowFilter = $"{nomeCampo} {filtro.DS_OPERACAO} {filtro.DS_VALOR}";
        }
        // Filtros de texto
        else if (tipoFiltro is "TIPO PARCELA" or "OBRA" or "CLASSIFICAÇÃO CONTRATO" or 
                 "STATUS COBRANÇA" or "STATUS ESCRITURA" or "INDICE REAJUSTE")
        {
            if (filtro.DS_OPERACAO?.Contains("IN") == true || filtro.DS_OPERACAO?.Contains("LIKE") == true)
            {
                dv.RowFilter = $"{nomeCampo} {filtro.DS_OPERACAO} {filtro.DS_VALOR}";
            }
            else
            {
                dv.RowFilter = $"{nomeCampo} {filtro.DS_OPERACAO} '{filtro.DS_VALOR}'";
            }
        }
        // Filtros de data
        else if (tipoFiltro is "DATA INÍCIO GARANTIA" or "DATA AGI" or "DATA RECEBIMENTO ÁREA COMUM" or
                 "DATA HABITE-SE" or "DATA LANÇAMENTO" or "DATA PATRIMÔNIO AFETAÇÃO" or 
                 "DATA DA VENDA" or "DATA ENTREGA CHAVES")
        {
            if (DateTime.TryParse(filtro.DS_VALOR, out DateTime dataFiltro))
            {
                dv.RowFilter = string.Format(CultureInfo.InvariantCulture, 
                    "{0} {1} '{2}'", nomeCampo, filtro.DS_OPERACAO, dataFiltro);
            }
        }
    }

    private string ObterNomeCampo(string tipoFiltro)
    {
        return tipoFiltro switch
        {
            "AGING DIAS" => "AGING_DIAS",
            "EMPRESA" => "ID_ORGANIZACAO",
            "VALOR PARCELA" => "VALOR_PARCELA",
            "NUMERO PARCELAS" => "NUM_PARCELAS",
            "TIPO PARCELA" => "TIPO_PARCELA",
            "OBRA" => "ID_OBRA",
            "CLASSIFICAÇÃO CONTRATO" => "CLASSIFICACAO_CONTRATO",
            "STATUS COBRANÇA" => "STATUS_COBRANCA",
            "STATUS ESCRITURA" => "STATUS_ESCRITURA",
            "INDICE REAJUSTE" => "INDICE_REAJUSTE",
            "DATA INÍCIO GARANTIA" => "DATA_INICIO_GARANTIA",
            "DATA AGI" => "DATA_AGI",
            "AGING VENDA" => "AGING_VENDA",
            "DATA DA VENDA" => "DATA_VENDA",
            "DATA ENTREGA CHAVES" => "DATA_ENTREGA_CHAVES",
            "AGING ENTREGA CHAVES" => "AGING_ENTREGA_CHAVES",
            _ => string.Empty
        };
    }
}
