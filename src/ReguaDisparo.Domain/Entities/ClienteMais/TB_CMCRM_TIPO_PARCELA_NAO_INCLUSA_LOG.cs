using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PARCELA_NAO_INCLUSA_LOG
{
    public int ID_TIPO_PARCELA { get; set; }

    public string COD_TIPO_PARCELA { get; set; } = null!;

    public string DS_TIPO_PARCELA { get; set; } = null!;

    public DateTime DT_GRAVACAO { get; set; }

    public string DS_TIPO_GRAVACAO { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public int ID_TIPO_PARCELA_NAO_INCLUSA_LOG { get; set; }
}
