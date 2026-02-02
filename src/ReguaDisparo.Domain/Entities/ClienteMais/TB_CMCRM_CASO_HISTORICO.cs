using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_HISTORICO
{
    public int ID_CASO_HISTORICO { get; set; }

    public string DS_HISTORICO { get; set; } = null!;

    public int ID_USUARIO { get; set; }

    public DateTime DT_CADASTRO { get; set; }

    public int ID_CASO { get; set; }

    public bool FL_SISTEMA_USUARIO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool? FL_ORIGEM_CHAT { get; set; }

    public int? ID_CASO_ATIVIDADE { get; set; }

    public bool? FL_ORIGEM_EMAIL { get; set; }

    public bool FL_CLIENTE_VISUALIZAR_HISTORICO { get; set; }

    public bool? FL_ATENDIMENTO_SINC_UAU { get; set; }

    public int? ID_CASO_VISITA { get; set; }

    public bool? FL_LIDO { get; set; }

    public virtual TB_CMCRM_CASO ID_CASONavigation { get; set; } = null!;

    public virtual TB_CMCRM_CASO_ATIVIDADE? ID_CASO_ATIVIDADENavigation { get; set; }

    public virtual ICollection<TB_CMCRM_CASO_HISTORICO_SINCRONIum> TB_CMCRM_CASO_HISTORICO_SINCRONIa { get; set; } = new List<TB_CMCRM_CASO_HISTORICO_SINCRONIum>();
}
