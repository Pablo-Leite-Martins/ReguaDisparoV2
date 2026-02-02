using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface do serviço principal de Régua de Cobrança
/// </summary>
public interface IReguaCobrancaService
{
    /// <summary>
    /// Executa a régua de cobrança para todas as organizações ativas
    /// Baseado em ExecutaReguaCobranca() do projeto antigo
    /// </summary>
    Task ExecutarReguaCobrancaAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Executa a régua de cobrança para uma organização específica
    /// Baseado em ExecutaReguaCobrancaOrganizacao() do projeto antigo
    /// </summary>
    Task ExecutarReguaCobrancaOrganizacaoAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Executa uma ação de etapa da régua
    /// Baseado em ExecutaAcaoEtapaRegua() do projeto antigo
    /// </summary>
    Task ExecutarAcaoEtapaReguaAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA reguaEtapa,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG reguaConfig,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO> listaAcoes,
        CancellationToken cancellationToken = default);
}
