using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_SUBCATEGORIA_ATENDIMENTO
{
    public int ID_SUBCATEGORIA_ATENDIMENTO { get; set; }

    public int? ID_PRODUTO { get; set; }

    public int ID_CATEGORIA_ATENDIMENTO { get; set; }

    public string DS_SUBCATEGORIA_ATENDIMENTO { get; set; } = null!;

    public virtual TB_CMCRM_CATEGORIA_ATENDIMENTO ID_CATEGORIA_ATENDIMENTONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PRODUTO? ID_PRODUTONavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO> TB_CMCRM_CASOs { get; set; } = new List<TB_CMCRM_CASO>();
}
