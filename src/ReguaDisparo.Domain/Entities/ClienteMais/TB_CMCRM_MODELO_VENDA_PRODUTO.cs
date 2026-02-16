using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MODELO_VENDA_PRODUTO
{
    public int ID_MODELO_VENDA_PRODUTO { get; set; }

    public int ID_MODELO_VENDA { get; set; }

    public int ID_PRODUTO { get; set; }

    public virtual TB_CMCRM_MODELO_VENDA ID_MODELO_VENDANavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_MODELO_VENDA_CONFIGURACAO> TB_CMCRM_MODELO_VENDA_CONFIGURACAOs { get; set; } = new List<TB_CMCRM_MODELO_VENDA_CONFIGURACAO>();
}
