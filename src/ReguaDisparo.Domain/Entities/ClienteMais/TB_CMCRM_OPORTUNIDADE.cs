using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_OPORTUNIDADE
{
    public int ID_OPORTUNIDADE { get; set; }

    public string DS_NOME { get; set; } = null!;

    public DateTime? DT_FECHAMENTO { get; set; }

    public decimal? VL_OPORTUNIDADE { get; set; }

    public decimal? NR_PROBABILIDADE_FECHAMENTO { get; set; }

    public string DS_STATUS { get; set; } = null!;

    public int ID_CONTA { get; set; }

    public int? ID_CAMPANHA { get; set; }

    public int? ID_FASE_OPORTUNIDADE { get; set; }

    public int? ID_TIPO_OPORTUNIDADE { get; set; }

    public int? ID_CASO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }

    public virtual TB_CMCRM_CONTA ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_OPORTUNIDADE? ID_TIPO_OPORTUNIDADENavigation { get; set; }

    public virtual ICollection<TB_CMCRM_OPORTUNIDADE_PRODUTO> TB_CMCRM_OPORTUNIDADE_PRODUTOs { get; set; } = new List<TB_CMCRM_OPORTUNIDADE_PRODUTO>();

    public virtual ICollection<TB_CMCRM_PROPOSTA> TB_CMCRM_PROPOSTa { get; set; } = new List<TB_CMCRM_PROPOSTA>();
}
