using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TOTVS_FATO_DATAS_REPASSE
{
    public int ID_TOTVS_FATO_DATAS_REPASSE { get; set; }

    public int? ID { get; set; }

    public int? PROPOSTAHYPNOBOX { get; set; }

    public int? NUMEROVENDA { get; set; }

    public string? DATAGERACAORP { get; set; }

    public string? DATAASSINATURARP { get; set; }

    public string? DATAASSINATURACEF { get; set; }

    public string? DATACARTORIO { get; set; }

    public string? DATAATUALIZACAO { get; set; }

    public DateTime? DT_MES_REFERENCIA { get; set; }
}
