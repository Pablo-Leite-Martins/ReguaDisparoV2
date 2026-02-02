using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_REMESSA_SERASA
{
    public int ID_REMESSA_SERASA { get; set; }

    public string ID_CHAVE_ERP_PARCELA { get; set; } = null!;

    public int ID_EMPRESA { get; set; }

    public string ID_OBRA { get; set; } = null!;

    public int ID_VENDA { get; set; }

    public int ID_PARCELA { get; set; }

    public string ID_TIPO_PARCELA { get; set; } = null!;

    public decimal? VL_PARCELA { get; set; }

    public DateTime DT_INCLUSAO { get; set; }

    public int NR_REMESSA_INCLUSAO { get; set; }

    public int ID_USUARIO_INCLUSAO { get; set; }

    public DateTime? DT_EXCLUSAO { get; set; }

    public int? NR_REMESSA_EXCLUSAO { get; set; }

    public int? ID_USUARIO_EXCLUSAO { get; set; }
}
