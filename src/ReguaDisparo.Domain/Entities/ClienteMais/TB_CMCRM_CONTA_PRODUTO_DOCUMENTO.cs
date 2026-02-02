using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CONTA_PRODUTO_DOCUMENTO
{
    public int ID_CONTA_PRODUTO_DOCUMENTO { get; set; }

    public int ID_CONTA_PRODUTO { get; set; }

    public byte[] IM_DOCUMENTO { get; set; } = null!;

    public string DS_DOCUMENTO { get; set; } = null!;

    public int NR_TAMANHO { get; set; }

    public string DS_TIPO { get; set; } = null!;

    public DateTime DT_CADASTRO { get; set; }

    public int ID_TIPO_DOCUMENTO { get; set; }

    public string? DS_LINK_DRIVE { get; set; }

    public virtual TB_CMCRM_CONTA_PRODUTO ID_CONTA_PRODUTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_DOCUMENTO ID_TIPO_DOCUMENTONavigation { get; set; } = null!;
}
