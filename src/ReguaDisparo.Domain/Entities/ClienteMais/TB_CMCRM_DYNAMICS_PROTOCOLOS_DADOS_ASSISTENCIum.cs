using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIum
{
    public int ID_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIA { get; set; }

    public string? numeroAssistencia { get; set; }

    public string? subAssunto { get; set; }

    public string? ondeOcorreu { get; set; }

    public string? statusAtividade { get; set; }

    public string? tipoOs { get; set; }

    public string? dataCriacaoAssistencia { get; set; }

    public string? dataAgendadaVistoria { get; set; }

    public string? classificacaoVistoria { get; set; }

    public string? clientePresenteVistoria { get; set; }

    public string? vizinhoPresenteVistoria { get; set; }

    public string? nomeEncarregadoVistoria { get; set; }

    public string? emailEncarregadoVistoria { get; set; }

    public string? classificacaoReparo { get; set; }

    public string? dataAgendadaExecucao { get; set; }

    public string? referenteA { get; set; }

    public string? responsavel { get; set; }

    public string? descricaoAssistencia { get; set; }

    public string? dataResolucao { get; set; }

    public string? dataTerminoReal { get; set; }

    public string? numeroOcorrencia { get; set; }
}
