using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de configuração de régua de cobrança
/// </summary>
public interface IReguaCobrancaConfigService
{
    /// <summary>
    /// Lista todas as configurações de régua
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Busca configuração por ID da régua
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarPorReguaAsync(int idRegua, string nomeBancoCrm);

    /// <summary>
    /// Busca configuração por ID
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG?> BuscarAsync(int idConfig, string nomeBancoCrm);

    /// <summary>
    /// Insere uma nova configuração
    /// </summary>
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade, string nomeBancoCrm);

    /// <summary>
    /// Atualiza uma configuração existente
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_CONFIG entidade, string nomeBancoCrm);

    /// <summary>
    /// Exclui uma configuração
    /// </summary>
    Task ExcluirAsync(int idConfig, string nomeBancoCrm);
}
