using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIA_PLANILHA
{
    public int ID_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIA_PLANILHA { get; set; }

    public string? numeroOcorrencia { get; set; }

    public string? numeroAssistencia { get; set; }

    public string? subAssuntoPreliminar { get; set; }

    public string? subAssuntoClassificacao { get; set; }

    public string? subAssunto { get; set; }
}
