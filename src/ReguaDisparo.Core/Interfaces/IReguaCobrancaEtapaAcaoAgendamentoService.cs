using ReguaDisparo.Domain.Entities.ClienteMais;

namespace ReguaDisparo.Core.Interfaces;

/// <summary>
/// Serviço para gerenciamento de agendamentos de ações de régua de cobrança
/// </summary>
public interface IReguaCobrancaEtapaAcaoAgendamentoService
{
    /// <summary>
    /// Lista todos os agendamentos
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarAsync(string nomeBancoCrm);

    /// <summary>
    /// Lista agendamentos por etapa ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ListarPorEtapaAcaoAsync(int idEtapaAcao, string nomeBancoCrm);

    /// <summary>
    /// Obtém agendamentos pendentes (não enviados) para uma ação
    /// </summary>
    Task<List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA>> ObterAgendamentosPendentesAsync(int idEtapaAcao, string nomeBancoCrm);

    /// <summary>
    /// Busca um agendamento específico
    /// </summary>
    Task<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA?> BuscarAsync(int idAgenda, string nomeBancoCrm);

    /// <summary>
    /// Insere um novo agendamento
    /// </summary>
    Task InserirAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade, string nomeBancoCrm);

    /// <summary>
    /// Atualiza um agendamento
    /// </summary>
    Task AtualizarAsync(TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA entidade, string nomeBancoCrm);

    /// <summary>
    /// Executa um agendamento marcando-o como enviado
    /// </summary>
    Task ExecutarAgendamentoAsync(int idAgendamento, string nomeBancoCrm);

    /// <summary>
    /// Verifica se uma ação possui agendamentos cadastrados
    /// </summary>
    Task<bool> VerificarSeAcaoTemAgendamentosAsync(int idEtapaAcao, string nomeBancoCrm);
}
