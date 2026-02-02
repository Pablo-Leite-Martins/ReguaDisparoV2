using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_ANUNCIO
{
    public int ID_PRODUTO_ANUNCIO { get; set; }

    public int ID_PRODUTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public DateTime? DT_INICIO_ANUNCIO { get; set; }

    public DateTime? DT_FIM_ANUNCIO { get; set; }

    public string? DS_TOKEN_ANUNCIO { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
