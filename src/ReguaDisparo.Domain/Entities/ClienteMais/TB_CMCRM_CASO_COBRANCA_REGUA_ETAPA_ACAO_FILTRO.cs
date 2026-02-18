using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO { get; set; }

    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO { get; set; }

    public string DS_VALOR { get; set; } = null!;

    public string DS_OPERACAO { get; set; } = null!;

    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public virtual TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO? ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRONavigation { get; set; }
}
