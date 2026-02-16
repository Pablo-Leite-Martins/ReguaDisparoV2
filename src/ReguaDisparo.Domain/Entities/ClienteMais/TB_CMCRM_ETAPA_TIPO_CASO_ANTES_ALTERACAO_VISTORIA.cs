using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_ETAPA_TIPO_CASO_ANTES_ALTERACAO_VISTORIA
{
    public int ID_ETAPA_TIPO_CASO { get; set; }

    public int ID_TIPO_CASO { get; set; }

    public string DS_ETAPA { get; set; } = null!;

    public int NR_ETAPA { get; set; }

    public bool? FL_ETAPA_INICIAL { get; set; }

    public bool? FL_ETAPA_FINAL { get; set; }

    public string? CD_ETAPA { get; set; }

    public bool FL_NOTIFICAR_CLIENTE { get; set; }
}
