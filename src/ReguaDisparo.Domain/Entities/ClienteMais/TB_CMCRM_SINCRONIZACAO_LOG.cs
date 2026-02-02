using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SINCRONIZACAO_LOG
{
    public int ID_SINCRONIZACAO_LOG { get; set; }

    public DateTime DT_HORARIO { get; set; }

    public string DS_SINCRONIZACAO_LOG { get; set; } = null!;

    public bool FL_DOWNLOAD { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public int? ID_CASO { get; set; }

    public bool FL_ERRO { get; set; }

    public virtual TB_CMCRM_CASO? ID_CASONavigation { get; set; }
}
