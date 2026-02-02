using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ACAO_ETAPA_TIPO_CASO
{
    public int ID_ACAO_ETAPA_TIPO_CASO { get; set; }

    public string? DS_ACAO_ETAPA_TIPO_CASO { get; set; }

    public string? DS_TIPO_ACAO_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_TIPO_CASO_DESTINO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public bool? FL_INSERIR_JUSTIFICATIVA_FECHAMENTO_CASO { get; set; }

    public virtual TB_CMCRM_ETAPA_TIPO_CASO? ID_ETAPA_TIPO_CASONavigation { get; set; }
}
