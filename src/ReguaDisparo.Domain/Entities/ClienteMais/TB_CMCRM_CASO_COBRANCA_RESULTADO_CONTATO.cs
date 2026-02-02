using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_RESULTADO_CONTATO
{
    public int ID_CASO_COBRANCA_RESULTADO_CONTATO { get; set; }

    public string DS_RESULTADO_CONTATO { get; set; } = null!;

    public string DS_CLASSIFICACAO { get; set; } = null!;

    public bool? FL_ATIVO { get; set; }

    public int? NR_TEMPO_RETORNO_FILA { get; set; }

    public int? ID_CASO_COBRANCA_CLASSIFICACAO_COBRANCA { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_CLASSIFICACAO_COBRANCA? ID_CASO_COBRANCA_CLASSIFICACAO_COBRANCANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_DADO> TB_CMCRM_CASO_COBRANCA_DADOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_DADO>();
}
