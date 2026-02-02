using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UNIDADE
{
    public int ID_UNIDADE { get; set; }

    public int ID_PRODUTO { get; set; }

    public decimal? VL_PRECO { get; set; }

    public int ID_UNIDADE_PRECO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_UNIDADE_PRECO ID_UNIDADE_PRECONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_DISTRIBUICAO_PAGAMENTO> TB_CMCRM_DISTRIBUICAO_PAGAMENTOs { get; set; } = new List<TB_CMCRM_DISTRIBUICAO_PAGAMENTO>();
}
