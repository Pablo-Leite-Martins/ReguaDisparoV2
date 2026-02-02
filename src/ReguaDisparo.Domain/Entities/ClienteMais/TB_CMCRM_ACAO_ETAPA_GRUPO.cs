using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ACAO_ETAPA_GRUPO
{
    public int ID_ACAO_ETAPA_GRUPO { get; set; }

    public int? ID_ETAPA_ATENDIMENTO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO { get; set; }

    public int ID_GRUPO { get; set; }
}
