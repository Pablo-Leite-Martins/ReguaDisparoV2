using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_PRODUTO
{
    public int ID_ESTRUTURA_COMISSAO_PRODUTO { get; set; }

    public int ID_ESTRUTURA_COMISSAO { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO ID_ESTRUTURA_COMISSAONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
