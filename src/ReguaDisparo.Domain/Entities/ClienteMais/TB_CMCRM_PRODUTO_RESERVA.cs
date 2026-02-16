using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PRODUTO_RESERVA
{
    public int ID_PRODUTO_RESERVA { get; set; }

    public int ID_PRODUTO { get; set; }

    public int? ID_CONTA { get; set; }

    public string? DS_RESERVA { get; set; }

    public DateTime? DT_INICIO_RESERVA { get; set; }

    public DateTime? DT_FIM_RESERVA { get; set; }

    public DateTime? DT_PREVISAO_FIM_RESERVA { get; set; }

    public int? ID_USUARIO { get; set; }

    public string? ID_CHAVE_ERP { get; set; }

    public virtual TB_CMCRM_CONTA? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_PRODUTO ID_PRODUTONavigation { get; set; } = null!;
}
