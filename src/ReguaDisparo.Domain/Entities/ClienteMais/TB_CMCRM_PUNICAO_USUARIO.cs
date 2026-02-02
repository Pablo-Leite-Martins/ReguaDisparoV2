using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_PUNICAO_USUARIO
{
    public int ID_PUNICAO_USUARIO { get; set; }

    public string DS_PUNICAO { get; set; } = null!;

    public DateTime DT_INICIO_PUNICAO { get; set; }

    public DateTime DT_FIM_PUNICAO { get; set; }

    public int ID_USUARIO { get; set; }

    public bool FL_ENCERRADA { get; set; }

    public virtual ICollection<TB_CMCRM_PUNICAO_USUARIO_LOG> TB_CMCRM_PUNICAO_USUARIO_LOGs { get; set; } = new List<TB_CMCRM_PUNICAO_USUARIO_LOG>();
}
