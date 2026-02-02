using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_DOCUMENTO_GERADO
{
    public int ID_CASO_DOCUMENTO_GERADO { get; set; }

    public string DS_HTML { get; set; } = null!;

    public int ID_USUARIO_RESPONSAVEL { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_CASO { get; set; }

    public int ID_DOCUMENTO_TEMPLATE { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_DOCUMENTO_TEMPLATE ID_DOCUMENTO_TEMPLATENavigation { get; set; } = null!;
}
