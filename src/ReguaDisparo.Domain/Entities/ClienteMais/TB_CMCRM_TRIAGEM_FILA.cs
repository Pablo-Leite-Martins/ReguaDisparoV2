using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TRIAGEM_FILA
{
    public int ID_TRIAGEM_FILA { get; set; }

    public string? DS_TRIAGEM_FILA { get; set; }

    public int? ID_EMAIL_CONTA_CONFIG { get; set; }

    public bool? FL_ATIVO { get; set; }

    public int? ID_USUARIO_COORDENADOR { get; set; }

    public virtual TB_CMCRM_EMAIL_CONTA_CONFIG? ID_EMAIL_CONTA_CONFIGNavigation { get; set; }

    public virtual ICollection<TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAO> TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAOs { get; set; } = new List<TB_CMCRM_TRIAGEM_FILA_DISTRIBUICAO>();

    public virtual ICollection<TB_CMCRM_TRIAGEM_FILA_USUARIO> TB_CMCRM_TRIAGEM_FILA_USUARIOs { get; set; } = new List<TB_CMCRM_TRIAGEM_FILA_USUARIO>();
}
