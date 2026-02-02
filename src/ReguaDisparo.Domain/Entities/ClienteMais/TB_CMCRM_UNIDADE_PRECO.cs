using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_UNIDADE_PRECO
{
    public int ID_UNIDADE_PRECO { get; set; }

    public string DS_DESCRICAO { get; set; } = null!;

    public DateTime? DT_VENCIMENTO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int ID_PRODUTO { get; set; }

    public decimal? VL_PERCENTUAL_GORDURA { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public bool FL_SINC_SRV { get; set; }

    public bool? FL_PADRAO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_MODELO_VENDA_UNIDADE_PRECO> TB_CMCRM_MODELO_VENDA_UNIDADE_PRECOs { get; set; } = new List<TB_CMCRM_MODELO_VENDA_UNIDADE_PRECO>();

    public virtual ICollection<TB_CMCRM_PROPOSTum> TB_CMCRM_PROPOSTa { get; set; } = new List<TB_CMCRM_PROPOSTum>();

    public virtual ICollection<TB_CMCRM_UNIDADE_PRECO_LOG> TB_CMCRM_UNIDADE_PRECO_LOGs { get; set; } = new List<TB_CMCRM_UNIDADE_PRECO_LOG>();

    public virtual ICollection<TB_CMCRM_UNIDADE> TB_CMCRM_UNIDADEs { get; set; } = new List<TB_CMCRM_UNIDADE>();
}
