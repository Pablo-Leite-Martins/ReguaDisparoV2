using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA { get; set; }

    public string DS_NOME_ETAPA { get; set; } = null!;

    public int NR_ETAPA { get; set; }

    public int ID_CASO_COBRANCA_REGUA { get; set; }

    public bool? FL_COBRANCA_PREVENTIVA { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO> TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAOs { get; set; } = new List<TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ORDENACAO>();
}
