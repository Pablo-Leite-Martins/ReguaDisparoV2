using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL
{
    public int ID_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; }

    public string DS_ESTRUTURA_COMISSAO_FLEXIVEL { get; set; } = null!;

    public decimal? VL_PERCENTUAL_IMOBILIARIA { get; set; }

    public decimal? VL_PERCENTUAL_EMPRESA { get; set; }

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_CARGO> TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_CARGOs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_CARGO>();

    public virtual ICollection<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA> TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELAs { get; set; } = new List<TB_CMCRM_ESTRUTURA_COMISSAO_FLEXIVEL_TIPO_PARCELA>();

    public virtual ICollection<TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL> TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVELs { get; set; } = new List<TB_CMCRM_PROPOSTA_ESTRUTURA_COMISSAO_FLEXIVEL>();
}
