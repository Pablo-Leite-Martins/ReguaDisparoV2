using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_MODELO_VENDA
{
    public int ID_ESTRUTURA_COMISSAO_MODELO_VENDA { get; set; }

    public int ID_ESTRUTURA_COMISSAO { get; set; }

    public int ID_MODELO_VENDA { get; set; }

    public int? ID_ORIGEM_LEAD { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO ID_ESTRUTURA_COMISSAONavigation { get; set; } = null!;

    public virtual TB_CMCRM_MODELO_VENDA ID_MODELO_VENDANavigation { get; set; } = null!;

    public virtual TB_CMCRM_ORIGEM_LEAD? ID_ORIGEM_LEADNavigation { get; set; }
}
