using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Interface para serviço de configurações gerais do sistema
/// </summary>
public interface IConfigGeralService
{
    /// <summary>
    /// Obtém a configuração geral do sistema
    /// </summary>
    Task<TB_CMCRM_CONFIG_GERAL?> ObterConfiguracaoAsync(string nomeBancoCrm);

    /// <summary>
    /// Verifica se deve disparar e-mails de cobrança em fim de semana
    /// </summary>
    Task<bool> PodeDispararEmailFimDeSemanaAsync(string nomeBancoCrm);

    /// <summary>
    /// Atualiza a configuração geral
    /// </summary>
    Task AtualizarConfiguracaoAsync(TB_CMCRM_CONFIG_GERAL configuracao, string nomeBancoCrm);

    /// <summary>
    /// Insere uma nova configuração geral
    /// </summary>
    Task InserirConfiguracaoAsync(TB_CMCRM_CONFIG_GERAL configuracao, string nomeBancoCrm);
}
