using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_EMPREENDIMENTO_PA
{
    public int ID_EMPREEDIMENTO_PA { get; set; }

    public string DS_EMPREENDIMENTO_PA { get; set; } = null!;

    public int ID_USUARIO_CADASTRO { get; set; }

    public DateTime DT_ATUALIZACAO { get; set; }
}
