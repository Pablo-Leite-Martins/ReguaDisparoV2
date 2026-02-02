using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_LOG
{
    public int ID_ESTRUTURA_COMISSAO_LOG { get; set; }

    public string DS_ESTRUTURA_COMISSAO_LOG { get; set; } = null!;

    public DateTime DT_ESTRUTURA_COMISSAO_LOG { get; set; }

    public int ID_ESTRUTURA_COMISSAO { get; set; }

    public int ID_USUARIO { get; set; }

    public virtual TB_CMCRM_ESTRUTURA_COMISSAO ID_ESTRUTURA_COMISSAONavigation { get; set; } = null!;
}
