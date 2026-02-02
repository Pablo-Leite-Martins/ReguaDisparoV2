using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIA_EXECUTOR
{
    public int ID_DYNAMICS_PROTOCOLOS_DADOS_ASSISTENCIA_EXECUTOR { get; set; }

    public string? nomeEncarregadoReparo { get; set; }

    public string? emailEncarregadoReparo { get; set; }

    public string? numeroAssistencia { get; set; }
}
