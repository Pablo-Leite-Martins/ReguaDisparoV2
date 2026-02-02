using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_POSTAGEM_MR
{
    public int ID_TIPO_POSTAGEM_MRS { get; set; }

    public int ID_CODIGO_POSTAGEM { get; set; }

    public string DS_TIPO_POSTAGEM { get; set; } = null!;
}
