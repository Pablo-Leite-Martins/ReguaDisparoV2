using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC_2024_03_28
{
    public int ID_CATEGORIA_ATENDIMENTO_CASO_ASSISTENCIA_TEC { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO_ABERTURA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_VISTORIA { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_REPARO { get; set; }

    public int? ID_CATEGORIA_ATENDIMENTO_FECHAMENTO { get; set; }

    public int ID_CASO { get; set; }
}
