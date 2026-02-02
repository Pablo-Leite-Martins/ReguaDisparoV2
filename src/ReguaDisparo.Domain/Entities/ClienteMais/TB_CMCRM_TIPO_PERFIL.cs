using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_TIPO_PERFIL
{
    public int ID_TIPO_PERFIL { get; set; }

    public string DS_TIPO_PERFIL { get; set; } = null!;

    public bool FL_ATIVO { get; set; }

    public virtual ICollection<TB_CMCRM_TIPO_PERFIL_ATRIBUTO> TB_CMCRM_TIPO_PERFIL_ATRIBUTOs { get; set; } = new List<TB_CMCRM_TIPO_PERFIL_ATRIBUTO>();

    public virtual ICollection<TB_CMCRM_TIPO_PERFIL_ETAPA_TIPO_CASO> TB_CMCRM_TIPO_PERFIL_ETAPA_TIPO_CASOs { get; set; } = new List<TB_CMCRM_TIPO_PERFIL_ETAPA_TIPO_CASO>();
}
