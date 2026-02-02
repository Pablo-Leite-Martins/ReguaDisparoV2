using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_DOCUMENTO_LOG
{
    public int ID_CASO_DOCUMENTO { get; set; }

    public int? ID_CASO { get; set; }

    public byte[]? IM_DOCUMENTO { get; set; }

    public string? DS_DOCUMENTO { get; set; }

    public int? NR_TAMANHO { get; set; }

    public string? DS_TIPO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_TIPO_DOCUMENTO { get; set; }

    public int? ID_USUARIO { get; set; }

    public string? DS_LINK_DRIVE { get; set; }

    public DateTime? DT_EXCLUSAO { get; set; }

    public int? ID_USUARIO_EXCLUSAO { get; set; }

    public bool FL_EXCLUSAO_DRIVE { get; set; }

    public bool? FL_SINC_UAU { get; set; }
}
