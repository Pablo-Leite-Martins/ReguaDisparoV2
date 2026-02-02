using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_FILA_ATENDIMENTO
{
    public int ID_FILA_ATENDIMENTO { get; set; }

    public string DS_FILA_ATENDIMENTO { get; set; } = null!;

    public int? ID_ORIGEM_LEAD { get; set; }

    public bool FL_ATIVO { get; set; }

    public int? ID_PONTO_VENDA { get; set; }

    public bool? FL_TELEFONIA { get; set; }

    public string? ID_CAMPANHA { get; set; }

    public string? HR_INICIO { get; set; }

    public string? HR_FIM { get; set; }

    public int? ID_USUARIO_COORDENADOR { get; set; }

    public virtual TB_CMCRM_ORIGEM_LEAD? ID_ORIGEM_LEADNavigation { get; set; }

    public virtual TB_CMCRM_PONTO_VENDum? ID_PONTO_VENDANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOG> TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOGs { get; set; } = new List<TB_CMCRM_FILA_ATENDIMENTO_DISTRIBUICAO_LOG>();

    public virtual ICollection<TB_CMCRM_FILA_ATENDIMENTO_USUARIO> TB_CMCRM_FILA_ATENDIMENTO_USUARIOs { get; set; } = new List<TB_CMCRM_FILA_ATENDIMENTO_USUARIO>();

    public virtual ICollection<TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTO> TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_ORIGEM_LEAD_FILA_ATENDIMENTO>();
}
