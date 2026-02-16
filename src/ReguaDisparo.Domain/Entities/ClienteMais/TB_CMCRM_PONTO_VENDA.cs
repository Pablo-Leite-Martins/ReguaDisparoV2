using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PONTO_VENDA
{
    public int ID_PONTO_VENDA { get; set; }

    public string DS_PONTO_VENDA { get; set; } = null!;

    public int? ID_PRODUTO { get; set; }

    public TimeOnly? NR_HORA_INICIAL { get; set; }

    public TimeOnly? NR_HORA_FINAL { get; set; }

    public int? NR_INTERVALO { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_VISITA> TB_CMCRM_CASO_VISITa { get; set; } = new List<TB_CMCRM_CASO_VISITA>();

    public virtual ICollection<TB_CMCRM_FILA_ATENDIMENTO> TB_CMCRM_FILA_ATENDIMENTOs { get; set; } = new List<TB_CMCRM_FILA_ATENDIMENTO>();
}
