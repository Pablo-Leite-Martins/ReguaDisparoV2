using System;
using System.Collections.Generic;

namespace ReguaDisparo.Domain.Entities.ClienteMais;

public partial class TB_CMCRM_CASO_HISTORICO_LOG
{
    public int ID_CASO_HISTORICO { get; set; }

    public string? DS_HISTORICO { get; set; }

    public int? ID_USUARIO { get; set; }

    public DateTime? DT_CADASTRO { get; set; }

    public int? ID_CASO { get; set; }

    public bool? FL_SISTEMA_USUARIO { get; set; }

    public int? ID_ETAPA_TIPO_CASO { get; set; }

    public int? ID_ETAPA_CATEGORIA_ATENDIMENTO_TIPO_CASO { get; set; }

    public bool? FL_ORIGEM_CHAT { get; set; }

    public int? ID_CASO_ATIVIDADE { get; set; }

    public bool? FL_ORIGEM_EMAIL { get; set; }

    public bool? FL_CLIENTE_VISUALIZAR_HISTORICO { get; set; }

    public bool? FL_ATENDIMENTO_SINC_UAU { get; set; }

    public DateTime? DT_EXCLUSAO { get; set; }

    public int? ID_USUARIO_EXCLUSAO { get; set; }
}
