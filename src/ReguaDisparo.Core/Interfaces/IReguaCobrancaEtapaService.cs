using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de etapas de régua de cobrança
/// </summary>
public interface IReguaCobrancaEtapaService
{
    /// <summary>
    /// Lista todas as etapas
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Lista etapas por ID da régua ordenadas por número da etapa
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA>> ListarPorReguaAsync(int idRegua, string nomeBancoCrm);

    /// <summary>
    /// Busca etapa por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA?> BuscarAsync(int idEtapa, string nomeBancoCrm);

    /// <summary>
    /// Insere uma nova etapa
    /// </summary>
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade, string nomeBancoCrm);

    /// <summary>
    /// Atualiza uma etapa existente
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA entidade, string nomeBancoCrm);

    /// <summary>
    /// Exclui uma etapa
    /// </summary>
    Task ExcluirAsync(int idEtapa, string nomeBancoCrm);
}
