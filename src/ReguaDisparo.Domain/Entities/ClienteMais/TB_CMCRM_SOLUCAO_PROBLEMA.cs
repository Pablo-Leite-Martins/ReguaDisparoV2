using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SOLUCAO_PROBLEMA
{
    public int ID_SOLUCAO_PROBLEMA { get; set; }

    public string DS_SOLUCAO_PROBLEMA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_DADOS_FECHAMENTO> TB_CMCRM_CASO_DADOS_FECHAMENTOs { get; set; } = new List<TB_CMCRM_CASO_DADOS_FECHAMENTO>();
}
