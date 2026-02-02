using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_DOCUMENTO
{
    public int ID_CASO_DOCUMENTO { get; set; }

    public int ID_CASO { get; set; }

    public byte[]? IM_DOCUMENTO { get; set; }

    public string DS_DOCUMENTO { get; set; } = null!;

    public int NR_TAMANHO { get; set; }

    public string DS_TIPO { get; set; } = null!;

    public DateTime DT_CADASTRO { get; set; }

    public int? ID_TIPO_DOCUMENTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public string? DS_LINK_DRIVE { get; set; }

    public bool? FL_SINC_UAU { get; set; }

    public int? NR_TENTATIVAS_ENVIO_UAU { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_DOCUMENTO? ID_TIPO_DOCUMENTONavigation { get; set; }
}
