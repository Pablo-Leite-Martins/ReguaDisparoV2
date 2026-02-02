using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_DATAS_REPASSE_HYPNOBOX
{
    public int ID_TOTVS_FATO_DATAS_REPASSE_HYPPNOBOX { get; set; }

    public string? propostaHypnobox { get; set; }

    public string? numeroVenda { get; set; }

    public string? dataGeracaoRP { get; set; }

    public string? dataAssinaturaRP { get; set; }

    public string? dataAssinaturaCEF { get; set; }

    public string? dataCartorio { get; set; }

    public string? dataAssinaturaTodosProponentes { get; set; }

    public string? dataVenda { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
