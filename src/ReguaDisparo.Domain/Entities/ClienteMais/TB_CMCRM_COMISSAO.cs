using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_COMISSAO
{
    public int ID_COMISSAO { get; set; }

    public int ID_CONTA_PRODUTO { get; set; }

    public int? ID_USUARIO_BENEFICIADO { get; set; }

    public int? ID_EQUIPE_VENDAS { get; set; }

    public int ID_CASO { get; set; }

    public decimal VL_COMISSAO { get; set; }

    public string DS_STATUS_COMISSAO { get; set; } = null!;

    public DateTime DT_CRIACAO { get; set; }

    public DateTime? DT_PAGAMENTO_COMISSAO { get; set; }
}
