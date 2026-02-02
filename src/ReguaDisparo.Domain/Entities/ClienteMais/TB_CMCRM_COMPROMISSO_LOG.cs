using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMPROMISSO_LOG
{
    public int? ID_COMPROMISSO { get; set; }

    public int? ID_USUARIO { get; set; }

    public int? ID_CASO { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CAMPANHA { get; set; }

    public int? ID_CONTATO { get; set; }

    public DateTime? DT_INICIO { get; set; }

    public DateTime? DT_FIM { get; set; }

    public string? DS_ASSUNTO { get; set; }

    public string? DS_DESCRICAO { get; set; }

    public string? DS_LOCAL { get; set; }

    public int? ID_TIPO_COMPROMISSO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? ID_CASO_VISITA { get; set; }

    public DateTime? DT_EXCLUSAO { get; set; }

    public int? ID_USUARIO_EXCLUSAO { get; set; }
}
