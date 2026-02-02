using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_ATIVIDADE
{
    public int ID_CASO_ATIVIDADE { get; set; }

    public int ID_CASO { get; set; }

    public int ID_TIPO_ATIVIDADE { get; set; }

    public DateTime DT_CASO_ATIVIDADE { get; set; }

    public TimeOnly? DT_DURACAO { get; set; }

    public int? ID_USUARIO_CADASTRO { get; set; }

    public bool? FL_CONCLUIDO { get; set; }

    public DateTime? DT_CONCLUSAO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public decimal? VL_CUSTO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_TIPO_ATIVIDADE ID_TIPO_ATIVIDADENavigation { get; set; } = null!;

    public virtual ICollection<TB_CMCRM_CASO_HISTORICO> TB_CMCRM_CASO_HISTORICOs { get; set; } = new List<TB_CMCRM_CASO_HISTORICO>();

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();
}
