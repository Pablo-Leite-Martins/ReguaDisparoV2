using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_OPCAO_PLANTA
{
    public int ID_OPCAO_PLANTA { get; set; }

    public string DS_OPCAO_PLANTA { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_DADOS_PRODUTO> TB_CMCRM_DADOS_PRODUTOs { get; set; } = new List<TB_CMCRM_DADOS_PRODUTO>();
}
