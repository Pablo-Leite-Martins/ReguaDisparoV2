using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Domain.Entities.Corporativo;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface do serviço principal de Régua de Cobrança
/// </summary>
public interface IReguaCobrancaService
{

    Task ExecutarReguaCobrancaAsync(CancellationToken cancellationToken = default);

    Task ExecutarReguaCobrancaOrganizacaoAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        CancellationToken cancellationToken = default);

    Task ExecutarAcaoEtapaReguaAsync(
        TB_CMCORP_ORGANIZACAO organizacao,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA reguaEtapa,
        TB_CMCRM_CASO_COBRANCA_REGUA regua,
        TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG reguaConfig,
        List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO> listaAcoes,
        CancellationToken cancellationToken = default);
}
