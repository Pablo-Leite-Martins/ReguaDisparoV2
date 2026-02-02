using Microsoft.Extensions.Logging;
using ReguaDisparo.Core.Interfaces;
using ReguaDisparo.Domain.Entities.ClienteMais;
using ReguaDisparo.Infrastructure.Data.Factories;

namespace ReguaDisparo.Core.Services;

/// <summary>
/// Serviço para envio de comunicações (Email, SMS, WhatsApp)
/// Versão simplificada inicial - será expandida conforme necessário
/// </summary>
public class ComunicacaoService : IComunicacaoService
{
    private readonly ILogger<ComunicacaoService> _logger;
    private readonly IEmailService _emailService;
    private readonly ITenantDbContextFactory _tenantFactory;

    public ComunicacaoService(
        ILogger<ComunicacaoService> logger,
        IEmailService emailService,
        ITenantDbContextFactory tenantFactory)
    {
        _logger = logger;
        _emailService = emailService;
        _tenantFactory = tenantFactory;
    }

    public async Task EnviarEmailsAsync(
        List<DestinatarioEmail> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Iniciando envio de {Count} e-mails para ação {IdAcao}", 
                destinatarios.Count, acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);

            int sucessos = 0;
            int falhas = 0;

            foreach (var destinatario in destinatarios)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;

                try
                {
                    // TODO: Buscar template de e-mail e processar variáveis
                    // Por enquanto, envio simples
                    
                    string assunto = acao.DS_NOME_ACAO ?? "Comunicado";
                    string corpo = $"Comunicação automática - Régua de Disparo\n\nOlá {destinatario.Nome},\n\nEste é um e-mail automático.";

                    await _emailService.SendEmailAsync(
                        destinatario.Email,
                        assunto,
                        corpo);

                    await RegistrarHistoricoEnvioAsync(
                        acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO,
                        "EMAIL",
                        destinatario.Email,
                        true,
                        null,
                        nomeBancoCrm);

                    sucessos++;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao enviar e-mail para {Email}", destinatario.Email);
                    
                    await RegistrarFalhaEnvioAsync(
                        acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO,
                        "EMAIL",
                        destinatario.Email,
                        ex.Message,
                        nomeBancoCrm);

                    falhas++;
                }
            }

            _logger.LogInformation("Envio de e-mails concluído. Sucessos: {Sucessos}, Falhas: {Falhas}", 
                sucessos, falhas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar envio de e-mails");
            throw;
        }
    }

    public async Task EnviarSmsAsync(
        List<DestinatarioSms> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("Envio de SMS não implementado ainda. Ação: {IdAcao}", 
            acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        
        // TODO: Implementar integração com provedor de SMS
        await Task.CompletedTask;
    }

    public async Task EnviarWhatsAppAsync(
        List<DestinatarioWhatsApp> destinatarios,
        TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO acao,
        string nomeBancoCrm,
        CancellationToken cancellationToken = default)
    {
        _logger.LogWarning("Envio de WhatsApp não implementado ainda. Ação: {IdAcao}", 
            acao.ID_CASO_COBRANCA_REGUA_ETAPA_ACAO);
        
        // TODO: Implementar integração com API de WhatsApp
        await Task.CompletedTask;
    }

    public async Task RegistrarHistoricoEnvioAsync(
        int idAcao,
        string tipoEnvio,
        string destinatario,
        bool sucesso,
        string? mensagemErro,
        string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);

            var historico = new TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIO
            {
                ID_CASO_COBRANCA_REGUA_ETAPA_ACAO = idAcao,
                DS_EMAIL = tipoEnvio == "EMAIL" ? destinatario : null,
                NR_TELEFONE = tipoEnvio != "EMAIL" ? destinatario : null,
                FL_REGUA_VALIDADA = sucesso,
                DS_CONTEUDO_ENVIADO = mensagemErro,
                DT_ENVIO = DateTime.Now
            };

            await crmDb.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_ENVIOs.AddAsync(historico);
            await crmDb.SaveChangesAsync();

            _logger.LogDebug("Histórico de envio registrado para {Destinatario}", destinatario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar histórico de envio");
            // Não propaga exceção para não interromper o fluxo
        }
    }

    public async Task RegistrarFalhaEnvioAsync(
        int idAcao,
        string tipoEnvio,
        string destinatario,
        string motivoFalha,
        string nomeBancoCrm)
    {
        try
        {
            using var crmDb = await _tenantFactory.CreateDbContextAsync(nomeBancoCrm);

            var falha = new TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIO
            {
                ID_CASO_COBRANCA_REGUA_ETAPA_ACAO = idAcao,
                DS_EMAIL = tipoEnvio == "EMAIL" ? destinatario : null,
                NR_TELEFONE = tipoEnvio != "EMAIL" ? destinatario : null,
                DS_MESSAGE = motivoFalha,
                DT_ENVIO = DateTime.Now
            };

            await crmDb.TB_CMCRM_CASO_COBRANCA_REGUA_HISTORICO_NAO_ENVIOs.AddAsync(falha);
            await crmDb.SaveChangesAsync();

            _logger.LogDebug("Falha de envio registrada para {Destinatario}", destinatario);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao registrar falha de envio");
            // Não propaga exceção
        }
    }
}
