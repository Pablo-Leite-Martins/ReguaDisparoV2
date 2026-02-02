using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_CAMPANHA
{
    public int ID_CASO_COBRANCA_CAMPANHA { get; set; }

    public string DS_NOME_CAMPANHA { get; set; } = null!;

    public string DS_OBJETIVO_CAMPANHA { get; set; } = null!;

    public string DS_CONDICOES_NEGOCIACAO { get; set; } = null!;

    public decimal VLR_META_RECUPERACAO { get; set; }

    public DateTime DT_INICIO { get; set; }

    public DateTime DT_TERMINO { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_GRUPO { get; set; }

    public bool? FL_DISCADOR { get; set; }

    public int? ID_CAMPANHA_DISCADOR { get; set; }

    public virtual ICollection<TB_CMCRM_ALCADA_GRUPO_CAMPANHA> TB_CMCRM_ALCADA_GRUPO_CAMPANHAs { get; set; } = new List<TB_CMCRM_ALCADA_GRUPO_CAMPANHA>();

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_DADO> TB_CMCRM_CASO_COBRANCA_DADOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_DADO>();
}
