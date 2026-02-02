using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO_LOG
{
    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_FILTRO { get; set; }

    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO_TIPO_FILTRO { get; set; }

    public string DS_VALOR { get; set; } = null!;

    public string DS_OPERACAO { get; set; } = null!;

    public int ID_CASO_COBRANCA_REGUA_ETAPA_ACAO { get; set; }

    public int ID_USUARIO { get; set; }

    public string? DS_REGISTRO { get; set; }

    public DateTime? DT_REGISTRO { get; set; }
}
