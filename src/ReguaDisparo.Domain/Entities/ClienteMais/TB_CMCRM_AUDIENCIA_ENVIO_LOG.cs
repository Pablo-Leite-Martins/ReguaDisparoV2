using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_AUDIENCIA_ENVIO_LOG
{
    public int ID_AUDIENCIA_ENVIO_LOG { get; set; }

    public int ID_AUDIENCIA { get; set; }

    public string? DS_CLIENTE { get; set; }

    public string DS_EMAIL { get; set; } = null!;

    public string? NR_TELEFONE { get; set; }

    public string? DS_CONTEUDO_ENVIADO { get; set; }

    public int ID_TIPO_COMUNICADO { get; set; }

    public DateTime DT_ENVIO { get; set; }

    public bool? FL_SUCESSO { get; set; }

    public string? DS_STATUS { get; set; }

    public int? ID_DOCUMENTO_TEMPLATE { get; set; }

    public int? ID_CONTA { get; set; }
}
