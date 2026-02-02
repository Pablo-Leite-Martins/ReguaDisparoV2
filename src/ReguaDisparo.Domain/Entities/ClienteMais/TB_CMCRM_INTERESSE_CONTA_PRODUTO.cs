using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_INTERESSE_CONTA_PRODUTO
{
    public int ID_INTERESSE_CONTA_PRODUTO { get; set; }

    public int ID_CONTA { get; set; }

    public int ID_TIPO_PRODUTO { get; set; }

    public int NR_MIN_QUARTOS { get; set; }

    public int? NR_MAX_QUARTOS { get; set; }

    public int NR_MIN_VAGAS { get; set; }

    public int? NR_MAX_VAGAS { get; set; }

    public decimal VL_MIN_METROS_QUADRADOS { get; set; }

    public decimal? VL_MAX_METROS_QUADRADOS { get; set; }

    public string ID_LUGAR_PRINCIPAL { get; set; } = null!;

    public int? ID_PRODUTO_PRINCIPAL { get; set; }

    public string? ID_LUGAR_SECUNDARIO { get; set; }

    public int? ID_PRODUTO_SECUNDARIO { get; set; }

    public string? ID_LUGAR_TERCIARIO { get; set; }

    public int? ID_PRODUTO_TERCIARIO { get; set; }

    public virtual TB_CMCRM_CONTum ID_CONTANavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTO_PRINCIPALNavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTO_SECUNDARIONavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTO_TERCIARIONavigation { get; set; }

    public virtual TB_CMCRM_TIPO_PRODUTO ID_TIPO_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_AREA_COMUM_INTERESSE> TB_CMCRM_AREA_COMUM_INTERESSEs { get; set; } = new List<TB_CMCRM_AREA_COMUM_INTERESSE>();
}
