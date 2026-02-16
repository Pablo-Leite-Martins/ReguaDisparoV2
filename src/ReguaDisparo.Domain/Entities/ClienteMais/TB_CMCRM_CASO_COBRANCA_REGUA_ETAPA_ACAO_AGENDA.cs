using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_AGENDA { get; set; }

    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public DateTime DT_ENVIO { get; set; }

    public bool FL_ENVIADO { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO ID_CASO_COBRANCA_REGUA_ETAPA_ACAONavigation { get; set; } = null!;
}
