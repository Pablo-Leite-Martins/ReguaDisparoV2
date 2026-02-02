using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_MOTIVO_PROBLEMA
{
    public int ID_MOTIVO_PROBLEMA { get; set; }

    public string DS_MOTIVO_PROBLEMA { get; set; } = null!;

    public int? ID_MOTIVO_PROBLEMA_PAI { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_USUARIO { get; set; }

    public bool? FL_ATIVO { get; set; }

    public virtual TB_CMCRM_MOTIVO_PROBLEMA? ID_MOTIVO_PROBLEMA_PAINavigation { get; set; }

    public virtual ICollection<TB_CMCRM_MOTIVO_PROBLEMA> InverseID_MOTIVO_PROBLEMA_PAINavigation { get; set; } = new List<TB_CMCRM_MOTIVO_PROBLEMA>();

    public virtual ICollection<TB_CMCRM_CASO_DADOS_FECHAMENTO> TB_CMCRM_CASO_DADOS_FECHAMENTOs { get; set; } = new List<TB_CMCRM_CASO_DADOS_FECHAMENTO>();
}
