using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PARCELAS_SERASA_2023_03_21
{
    public int ID_PARCELAS_SERASA { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public DateTime DT_VENCIMENTO { get; set; }

    public int? ID_USUARIO_NEGATIVACAO { get; set; }

    public int? ID_USUARIO_POSITIVACAO { get; set; }

    public DateTime? DT_NEGATIVACAO { get; set; }

    public DateTime? DT_POSITIVACAO { get; set; }

    public int? ID_ENVIO_SERASA { get; set; }

    public string? DS_STATUS_SERASA { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CONTATO_FIADOR { get; set; }
}
