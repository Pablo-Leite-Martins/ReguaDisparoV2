using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_VENDA_CONFIGURACAO
{
    public int ID_MODELO_VENDA_CONFIGURACAO { get; set; }

    public int NR_EXIBICAO { get; set; }

    public int NR_CONJUNTO { get; set; }

    public int ID_MODELO_VENDA_PRODUTO { get; set; }

    public virtual TB_CMCRM_MODELO_VENDA_PRODUTO ID_MODELO_VENDA_PRODUTONavigation { get; set; } = null!;
}
