using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PRODUTO
{
    public int ID_TIPO_PRODUTO { get; set; }

    public string DS_TIPO_PRODUTO { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_DOCUMENTO_TEMPLATE> TB_CMCRM_DOCUMENTO_TEMPLATEs { get; set; } = new List<TB_CMCRM_DOCUMENTO_TEMPLATE>();

    public virtual ICollection<TB_CMCRM_INTERESSE_CONTA_PRODUTO> TB_CMCRM_INTERESSE_CONTA_PRODUTOs { get; set; } = new List<TB_CMCRM_INTERESSE_CONTA_PRODUTO>();

    public virtual ICollection<TB_CMCRM_PRODUTO> TB_CMCRM_PRODUTOs { get; set; } = new List<TB_CMCRM_PRODUTO>();
}
