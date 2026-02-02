using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_DOCUMENTO_IMPORTACAO_20230810
{
    public int ID_DOCUMENTO_IMPORTACAO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public string? DS_NOME_DOCUMENTO { get; set; }

    public byte[]? IM_DOCUMENTO { get; set; }

    public bool? FL_SINCRONIZADO { get; set; }

    public DateTime? DT_VENDA { get; set; }
}
