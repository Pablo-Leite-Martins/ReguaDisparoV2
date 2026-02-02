using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_VISITum
{
    public int ID_CASO_VISITA { get; set; }

    public int ID_CASO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_USUARIO_CADASTRO { get; set; }

    public int? ID_USUARIO_RESPONSAVEL { get; set; }

    public DateTime? DT_CASO_VISITA { get; set; }

    public int? ID_PONTO_VENDA { get; set; }

    public bool FL_EFETIVADA { get; set; }

    public int? ID_TIPO_VISITA { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_PONTO_VENDum? ID_PONTO_VENDANavigation { get; set; }

    public virtual TB_CMCRM_TIPO_VISITum? ID_TIPO_VISITANavigation { get; set; }

    public virtual ICollection<TB_CMCRM_COMPROMISSO> TB_CMCRM_COMPROMISSOs { get; set; } = new List<TB_CMCRM_COMPROMISSO>();
}
