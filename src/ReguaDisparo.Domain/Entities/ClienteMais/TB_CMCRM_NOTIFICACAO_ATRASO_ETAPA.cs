using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_NOTIFICACAO_ATRASO_ETAPA
{
    public int ID_NOTIFICACAO_ATRASO { get; set; }

    public string? DS_NOTIFICACAO_ATRASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public int ID_USUARIO_DESTINATARIO { get; set; }

    public int NR_AGING_ATRASO_ETAPA { get; set; }

    public DateTime? DT_ENVIO { get; set; }
}
