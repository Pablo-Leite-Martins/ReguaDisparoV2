using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PARCELAS_SERASA
{
    public int ID_PARCELAS_SERASA { get; set; }

    public string ID_CHAVE_ERP { get; set; } = null!;

    public DateTime DT_VENCIMENTO { get; set; }

    public int? ID_USUARIO_NEGATIVACAO { get; set; }

    public int? ID_USUARIO_POSITIVACAO { get; set; }

    public DateTime? DT_NEGATIVACAO { get; set; }

    public DateTime? DT_POSITIVACAO { get; set; }

    public string? DS_STATUS_SERASA { get; set; }

    public int? ID_CONTA { get; set; }

    public int? ID_CONTATO_FIADOR { get; set; }

    public string? ID_ENVIO_SERASA { get; set; }

    public string? NR_CNPJ { get; set; }

    public virtual TB_CMCRM_CONTum? ID_CONTANavigation { get; set; }

    public virtual TB_CMCRM_CONTATO? ID_CONTATO_FIADORNavigation { get; set; }
}
